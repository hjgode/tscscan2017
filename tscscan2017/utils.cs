using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace tscscan2017
{
    public class utils
    {
        enum MapType
        {
            MAPVK_VK_TO_VSC = 0,
            MAPVK_VSC_TO_VK = 1,
            MAPVK_VK_TO_CHAR = 2,
            MAPVK_VSC_TO_VK_EX = 3
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MapVirtualKey(int uCode, MapType uMapType);

        public static bool IsPrintableChar(System.Windows.Forms.Keys key)
        {
            return !char.IsControl((char)MapVirtualKey((int)key, MapType.MAPVK_VK_TO_CHAR));
        }
        public static int getIntChar(System.Windows.Forms.Keys key)
        {
            return (char)MapVirtualKey((int)key, MapType.MAPVK_VK_TO_CHAR);
        }
    }
}
