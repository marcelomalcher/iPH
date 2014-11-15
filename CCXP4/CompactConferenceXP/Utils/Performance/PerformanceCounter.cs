using System;
using System.Collections.Generic;
using System.Text;

namespace CCXP.Utils.Performance
{
    /// <summary>
    /// This class was developed to supply the PerformanceCounter class that exists at .NET Framework
    /// and does not exists at .NET Compact Framework. Doing this, I won't need to remove all references
    /// to PerfomWrapper in the ConferenceAPI Solution. 
    /// </summary>

    public class PerformanceCounter
    {
        #region Attributes

        private string categoryName;
        private string counterName;
        private string instanceName;
        private bool readOnly = false;
        private long rawValue = 0;

        #endregion

        #region Constructor

        public PerformanceCounter(string categoryName, string counterName, string instanceName, bool readOnly)
        {
            this.categoryName = categoryName;
            this.counterName = counterName;
            this.instanceName = instanceName;
            this.readOnly = readOnly;
        }

        #endregion

        #region Properties

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        public string CounterName
        {
            get
            {
                return counterName;
            }
            set
            {
                counterName = value;
            }
        }

        public string InstanceName
        {
            get
            {
                return instanceName;
            }
            set
            {
                instanceName = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
            }
        }

        public long RawValue
        {
            get
            {
                return rawValue;
            }
            set
            {
                rawValue = value;
            }
        }

        #endregion

        #region Methods

        public void RemoveInstance()
        {
            instanceName = null;
        }

        #endregion

    }
}
