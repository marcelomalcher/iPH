using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace CCXP.Utils.Performance
{
    class PCManager
    {
        // Call this method with True to 
        // turn on the peformance counters, 
        // or with False to turn them off.
        public static void SetPerfCounters(bool perfOn)
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "SOFTWARE\\Microsoft\\.NETCompactFramework\\PerfMonitor";
            string keyName = userRoot + "\\" + subkey;

            int PCset;
            if (perfOn == true)
                PCset = 1;
            else
                PCset = 0;

            // Set the the registry value.
            try
            {
                Registry.SetValue(keyName, "Counters", PCset);
                if (perfOn == true)
                    MessageBox.Show("Performance Counters On");
                else
                    MessageBox.Show("Performance Counters Off");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
