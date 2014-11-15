using System;
using System.Collections.Generic;
using System.Text;

namespace iPH.Commons.Session
{
    public class SessionInfo
    {
        #region Members

        #region Private

        private bool connected = false;
        
        private SessionKey key;
        
        private string multicastIp;
        
        private ushort port;      
        
        private ushort ttl = 3;

        private ushort fecPerc = 100;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public SessionInfo()
        {
            this.InitialValues();
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public bool Connected
        {
            get
            {
                return this.connected;
            }
            set
            {
                this.connected = value;
            }
        }

        public SessionKey Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        public string MulticastIp
        {
            get
            {
                return this.multicastIp;
            }
            set
            {
                this.multicastIp = value;
            }
        }

        public ushort Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        public ushort TTL
        {
            get
            {
                return this.ttl;
            }
            set
            {
                this.ttl = value;
            }
        }

        public ushort FECPerc
        {
            get
            {
                return this.fecPerc;
            }
            set
            {
                this.fecPerc = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        public void InitialValues()
        {
            this.Connected = false;
            this.MulticastIp = "";
            this.Port = 0;
            this.TTL = 3;
            this.Key = null;
            this.FECPerc = 100;
        }

        #endregion

        #endregion

    }
}
