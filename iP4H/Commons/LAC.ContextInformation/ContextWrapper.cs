using System;
using System.Collections.Generic;
using System.Text;
using ContextInformation;

namespace ContextInformation
{
    /// <summary>
    /// This class is a wrapper used to encapsulate the MocaWebService in order to bring information in a simpler way
    /// </summary>
    /// <remarks>Marcelo Malcher</remarks>
    public class ContextWrapper
    {
        #region Members

        private string wsUrl = "http://139.82.24.238:3636/mocaWS/mocaWS?wsdl"; 

        private MocaWebService.MocaWebService mocaWS;

        #endregion

        #region Ctors 
        
        public ContextWrapper()
        {
            this.mocaWS = new MocaWebService.MocaWebService();
            this.mocaWS.Url = this.wsUrl;
        }

        public ContextWrapper(string mocaWebServiceURL)
            : this()
        {
            try
            {
                this.wsUrl = mocaWebServiceURL;
                this.mocaWS.Url = this.wsUrl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }
       
        #endregion

        #region Ping Web Service

        public bool isConnected()
        {
            try
            {
                return mocaWS.isConnected();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }        
        }

        #endregion

        #region Context Access Methods

        public DeviceContext GetDeviceContext(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return null;
                DeviceContext deviceContext = new DeviceContext(dvcContext);
                return deviceContext;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public int GetEnergyLevel(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public long GetFreeMemory(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public bool IsOnLine(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }
        
        public int GetCpuUsage(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public long GetDeltaT(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public long GetTimeStamp(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public bool IsIpChange(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public bool IsApChange(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public int GetAdvertisementPeriodicity(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string GetCurrentAPMacAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "N/A";
                else
                    return dvcContext.currentAPMacAddress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string GetMobileHostIPAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "N/A";
                else
                    return dvcContext.mobileHostIPAddress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string GetMobileHostMacAddress(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "N/A";
                else
                    return dvcContext.mobileHostMacAddress;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string GetNetworkMask(string MacAddress)
        {
            try
            {
                MocaWebService.deviceContextWS dvcContext = mocaWS.askCIS(MacAddress);
                if (dvcContext == null)
                    return "N/A";
                else
                    return dvcContext.networkMask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }
        
        public string GetAreaFromDevice(string MacAddress)
        {
            try
            {
                string area = mocaWS.askLISAreaOfDevice(MacAddress);
                if (area == null)
                    return "N/A";
                else
                    return area;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string[] GetAreas(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string[] GetDevices(string MacAddress)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        public string[] GetDevicesOfArea(string Area)
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
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the MocaWebService: \n" + e.Message);
            }
        }

        #endregion
    }
}
