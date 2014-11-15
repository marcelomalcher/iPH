using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;
using LAC.Functions.Network;
using iPH.Commons.User.Role;

namespace iPH.Commons.User
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Participant: ICSerializable
    {
        #region Members

        #region Private

        private string macAddress;
        private string nickName;
        private BaseRole role;

        #endregion

        #endregion

        #region Constructors

        #region Public

        public Participant()
        {
            this.InitialValues();
        }

        #endregion

        #endregion

        #region Properties

        #region Public

        public string MacAddress
        {
            get
            {
                return this.macAddress;
            }
            set
            {
                this.macAddress = value;
            }
        }

        public string NickName
        {
            get
            {
                return this.nickName;
            }
            set
            {
                this.nickName = value;
            }
        }

        public BaseRole Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        public void InitialValues()
        {
            this.macAddress = PhysicalAddress.GetMacAddress();
            this.nickName = "";
            this.role = Offline.Instance;
        }

        #region Overrides Equals & GetHashcode

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            Participant objParticipant = (Participant)obj;

            if (!this.macAddress.Equals(objParticipant.macAddress)) return false;

            if (!this.nickName.Equals(objParticipant.nickName)) return false;

            if (!this.role.Equals(objParticipant.role)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.macAddress.GetHashCode();
        }

        #endregion

        #region ICSerializable Methods

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            macAddress = (string)parent.Deserialize(stream);
            nickName = (string)parent.Deserialize(stream);
            role = (BaseRole)parent.Deserialize(stream);
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, macAddress);
            parent.Serialize(stream, nickName);
            parent.Serialize(stream, role);
        }

        #endregion

        #endregion
    }

}
