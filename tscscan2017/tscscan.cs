using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace tscscan2017
{
    class tscscan
    {
        public class tscscanlist
        {
            List<tscscan> _tscscanlist = new List<tscscan>();
            public tscscan[] mytscscanlist { get { return _tscscanlist.ToArray(); } }
            public tscscanlist()
            {
                _tscscanlist = new List<tscscan>();
            }
            public int readfile(string filename){
            int iRet = 0;
            int iIndex = 0;
            using (TextReader tr = new StreamReader(filename)){
                string line = tr.ReadLine();
                while (line != null)
                {
                    while(line.StartsWith("//"))
                        line = tr.ReadLine();
                    int iscn=0, ichr=0;
                    string cmnt="";
                    if (line.StartsWith("//"))
                        line = tr.ReadLine();
                    else
                    {
                        string[] parts = line.Split(new char[] { ' ', '\t' });
                        iscn = Convert.ToInt16(parts[0], 16);
                        ichr = Convert.ToInt16(parts[1], 16);
                        if (parts.Length > 2)
                        {
                            if (parts[2].StartsWith("//"))
                            {
                                for(int x=2;x<parts.Length;x++)
                                    cmnt += parts[x];
                            }
                        }
                        if(cmnt!="")
                            _tscscanlist.Add(new tscscan(iIndex,iscn,ichr,cmnt));
                        else
                            _tscscanlist.Add(new tscscan(iIndex,iscn,ichr));
                        iIndex++;
                    }
                    line = tr.ReadLine();
                }
            }
            iRet = --iIndex;
            return iRet;
        }
    }

        int _scancode=0x00;
        public int scancode { get { return _scancode; } set { _scancode = value; } }
        int _unshiftedchar = 0x00;
        public int unshiftedchar { get { return _unshiftedchar; } set { _unshiftedchar = value; } }
        int _index=0;
        public int index { get { return _index; } set { _index = value; } }
        string _comment;
        public string comment { get { return _comment; } set { _comment = value; } }

        public tscscan(int idx, int scn, int chr)
        {
            _index=idx;
            _scancode = scn;
            _unshiftedchar = chr;
            _comment = "";            
        }
        public tscscan(int idx, int scn, int chr, string cmnt)
        {
            _index = idx;
            _scancode = scn;
            _unshiftedchar = chr;
            _comment = cmnt;
        }

    }
}
