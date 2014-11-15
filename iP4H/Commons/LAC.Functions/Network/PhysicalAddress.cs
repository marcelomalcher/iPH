using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; 
using OpenNETCF.Net;

namespace LAC.Functions.Network
{
    public class PhysicalAddress
    {
        /// <summary>
        /// Returns current MacAddress
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            byte[] macAddress;
            string result; 
            try
            {
                AdapterCollection adapters = Networking.GetAdapters();
                if (adapters.Count > 0)
                   macAddress = adapters[0].MacAddress;
                else
                    return "";

                result = string.Format("{0:x2}:{1:x2}:{2:x2}:{3:x2}:{4:x2}:{5:x2}", macAddress[0], macAddress[1], macAddress[2], macAddress[3], macAddress[4], macAddress[5]);
                
                return result.ToUpper();

            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occurred while attempting to retrieve the MAC Address: /n" +
                    e.Message);
                return "";
            }
        }
    }
}
