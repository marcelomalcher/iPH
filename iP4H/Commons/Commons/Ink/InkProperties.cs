using System;
using System.Collections.Generic;
using System.Text;

namespace iPH.Commons.Ink
{
    public class InkProperties
    {
        #region Members

        private static readonly int SIZE_PDA = 1;
        
        private static readonly int SIZE_DESKTOP = 3;
        
        #endregion

        #region Static
        
        public static int GetSizeByPlatform(PlatformID platformId)
        {
            switch (platformId)
            {
                case (PlatformID.WinCE):
                    return SIZE_PDA;                                                         
                default:
                    return SIZE_DESKTOP;
            }
        }

        #endregion
    }
}
