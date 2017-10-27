using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace tscscan2017
{
    public class tscshift{
        public class tscshiftlist
        {
            List<tscshift> _shiftlist = new List<tscshift>();
            public tscshift[] myShiftlist { get { return _shiftlist.ToArray(); } }

            public tscshiftlist()
            {
                _shiftlist = new List<tscshift>();
            }

            public int readfile(string filename)
            {
                int iRet = 0;
                int iIndex = 0;
                using (TextReader tr = new StreamReader(filename))
                {
                    string line = tr.ReadLine();
                    while (line != null)
                    {
                        while (line.StartsWith("//") || line.Trim().Length == 0)
                            line = tr.ReadLine();
                        int iCharIn = 0, iCharOut = 0;
                        int iShifted = 0;
                        if (line.StartsWith("//") || line.Trim().Length == 0)
                            line = tr.ReadLine();
                        else
                        {
                            string[] parts = line.Split(new char[] { ' ', '\t' });
                            iCharIn = Convert.ToInt16(parts[0], 16);
                            iCharOut = Convert.ToInt16(parts[1], 16);
                            iShifted = Convert.ToInt16(parts[2]);
                            _shiftlist.Add(new tscshift(iCharIn, iCharOut, iShifted));
                            iIndex++;
                        }
                        line = tr.ReadLine();
                    }
                }
                iRet = --iIndex;
                return iRet;
            }
        }
        /*
        0x61 0x41 0     lower case a, a lower case a (0x61) will be lokked up as 0x41 (A) without shift flag set
        0x41 0x41 1     upper case A, a upper case a (0x41) will be lokked up as 0x41 with shift flag set
        */
        int _charcodeIn;
        public int charcodeIn { get { return _charcodeIn; } set { _charcodeIn = value; } }
        int _charcodeOut;
        public int charcodeOut { get { return _charcodeOut; } set { _charcodeOut = value; } }
        int _shifted;
        public int shifted { get { return _shifted; } set { _shifted = value; } }

        public tscshift(int charcodeIn, int charcodeOut, int shifted)
        {
            _charcodeIn = charcodeIn;
            _charcodeOut = charcodeOut;
            _shifted = shifted;
        }
    }
}
