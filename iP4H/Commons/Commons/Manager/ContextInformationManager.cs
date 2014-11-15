using System;
using System.Collections.Generic;
using System.Text;

using iPH.Commons.Context;

namespace iPH.Commons.Manager
{
    public class ContextInformationManager
    {
        #region Members
        private List<ContextInformationRule> myList;
        #endregion

        #region Ctor

        public ContextInformationManager()
        {
            this.myList = new List<ContextInformationRule>();           
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

        public List<ContextInformationRule> List
        {
            get
            {
                return this.myList;
            }
        }

        public ContextInformationRule this[int index]
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

        public void Add(ContextInformationRule contextInformationRule)
        {
            ContextInformationRule cRule = this.GetContextInformationRule(contextInformationRule);
            if (cRule != null)
            {
                if (!cRule.Timestamp.Equals(contextInformationRule.Timestamp))
                {
                    this.Remove(cRule);
                }
                return;
            }
            this.myList.Add(contextInformationRule);
        }

        public void Remove(ContextInformationRule contextInformationRule)
        {
            this.myList.Remove(contextInformationRule);
        }

        public void AppendRules(ContextInformationRule[] theRules)
        {
            lock (this.myList)
            {
                this.myList.Clear();
                //
                foreach (ContextInformationRule c in theRules)
                {
                    this.Add(c);
                }
            }
        }

        private ContextInformationRule GetContextInformationRule(ContextInformationRule contextInformationRule)
        {
            foreach (ContextInformationRule c in this.myList)
            {
                if (c.Guid.Equals(contextInformationRule.Guid))
                {
                    return c;
                }
            }
            return null;
        }

        #endregion
    }
}
