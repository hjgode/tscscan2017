using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ScanCodes
{
    public class scancode
    {
        public int _scancode { get; set; }
        public string _keyChar { get; set; }
        public string Normal { 
            get {
                if (!controlScancodes.Contains(_scancode))
                    return _keyChar.Substring(0, 1);
                else
                    return _keyChar;
            } 
        }
        public string Shifted
        {
            get
            {
                if (!controlScancodes.Contains(_scancode) && _keyChar.Length > 1)
                    return _keyChar.Substring(1, 1);
                else
                    return _keyChar;
            }
        }
        public string AltGr
        {
            get
            {
                if (!controlScancodes.Contains(_scancode) && _keyChar.Length==3)
                    return _keyChar.Substring(2, 1);
                else
                    return _keyChar;
            }
        }

        int[] controlScancodes = new int[] {0x00,0x01,0x0e,0x0f,0x1c,0x1d,0x2a,0x36,0x38,0x3a,
            0x3b,0x3c,0x3d,0x3e,0x3f,0x40,0x41,0x42,0x43,0x44,  //F1 to F10
            0x45,0x46, 
            0x47,0x48,0x49,0x4a,0x4b,0x4c,0x4d,0x4e,0x4f,0x50,0x51,0x52,0x53, //NumPad
            0x54
        };

        public scancode()
        {
        }
        public scancode(int bScancode, string sKey)
        {
            _scancode = bScancode;
            _keyChar = sKey;
        }
        public override string ToString()
        {
            return _keyChar;
        }
        public enum LangKeybdlayout
        {
            US,
            DE,
            IT,
            SP,
            FR
        }
        public static scancode[] getScanCodes(LangKeybdlayout layout)
        {
            switch (layout)
            {
                case LangKeybdlayout.US:
                    return scancodesUS;
                case LangKeybdlayout.DE:
                    return scancodesDE;
                case LangKeybdlayout.IT:
                    return scancodesIT;
                case LangKeybdlayout.FR:
                    return scancodesFR;
                default:
                    return scancodesUS;
            }
        }

        public static int[][] scancodes_matrix=new int[6][]{
            new int[]{0x01, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x40, 0x41, 0x42, 0x43, 0x44, 0x57, 0x58},                     //esc and F1 to F12, 3b (F1), 3c (F2), 3d (F3), 3e (F4), 3f (F5), 40 (F6), 41 (F7), 42 (F8), 43 (F9), 44 (F10), 0x57 (F11), 0x58 (F12)
            //double wide BS key
            new int[]{0x29, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e},    //29 (`~), 02 (1!), 03 (2@), 04 (3#), 05 (4$), 06 (5%E), 07 (6^), 08 (7&), 09 (8*), 0a (9(), 0b (0)), 0c (-_), 0d (=+), 0e (Backspace) (double wide key)
            //double wide TAB key
            new int[]{0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1b, 0x2b},   //0f (Tab), 10 (Q), 11 (W), 12 (E), 13 (R), 14 (T), 15 (Y), 16 (U), 17 (I), 18 (O), 19 (P), 1a ([{), 1b (]}), 0x2b (\|),  
            //double wide Caps key, double wide Enter key
            new int[]{0x3a, 0x1e, 0x1f, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x16, 0x27, 0x28, 0x1c},    // 0x3a CapsLock 1e (A), 1f (S), 20 (D), 21 (F), 22 (G), 23 (H), 24 (J), 25 (K), 26 (L), 27 (;:), 28 ('"), 0x1c ENTER (double wide key)
            //double wide LShift key, double wide RShift key
            new int[]{0x2a, 0x2c, 0x2d, 0x2e, 0x2f, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36 },             // 2a (LShift), 2c (Z), 2d (X), 2e (C), 2f (V), 30 (B), 31 (N), 32 (M), 33 (,<), 34 (.>), 35 (/?), 36 (RShift)
            //double wide LCtrl, double wide LAlt, 6xwide Space Bar, double wide RAlt, double wide RCtrl
            new int[]{0x1d, 0x00/*LWIN'*/, 0x38/*LAlt*/, 0x39/*SPACE*/, 0xE038/*RAlt*/, 0x00/*RWIN*/, 0x00/*MENU*/,  0xE01d/*RCtrl*/}   // 1d (LCtrl), WIN KEY, 38 (LAlt), 39 (Space bar), e038 (RAlt), (RWIN), (MENU), E01d (RCtrl)
        };

        //bitmap pixel locations for the keys
        public static int[][] buttonMatrix = new int[6][]{
            new int[] { 0, 46, 92, 138, 184, 230, 276, 322, 368, 414, 460, 506, 552, 600 },
            //second row is 518/13=40 + 80 for backspace
            new int[] { 0, 40, 80, 120, 160, 200, 240, 280, 320, 360, 400, 440, 480, 520, 600 },
            //third row is first 70, 11x40, starting with TAB, last is 60
            new int[]{ 0, 60, 100, 140, 180, 220, 260, 300, 340, 380, 420, 460, 500, 540, 600 }, 
            //fourth row starts with CapsLock and ends with return
            new int[]{ 0, 70, 110, 150, 190, 230, 270, 310, 350, 390, 430, 470, 510, 600 },
            //forth row is first 90 plus 10x40 plus RShift at 490
            new int[]{ 0, 90, 130, 170, 210, 250, 290, 330, 370, 410, 450, 490, 600 },
            //fifth row is 60 plus 40 plus 60 plus 240 (space) plus 60, 40, 40,60
            new int[]{ 0, 60, 100, 160, 400, 460, 500, 540, 600 },
        };

        public static int getScanCodeByBitmap(int xClick, int yClick, int width, int height)
        {
            int iRet = -1;
            int scaledX = 600 / width;
            int scaledY = 240 / height; // ie 240 / 120 = 2
            int rowH = height / 6;
            int rowClicked = yClick / rowH;
            int colClicked = xClick * scaledX;

            int[] bitmapMatrix = ScanCodes.scancode.buttonMatrix[rowClicked];
            for (int x = 0; x < bitmapMatrix.Length-1; x++)
            {
                if (bitmapMatrix[x] < colClicked && bitmapMatrix[x+1] >= colClicked)
                {
                    //found location
                    iRet = x;
                    iRet = scancodes_matrix[rowClicked][iRet]; //get the scancode
                    break;
                }
            }
            return iRet;
        }

        public static string getCharForScancode(int iScancode, LangKeybdlayout langKdb)
        {
            string s = "n/a";
            scancode[] scancodes = getScanCodes(langKdb);
            foreach (scancode scn in scancodes)
            {
                if (scn._scancode == iScancode)
                {
                    s = scn._keyChar;
                    break;
                }
            }
            return s;
        }
#region keyboards
        #region US
        public static scancode[] scancodesUS = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1!"),
            new scancode( 0x03 	,"2@"),
            new scancode( 0x04 	,"3#"),
            new scancode( 0x05 	,"4$"),
            new scancode( 0x06 	,"5%E"),
            new scancode( 0x07 	,"6^"),
            new scancode( 0x08 	,"7&"),
            new scancode( 0x09 	,"8*"),
            new scancode( 0x0a 	,"9\""),
            new scancode( 0x0b 	,"0\""),
            new scancode( 0x0c 	,"-_"),
            new scancode( 0x0d 	,"=+"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"Q"),
            new scancode( 0x11 	,"W"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Y"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"[{"),
            new scancode( 0x1b 	,"]}"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"A"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,";:"),
            new scancode( 0x28 	,"'\""),
            new scancode( 0x29 	,"`~"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"\\|"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"Z"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"M"),
            new scancode( 0x33 	,",<"),
            new scancode( 0x34 	,".>"),
            new scancode( 0x35 	,"/?"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };
        #endregion
        #region DE
        public static scancode[] scancodesDE = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1!"),
            new scancode( 0x03 	,"2\""),
            new scancode( 0x04 	,"3§"),
            new scancode( 0x05 	,"4$"),
            new scancode( 0x06 	,"5%"),
            new scancode( 0x07 	,"6&"),
            new scancode( 0x08 	,"7/{"),
            new scancode( 0x09 	,"8(["),
            new scancode( 0x0a 	,"9)]"),
            new scancode( 0x0b 	,"0=}"),
            new scancode( 0x0c 	,"ß?\\"),
            new scancode( 0x0d 	,"´`"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"Q"),
            new scancode( 0x11 	,"W"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Z"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"Ü"),
            new scancode( 0x1b 	,"+*~"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"A"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,"Ö"),
            new scancode( 0x28 	,"Ä"),
            new scancode( 0x29 	,"#'"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"<>|"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"Y"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"M"),
            new scancode( 0x33 	,",;"),
            new scancode( 0x34 	,".:"),
            new scancode( 0x35 	,"-_"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };
        #endregion
        #region IT
        public static scancode[] scancodesIT = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1!"),
            new scancode( 0x03 	,"2\""),
            new scancode( 0x04 	,"3£"),
            new scancode( 0x05 	,"4$"),
            new scancode( 0x06 	,"5%"),
            new scancode( 0x07 	,"6&"),
            new scancode( 0x08 	,"7/{"),
            new scancode( 0x09 	,"8(["),
            new scancode( 0x0a 	,"9)]"),
            new scancode( 0x0b 	,"0=}"),
            new scancode( 0x0c 	,"'?"),
            new scancode( 0x0d 	,"¡^"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"Q"),
            new scancode( 0x11 	,"W"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Z"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"èé{["),
            new scancode( 0x1b 	,"+*}]"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"A"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,"òç"),
            new scancode( 0x28 	,"à°"),
            new scancode( 0x29 	,"ù§"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"<>|"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"Y"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"M"),
            new scancode( 0x33 	,",;"),
            new scancode( 0x34 	,".:"),
            new scancode( 0x35 	,"-_"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };
        #endregion
        #region FR

        public static scancode[] scancodesFR = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1&"),
            new scancode( 0x03 	,"2é"),
            new scancode( 0x04 	,"3\""),
            new scancode( 0x05 	,"4'{"),
            new scancode( 0x06 	,"5(["),
            new scancode( 0x07 	,"6-|"),
            new scancode( 0x08 	,"7è`"),
            new scancode( 0x09 	,"8_\\"),
            new scancode( 0x0a 	,"9ç^"),
            new scancode( 0x0b 	,"0à@"),
            new scancode( 0x0c 	,"°)]"),
            new scancode( 0x0d 	,"+=}"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"A"),
            new scancode( 0x11 	,"Z"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Z"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"¨^"),
            new scancode( 0x1b 	,"£$¤"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"Q"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,"M"),
            new scancode( 0x28 	,"%ù"),
            new scancode( 0x29 	,"µ*"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"<>"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"W"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"?,"),
            new scancode( 0x33 	,".;"),
            new scancode( 0x34 	,"/:"),
            new scancode( 0x35 	,"§!"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };
        #endregion
        #region SP
        public static scancode[] scancodesSP = new scancode[]{
            new scancode( 0x00	,"error code"),
            new scancode( 0x01 	,"Esc"),
            new scancode( 0x02 	,"1!|"),
            new scancode( 0x03 	,"2\"@"),
            new scancode( 0x04 	,"3‧#"), 
            new scancode( 0x05 	,"4$~"),
            new scancode( 0x06 	,"5%€"),
            new scancode( 0x07 	,"6&¬"),
            new scancode( 0x08 	,"7/"),
            new scancode( 0x09 	,"8("),
            new scancode( 0x0a 	,"9)"),
            new scancode( 0x0b 	,"0="),
            new scancode( 0x0c 	,"'?"),
            new scancode( 0x0d 	,"¡¿"),
            new scancode( 0x0e 	,"Backspace"),
            new scancode( 0x0f 	,"Tab"),
            new scancode( 0x10 	,"Q"),
            new scancode( 0x11 	,"W"),
            new scancode( 0x12 	,"E"),
            new scancode( 0x13 	,"R"),
            new scancode( 0x14 	,"T"),
            new scancode( 0x15 	,"Y"),
            new scancode( 0x16 	,"U"),
            new scancode( 0x17 	,"I"),
            new scancode( 0x18 	,"O"),
            new scancode( 0x19 	,"P"),
            new scancode( 0x1a 	,"`^["),
            new scancode( 0x1b 	,"+*]"),
            new scancode( 0x1c 	,"Enter"),
            new scancode( 0x1d 	,"LCtrl"),
            new scancode( 0x1e 	,"A"),
            new scancode( 0x1f 	,"S"),
            new scancode( 0x20 	,"D"),
            new scancode( 0x21 	,"F"),
            new scancode( 0x22 	,"G"),
            new scancode( 0x23 	,"H"),
            new scancode( 0x24 	,"J"),
            new scancode( 0x25 	,"K"),
            new scancode( 0x26 	,"L"),
            new scancode( 0x27 	,"Ñ"),
            new scancode( 0x28 	,"´¨{"),
            new scancode( 0x29 	,"Ç}"),
            new scancode( 0x2a 	,"LShift"),
            new scancode( 0x2b 	,"<>"), //  on a 102-key keyboard),
            new scancode( 0x2c 	,"Z"),
            new scancode( 0x2d 	,"X"),
            new scancode( 0x2e 	,"C"),
            new scancode( 0x2f 	,"V"),
            new scancode( 0x30 	,"B"),
            new scancode( 0x31 	,"N"),
            new scancode( 0x32 	,"M"),
            new scancode( 0x33 	,",;"),
            new scancode( 0x34 	,".:"),
            new scancode( 0x35 	,"-_"),
            new scancode( 0x36 	,"RShift"),
            new scancode( 0x37 	,"Keypad-*"), //or ,"*/PrtScn" on a 83/84-key keyboard),
            new scancode( 0x38 	,"LAlt"),
            new scancode( 0x39 	,"Space bar"),
            new scancode( 0x3a 	,"CapsLock"),
            new scancode( 0x3b 	,"F1"),
            new scancode( 0x3c 	,"F2"),
            new scancode( 0x3d 	,"F3"),
            new scancode( 0x3e 	,"F4"),
            new scancode( 0x3f 	,"F5"),
            new scancode( 0x40 	,"F6"),
            new scancode( 0x41 	,"F7"),
            new scancode( 0x42 	,"F8"),
            new scancode( 0x43 	,"F9"),
            new scancode( 0x44 	,"F10"),
            new scancode( 0x45 	,"NumLock"),
            new scancode( 0x46 	,"ScrollLock"),
            new scancode( 0x47 	,"Keypad-7/Home"),
            new scancode( 0x48 	,"Keypad-8/Up"),
            new scancode( 0x49 	,"Keypad-9/PgUp"),
            new scancode( 0x4a 	,"Keypad--"),
            new scancode( 0x4b 	,"Keypad-4/Left"),
            new scancode( 0x4c 	,"Keypad-5"),
            new scancode( 0x4d 	,"Keypad-6/Right"),
            new scancode( 0x4e 	,"Keypad-+"),
            new scancode( 0x4f 	,"Keypad-1/End"),
            new scancode( 0x50 	,"Keypad-2/Down"),
            new scancode( 0x51 	,"Keypad-3/PgDn"),
            new scancode( 0x52 	,"Keypad-0/Ins"),
            new scancode( 0x53 	,"Keypad-./Del"),
            new scancode( 0x54 	,"Alt-SysRq")// on a 84+ key keyboard),
        };
        #endregion
        #endregion
    }
}
