using System;
using System.Collections.Generic;
using System.Text;
using ContextInformation;

namespace ContextInformation.Wrapper
{
    /// <summary>
    /// This class is a wrapper used to encapsulate the MocaWebService in order to bring information in a simpler way
    /// </summary>
    /// <remarks>Marcelo Malcher</remarks>
    public class ContextWrapper
    {
        #region Members

        private static ContextWrapper mySelf = null; 

        private string wsUrl = "http://139.82.24.238:3636/mocaWS/mocaWS?wsdl"; 

        private MocaWebService.MocaWebService mocaWS;

        #endregion

        #region Ctors 
        
        public ContextWrapper()
        {
        }

        private ContextWrapper(string mocaWebServiceURL)
        {
            this.wsUrl = mocaWebServiceURL;
            this.mocaWS = new MocaWebService.MocaWebService();
            this.mocaWS.Url = this.wsUrl;
        }
       
        #endregion

        #region Singleton

        public static ContextWrapper Instance
        {
            get
            {
                if (mySelf == null)
                    mySelf = new ContextWrapper();
                return mySelf;
            }
        }

        public string Url
        {
            get
            {
                return this.wsUrl;
            }
            set
            {
                this.wsUrl = value;
                this.mocaWS.Url = this.wsUrl;
            }
        }
        #endregion

        #region Context Access Methods 

        public int getEnergyLevel(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.energyLevel;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public long getFreeMemory(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.freeMemory;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public bool isOnLine(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return false;
                else
                    return dvcContext.onLine;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }
        
        public int getCpuUsage(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.cpuUsage;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public long getDeltaT(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.deltaT;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public long getTimeStamp(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.timeStamp;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public bool isIpChange(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return false;
                else
                    return dvcContext.ipChange;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public bool isApChange(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return false;
                else
                    return dvcContext.apChange;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public int getAdvertisementPeriodicity(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return -1;
                else
                    return dvcContext.advertisementPeriodicity;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string getCurrentAPMacAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "";
                else
                    return dvcContext.currentAPMacAddress;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string getMobileHostIPAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "";
                else
                    return dvcContext.mobileHostIPAddress;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string getMobileHostMacAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "";
                else
                    return dvcContext.mobileHostMacAddress;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string getNetworkMask(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "";
                else
                    return dvcContext.networkMask;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }
        
        public string getAreaFromDevice(string MacAddress)
        {
            try
            {
                string area = mocaWS.askLISAreaOfDevice(MacAddress);
                if (area == null)
                    return "";
                else
                    return area;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string[] getAreas(string MacAddress)
        {
            try
            {
                string[] areas = mocaWS.askLISAreas();
                if (areas == null)
                    return null;
                else
                    return areas;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string[] getDevices(string MacAddress)
        {
            try
            {
                string[] devices = mocaWS.askLISDevices();
                if (devices == null)
                    return null;
                else
                    return devices;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        public string[] getDevicesOfArea(string Area)
        {
            try
            {
                string[] devices = mocaWS.askLISDevicesOfArea(Area);
                if (devices == null)
                    return null;
                else
                    return devices;
            }
            catch (Exception e)
            {
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService");
            }
        }

        #endregion
    }
}
