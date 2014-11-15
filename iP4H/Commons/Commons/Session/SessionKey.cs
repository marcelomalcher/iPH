using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace iPH.Commons.Session
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class SessionKey : ICSerializable
    {
        #region Members

        private string key;

        #endregion

        #region Ctors

        public SessionKey()
        {
        }

        public SessionKey(string key)
        {
            this.key = key;
        }

        #endregion

        #region Prop

        public string Key
        {
            get
            {
                return this.key;
            }
        }

        #endregion

        #region Methods

        #region Equals & GetHashCode

        public override int GetHashCode()
        {
            return this.key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            SessionKey objSessionKey = (SessionKey)obj;

            if (!this.key.Equals(objSessionKey.key)) return false;

            return true;
        }


        #endregion

        #region Clear

        public void Clear()
        {
            this.key = "";
        }

        #endregion

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            key = (string)parent.Deserialize(stream);
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, key);
        }

        #endregion
    }
}
