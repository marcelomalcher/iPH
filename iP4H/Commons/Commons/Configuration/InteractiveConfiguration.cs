using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace iPH.Commons.Configuration
{
    public class InteractiveConfiguration
    {
        #region Members

        public static long DEFAULT_INTERVAL = 180000;
        
        private const long MIN_INTERVAL = 60000;

        public static long REQUEST_TIMEOUT = 5000;

        #region Private

        private bool usesContextInformation;

        private long contextTimerInterval;

        private long mocaWSRequestTimeOut;

        private string mocaWebServiceURL;

        private long sessionTimerInterval;

        private bool searchForActiveSessions;

        private string sessionServiceURL;
      
        private Color myPublicSlideColor;
        
        private Color myPrivateSlideColor;

        #endregion

        #region Public

        #region Constants

        public readonly static Color DEFAULT_PUBLIC_COLOR = Color.Wheat;

        public readonly static Color DEFAULT_PRIVATE_COLOR = Color.WhiteSmoke;

        #endregion

        #endregion

        #endregion

        #region Construtors

        #region Public

        public InteractiveConfiguration()
        {
            this.InitialValues();
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public bool UsesContextInformation
        {
            get
            {
                return this.usesContextInformation;
            }
            set
            {
                this.usesContextInformation = value;
            }
        }

        public long ContextTimerInterval
        {
            get
            {
                return this.contextTimerInterval;
            }
            set
            {
                if (value <= MIN_INTERVAL)
                    this.contextTimerInterval = MIN_INTERVAL;
                else
                    this.contextTimerInterval = value;
            }
        }

        public long MocaWSRequestTimeOut
        {
            get
            {
                return this.mocaWSRequestTimeOut;
            }
            set
            {
                if (value <= 0 )
                    this.mocaWSRequestTimeOut = REQUEST_TIMEOUT;
                else
                    this.mocaWSRequestTimeOut = value;
            }
        }
        
        
        public string MocaWebServiceURL
        {
            get
            {
                return this.mocaWebServiceURL;
            }
            set
            {
                this.mocaWebServiceURL = value;
            }
        }

        public long SessionTimeInterval
        {
            get
            {
                return this.sessionTimerInterval;
            }
            set
            {
                if (value <= MIN_INTERVAL)
                    this.sessionTimerInterval = MIN_INTERVAL;
                else
                    this.sessionTimerInterval = value;
            }
        }

        public bool SearchActiveSessions
        {
            get
            {
                return this.searchForActiveSessions;
            }
            set
            {
                this.searchForActiveSessions = value;
            }
        }

        public string SessionServiceURL
        {
            get
            {
                return this.sessionServiceURL;
            }
            set
            {
                this.sessionServiceURL = value;
            }
        }

        public Color PublicSlideColor
        {
            get
            {
                return this.myPublicSlideColor;
            }
            set
            {
                this.myPublicSlideColor = value;
            }
        }

        public Color PrivateSlideColor
        {
            get
            {
                return this.myPrivateSlideColor;
            }
            set
            {
                this.myPrivateSlideColor = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        public void InitialValues()
        {
            this.UsesContextInformation = false;
            this.ContextTimerInterval = DEFAULT_INTERVAL ;
            this.MocaWSRequestTimeOut = REQUEST_TIMEOUT;
            this.MocaWebServiceURL = "";
            this.SessionTimeInterval = DEFAULT_INTERVAL;
            this.SearchActiveSessions = false;
            this.SessionServiceURL = "";
            this.PublicSlideColor = DEFAULT_PUBLIC_COLOR;
            this.PrivateSlideColor = DEFAULT_PRIVATE_COLOR;
        }

        #endregion

        #endregion
    }
}
