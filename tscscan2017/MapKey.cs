using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tscscan2017
{
    public partial class MapKey : Form
    {
        public MapKey()
        {
            InitializeComponent();
            pictureBox1.Image = GetImageByName("us_keybd");
            pictureBox1.Refresh();
            pictureBox2.Image = GetImageByName("us_keybd");
            pictureBox2.Refresh();

            pictureBox1.MouseClick += new MouseEventHandler(pictureBox1_MouseClick);

            cbo_LangInput.DataSource = Enum.GetNames(typeof(ScanCodes.scancode.LangKeybdlayout));
            cboLangOutput.DataSource = Enum.GetNames(typeof(ScanCodes.scancode.LangKeybdlayout));

            cbo_LangInput.SelectedValueChanged += new EventHandler(cboLang_SelectedValueChanged);
            cboLangOutput.SelectedValueChanged += new EventHandler(cboLang_SelectedValueChanged);
        }

        void cboLang_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string fname = cb.SelectedItem.ToString().ToLower() + "_keybd";
            if (cb.Name == cbo_LangInput.Name)
            {
                pictureBox1.Image = GetImageByName(fname);
                pictureBox1.Refresh();
            }
            else {
                pictureBox2.Image = GetImageByName(fname);
                pictureBox2.Refresh();
            }
            
        }

        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //image is 600x200
            //keyboard image has 5 rows (first row with ESC and F1 to F12 is missing!
            //first row has 15 parts, last two parts are one key (backspace)

            int x = e.X;
            int y = e.Y;

            int scanCode = ScanCodes.scancode.getScanCodeByBitmap(x, y, pictureBox1.Width, pictureBox1.Height);
            System.Diagnostics.Debug.WriteLine("SCANCODE= 0x" + scanCode.ToString("x02"));

            string sLangIn = cbo_LangInput.SelectedItem.ToString().ToLower();
            string sLangOut = cboLangOutput.SelectedItem.ToString().ToLower();

            string sIN = ScanCodes.scancode.getCharForScancode(scanCode, (ScanCodes.scancode.LangKeybdlayout)Enum.Parse(typeof(ScanCodes.scancode.LangKeybdlayout),sLangIn.ToUpper()));
            string sOUT = ScanCodes.scancode.getCharForScancode(scanCode, (ScanCodes.scancode.LangKeybdlayout)Enum.Parse(typeof(ScanCodes.scancode.LangKeybdlayout), sLangOut.ToUpper()));

            txtScancodeIn.Text = txtScancodeOut.Text = scanCode.ToString();
            txtCharIn.Text = sIN;
            txtcharOut.Text = sOUT;

            System.Diagnostics.Debug.WriteLine("Char by kbd lang, "+sLangIn+"=" + sIN + ", "+sLangOut+"=" + sOUT);
        }

        public static Bitmap GetImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            return (Bitmap)rm.GetObject(imageName);

        }

    }
}
