using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Presentation;

namespace iPH.Commons.Parameters
{
    public class PresentationParameters
    {
        #region Members

        #region Private

        private bool allowSubmissions;
        
        private bool syncViewer;
        
        private bool syncMaster;
        
        private bool automaticContributions;
        
        private bool makeContributions;
        
        private Guid slideViewGuid;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public PresentationParameters()
        {
            this.InitialValues();
        }

        #endregion

        #endregion

        #region Properties

        #region Public 

        public bool AllowSubmissions
        {
            get
            {
                return this.allowSubmissions;
            }
            set
            {
                this.allowSubmissions = value;
            }
        }

        public bool SyncViewer
        {
            get
            {
                return this.syncViewer;
            }
            set
            {
                this.syncViewer = value;
            }
        }

        public bool SyncMaster
        {
            get
            {
                return this.syncMaster;
            }
            set
            {
                this.syncMaster = value;
            }
        }

        public bool AutomaticContributions
        {
            get
            {
                return this.automaticContributions;
            }
            set
            {
                this.automaticContributions = value;
            }
        }

        public bool MakeContributions
        {
            get
            {
                return this.makeContributions;
            }
            set
            {
                this.makeContributions = value;
            }
        }

        public Guid SlideViewGuid
        {
            get
            {
                return this.slideViewGuid;
            }
            set
            {
                this.slideViewGuid = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region Public

        public void InitialValues()
        {
            this.AllowSubmissions = true;
            this.SyncViewer = true;
            this.SyncMaster = true;
            this.AutomaticContributions = true;
            this.MakeContributions = true;
            this.SlideViewGuid = Guid.Empty;
        }

        #endregion

        #endregion
    }
}
