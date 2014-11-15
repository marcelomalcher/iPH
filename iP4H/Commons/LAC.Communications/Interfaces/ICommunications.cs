using System;
using System.Collections.Generic;
using System.Text;

namespace LAC.Communications.Interfaces
{
    public interface ICommunications
    {
        #region Receive
        
        void ReceiveObject(Object obj);

        #endregion
    }
}
