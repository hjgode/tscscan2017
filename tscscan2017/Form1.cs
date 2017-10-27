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
    public partial class Form1 : Form
    {
        tscscan.tscscanlist scanlist = new tscscan.tscscanlist();
        tscshift.tscshiftlist shiftlist = new tscshift.tscshiftlist();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_readTscscan_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
                        dlg.CheckFileExists = true; dlg.CheckPathExists = true;
                        dlg.Filter = "tscscan.txt|tscscan.txt|Text files|*.txt|All files|*.*";
                        dlg.FilterIndex = 0;
                        dlg.RestoreDirectory = true;
            dlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    scanlist.readfile(dlg.FileName);
                    dataGridViewTscscan.DataSource = scanlist.mytscscanlist;
                }
                catch (Exception) { }
            }
        }

        private void dataGridViewTscscan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tscscan tscItem = (tscscan)dataGridViewTscscan.CurrentRow.DataBoundItem;
            txtChar.Text = tscItem.unshiftedchar.ToString() +
                ", 0x" + tscItem.unshiftedchar.ToString("x02") +
                ", '" + Convert.ToChar(tscItem.unshiftedchar) + "'";
            txtChar.Refresh();
            txtScancode.Text = tscItem.scancode.ToString() +
                ", 0x" + tscItem.scancode.ToString("x02") +
                ", " + ScanCodes.scancode.scancodesUS[tscItem.scancode]._keyChar;
            txtScancode.Refresh();
        }

        private void btn_ReadTscShift_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true; dlg.CheckPathExists = true;
            dlg.Filter = "tscshift.txt|tscshift.txt|Text files|*.txt|All files|*.*";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    shiftlist.readfile(dlg.FileName);
                    dataGridViewShiftList.DataSource = shiftlist.myShiftlist;
                    string filepath = System.IO.Path.GetDirectoryName(dlg.FileName);
                    if (!filepath.EndsWith("\\"))
                        filepath += "\\";
                    if (System.IO.File.Exists(filepath + "tscscan.txt"))
                    {
                        scanlist.readfile(filepath + "tscscan.txt");
                        dataGridViewTscscan.DataSource = scanlist.mytscscanlist;
                    }
                }
                catch (Exception)
                {
                }
            }

        }

        private void dataGridViewShiftList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tscshift tscShiftItem = (tscshift)dataGridViewShiftList.CurrentRow.DataBoundItem;
            txtCharIn.Text = tscShiftItem.charcodeIn.ToString() +
                ", 0x" + tscShiftItem.charcodeIn.ToString("x02") +
                ", '" + Convert.ToChar(tscShiftItem.charcodeIn) + "'";
            txtCharIn.Refresh();
            txtCharOut.Text = tscShiftItem.charcodeOut.ToString() +
                ", 0x" + tscShiftItem.charcodeOut.ToString("x02") +
                ", '" + Convert.ToChar(tscShiftItem.charcodeOut) + "'";
            txtScancode.Refresh();
            txtShifted.Text = tscShiftItem.shifted == 1 ? "true" : "false";
            txtShifted.Refresh();

            if (dataGridViewTscscan.Rows.Count > 0)
            {
                //lookup charcodeOut in tscscan, simply scroll to row with index
                dataGridViewTscscan.ClearSelection();
                dataGridViewTscscan.Rows[tscShiftItem.charcodeOut].Selected = true;

                dataGridViewTscscan.FirstDisplayedScrollingRowIndex = dataGridViewTscscan.SelectedRows[0].Index;
                tscscan tscScanItem = (tscscan)dataGridViewTscscan.Rows[tscShiftItem.charcodeOut].DataBoundItem;

                dataGridViewTscscan.CurrentCell=dataGridViewTscscan.SelectedRows[0].Cells[0];
                dataGridViewTscscan_CellClick(new object(), new DataGridViewCellEventArgs(0, dataGridViewTscscan.SelectedRows[0].Index));

                txtFunction.Text = "Typed: " + (tscShiftItem.shifted == 1 ? "Shift+" : "Normal+") + Convert.ToChar(tscShiftItem.charcodeOut) + " (" +
                    Convert.ToChar(tscShiftItem.charcodeIn) + ")" +
                    "==>>" + 
                    ", 0x" + tscScanItem.scancode.ToString("x02") + ", " + 
                    (tscShiftItem.shifted == 1? ScanCodes.scancode.scancodesUS[tscScanItem.scancode].Shifted:ScanCodes.scancode.scancodesUS[tscScanItem.scancode].Normal);
                
                int scancode=tscScanItem.scancode;
                int shifted = tscShiftItem.shifted;
                string deKeybd = (shifted == 1 ? ScanCodes.scancode.scancodesDE[scancode].Shifted : ScanCodes.scancode.scancodesDE[scancode].Normal);
                string usKeybd = (shifted == 1 ? ScanCodes.scancode.scancodesUS[scancode].Shifted : ScanCodes.scancode.scancodesUS[scancode].Normal);
                txtFunction.Text += " DE='" + deKeybd + "', US='" + usKeybd + "'";
                txtFunction.Refresh();
            }

        }

        private void dataGridViewShiftList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ( (e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.Value != null)
            {
                long value = 0;
                if (long.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = "0x" + value.ToString("X");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridViewTscscan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ( (e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.Value != null)
            {
                long value = 0;
                if (long.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = "0x" + value.ToString("X");
                    e.FormattingApplied = true;
                }
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int iCh=Convert.ToInt16(ch);
            string iStr = iCh.ToString();
            if (dataGridViewShiftList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewShiftList.Rows)
                {
                    if (row.Cells[0].Value.ToString() == iStr)
                    {
                        dataGridViewShiftList.ClearSelection();
                        row.Selected = true;
                        dataGridViewShiftList.FirstDisplayedScrollingRowIndex = dataGridViewShiftList.SelectedRows[0].Index;
                        dataGridViewShiftList.CurrentCell = dataGridViewShiftList.SelectedRows[0].Cells[0];
                        dataGridViewShiftList_CellClick(new object(), new DataGridViewCellEventArgs(0, row.Index));
                        break;
                    }
                }
            }
            e.Handled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!utils.IsPrintableChar(e.KeyData))
            {
                System.Diagnostics.Debug.WriteLine("non printable key: " + e.KeyData.ToString());
                System.Diagnostics.Debug.WriteLine("char value: " + Convert.ToInt16(utils.getIntChar(e.KeyData)));
                //lookup non-printable key in tscscan
                int iKey = (int)(e.KeyCode);
                if (dataGridViewTscscan.Rows.Count > 0)
                {
                    //for VKEY and ASCII go to index line
                    dataGridViewTscscan.ClearSelection();
                    dataGridViewTscscan.FirstDisplayedScrollingRowIndex = iKey;
                    dataGridViewTscscan.Rows[iKey].Selected = true;
                    dataGridViewTscscan.CurrentCell = dataGridViewTscscan.SelectedRows[0].Cells[0];
                    dataGridViewTscscan_CellClick(new object(), new DataGridViewCellEventArgs(0, iKey));
                }

            }
            e.Handled = true;
        }

        private void mapKeysForRDMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapKey frm = new MapKey();
            frm.ShowDialog();
        }


    }
}
