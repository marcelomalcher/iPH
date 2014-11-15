using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LAC.Contribution.Arguments;
using LAC.Contribution.Objects;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

namespace LAC.Contribution
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class Contributions : ICSerializable, ICloneable
    {
        #region Members
        
        private List<ContributionBaseObject> myContributions;
        
        #endregion
        
        #region Constructors

        public Contributions()
        {
            this.myContributions = new List<ContributionBaseObject>();
        }

        #endregion

        #region Properties

        public int Count
        {
            get
            {
                return this.myContributions.Count;
            }
        }

        public List<ContributionBaseObject> List
        {
            get
            {
                return this.myContributions;
            }
        }
        
        public ContributionBaseObject this[int index]
        {
            get
            {
                if (index >= this.myContributions.Count)
                    return null;
                return (ContributionBaseObject)this.myContributions[index];
            }
        }

        #endregion

        #region NewGuid

        public void NewGuid()
        {
            foreach (ContributionBaseObject cbo in this.myContributions)
            {
                cbo.NewGuid();
            }
        }

        #endregion

        #region Methods

        #region Persistence

        public void InsertContribution(ContributionBaseObject contributionAdd, bool fireEvent)
        {
            if (this.GetContribution(contributionAdd) != null)
                return;
            this.myContributions.Add(contributionAdd);

            if (fireEvent)
            {
                NewContributionArgs e = new NewContributionArgs(contributionAdd);
                OnNewContributionEvent(e);
            }
        }

        public ContributionBaseObject RemoveContribution(Guid contributionGuid, bool fireEvent)
        {
            ContributionBaseObject c = this.GetContribution(contributionGuid);
            if (c != null)
            {
                this.myContributions.Remove(c);
                if (fireEvent)
                {
                    ContributionRemovedArgs e = new ContributionRemovedArgs(c);
                    OnContributionRemovedEvent(e);
                }
                return c;
            }
            return null;
        }

        public ContributionBaseObject RemoveContribution(ContributionBaseObject contributionRemove, bool fireEvent)
        {
            return this.RemoveContribution(contributionRemove.Guid, fireEvent);
        }

        public void Clear()
        {
            ContributionBaseObject[] allContributions = (ContributionBaseObject[])this.myContributions.ToArray();
            this.myContributions.Clear();

            ContributionRemovedArgs e = new ContributionRemovedArgs(allContributions);
            OnContributionRemovedEvent(e);
        }
       
        #endregion

        #region Navigation

        public ContributionBaseObject GetContribution(ContributionBaseObject contributionFind)
        {
            return this.GetContribution(contributionFind.Guid);
        }

        public ContributionBaseObject GetContribution(Guid contributionGuid)
        {
            foreach (ContributionBaseObject c in this.myContributions)
            {
                if (c.Guid.Equals(contributionGuid))
                {
                    return c;
                }
            }
            return null;
        }

        public int IndexOf(ContributionBaseObject contribution)
        {
            return this.myContributions.IndexOf(contribution);
        }
        
        #endregion
           
        #endregion

        #region Scale

        public void ScaleObject(int newWidth, int newHeight)
        {
            foreach (ContributionBaseObject cbObj in this.myContributions)
            {
                cbObj.ScaleObject(newWidth, newHeight);
            }
        }

        #endregion

        #region Draw

        public void Draw(Graphics g)
        {
            if (this.myContributions.Count <= 0)
                return;
            foreach (ContributionBaseObject cbObj in this.myContributions)
            {
                cbObj.Draw(g);
            }
        }

        #endregion

        #region Intersect

        public ContributionBaseObject IntersectObject(Type contributionObjectType, Point point, double radius)
        {
            foreach (ContributionBaseObject cbObj in this.myContributions)
            {
                if (cbObj.GetType().Equals(contributionObjectType))
                {
                    if (cbObj.IntersectObject(point, radius))
                        return cbObj;
                }
            }
            return null;
        }

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            int contributionCount = (int)parent.Deserialize(stream);
            for (int i = 0; i < contributionCount; i++)
            {
                ContributionBaseObject c = (ContributionBaseObject)parent.Deserialize(stream);
                this.myContributions.Add(c);
            }
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.Count);
            foreach (ContributionBaseObject c in this.myContributions)
            {
                parent.Serialize(stream, c);
            }
        }

        #endregion

        #region Delegate Events

        public delegate void NewContributionEventHandler(object sender, NewContributionArgs e);
        public event NewContributionEventHandler NewContributionEvent;
        protected virtual void OnNewContributionEvent(NewContributionArgs e)
        {
            if (NewContributionEvent != null)
            {
                NewContributionEvent(this, e);
            }
        }

        public delegate void ContributionRemovedEventHandler(object sender, ContributionRemovedArgs e);
        public event ContributionRemovedEventHandler ContributionRemovedEvent;
        protected virtual void OnContributionRemovedEvent(ContributionRemovedArgs e)
        {
            if (ContributionRemovedEvent != null)
            {
                ContributionRemovedEvent(this, e);
            }
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            Contributions newInstance = new Contributions();
            foreach (ContributionBaseObject cbo in this.myContributions)
            {
                ContributionBaseObject cContributionBaseObject = (ContributionBaseObject)cbo.Clone();
                newInstance.InsertContribution(cContributionBaseObject, false);
            }
            return newInstance;            
        }

        #endregion
    }

}
