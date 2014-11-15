using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Functions
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public abstract class BaseFunction: ICSerializable
    {
        #region Members
        private Guid myGuid;
        private string enabledToolTip;
        private string disabeldToolTip;
        #endregion

        #region Ctor
        public BaseFunction()
        {
            this.myGuid = Guid.NewGuid();
        }
        #endregion

        #region Props
        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
        }

        #endregion

        #region Name & Description

        public override string ToString()
        {
            return this.GetName();
        }

        protected virtual string GetName()
        {
            return "Base Function";
        }

        protected virtual string GetDescription()
        {
            return "This is the abstract class of all functions.";
        }

        public virtual bool IsEnabled()
        {
            return false;
        }

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            string cString = (string)parent.Deserialize(stream);
            this.myGuid = new Guid(cString);
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.myGuid.ToString());
        }

        #endregion
    }
}
