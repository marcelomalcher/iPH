using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.User;

namespace iPH.Commons.Manager
{
    public class ParticipantsManager
    {
        #region Members
        private List<Participant> myList;
        #endregion

        #region Ctor

        public ParticipantsManager()
        {
            this.myList = new List<Participant>();           
        }

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return this.myList.Count;
            }
        }

        public List<Participant> List
        {
            get
            {
                return this.myList;
            }
        }

        public Participant this[int index]
        {
            get
            {
                return this.myList[index];
            }
        }

        #endregion

        #region Methods

        public void Clear()
        {
            this.myList.Clear();
        }

        public void Add(Participant participant)
        {
            if (this.GetParticipant(participant) == null)
            {
                this.myList.Add(participant);
            }
        }

        public void Remove(Participant participant)
        {
            this.myList.Remove(participant);
        }

        private Participant GetParticipant(Participant participant)
        {
            foreach(Participant p in this.myList)
            {
                if (p.MacAddress.Equals(participant.MacAddress))
                {
                    return p;
                }
            }
            return null;
        }

        #endregion
    }
}
