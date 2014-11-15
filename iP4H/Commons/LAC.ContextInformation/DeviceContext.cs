using System;
using System.Collections.Generic;
using System.Text;

namespace ContextInformation
{
    public class DeviceContext
    {
        #region Members

        private int advertisementPeriodicityField;

        private bool apChangeField;

        private int cpuUsageField;

        private string currentAPMacAddressField;

        private long deltaTField;

        private int energyLevelField;

        private long freeMemoryField;

        private bool ipChangeField;

        private string mobileHostIPAddressField;

        private string mobileHostMacAddressField;

        private string networkMaskField;

        private bool onLineField;

        private long timeStampField;

        private int wlanConnectivityLevelField;

        #endregion

        #region Ctors

        public DeviceContext(MocaWebService.deviceContextWS dvcContext)
        {
            this.LoadDeviceContext(dvcContext);
        }

        #endregion

        #region Properties

        public int advertisementPeriodicity
        {
            get
            {
                return this.advertisementPeriodicityField;
            }
        }

        public bool ApChange
        {
            get
            {
                return this.apChangeField;
            }
        }

        public int CpuUsage
        {
            get
            {
                return this.cpuUsageField;
            }
        }

        public string CurrentAPMacAddress
        {
            get
            {
                return this.currentAPMacAddressField;
            }
        }

        public long DeltaT
        {
            get
            {
                return this.deltaTField;
            }
        }

        public int EnergyLevel
        {
            get
            {
                return this.energyLevelField;
            }
        }

        public long FreeMemory
        {
            get
            {
                return this.freeMemoryField;
            }
        }

        public bool IpChange
        {
            get
            {
                return this.ipChangeField;
            }
        }

        public string MobileHostIPAddress
        {
            get
            {
                return this.mobileHostIPAddressField;
            }
        }

        public string MobileHostMacAddress
        {
            get
            {
                return this.mobileHostMacAddressField;
            }
        }

        public string NetworkMask
        {
            get
            {
                return this.networkMaskField;
            }
        }
        
        public bool OnLine
        {
            get
            {
                return this.onLineField;
            }
        }

        public long TimeStamp
        {
            get
            {
                return this.timeStampField;
            }
        }

        public int WlanConnectivityLevel
        {
            get
            {
                return this.wlanConnectivityLevelField;
            }
        }

        #endregion

        #region Methods

        private void LoadDeviceContext(MocaWebService.deviceContextWS dvcContext)
        {
            this.advertisementPeriodicityField = dvcContext.advertisementPeriodicity;
            this.apChangeField = dvcContext.apChange;
            this.cpuUsageField = dvcContext.cpuUsage;
            this.currentAPMacAddressField = dvcContext.currentAPMacAddress;
            this.deltaTField = dvcContext.deltaT;
            this.energyLevelField = dvcContext.energyLevel;
            this.freeMemoryField = dvcContext.freeMemory;
            this.ipChangeField = dvcContext.ipChange;
            this.mobileHostIPAddressField = dvcContext.mobileHostIPAddress;
            this.mobileHostMacAddressField = dvcContext.mobileHostMacAddress;
            this.networkMaskField = dvcContext.networkMask;
            this.onLineField = dvcContext.onLine;
            this.timeStampField = dvcContext.timeStamp;
            this.wlanConnectivityLevelField = dvcContext.wlanConnectivityLevel;
        }

        #endregion
    }
}

