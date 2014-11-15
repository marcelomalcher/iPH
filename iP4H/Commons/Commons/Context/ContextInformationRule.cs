using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

using iPH.Commons.Functions;

using LAC.ContextInformation;

namespace iPH.Commons.Context
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContextInformationRule : ICSerializable
    {
        #region Members

        private Guid myGuid;
        private long myTimestamp;        
        private List<ContextRule> myRules;
        private BaseFunction myFunction;

        #endregion

        #region Ctor

        public ContextInformationRule()
        {
            this.myGuid = System.Guid.NewGuid();
            this.myTimestamp = DateTime.Now.Ticks;
            this.myRules = new List<ContextRule>();
        }

        public ContextInformationRule(List<ContextRule> theRules, BaseFunction theFunction)
            :this()
        {
            this.myRules = theRules;
            this.myFunction = theFunction;
        }

        #endregion

        #region Properties

        public Guid Guid
        {
            get
            {
                return this.myGuid;
            }
        }

        public long Timestamp
        {
            get
            {
                return this.myTimestamp;
            }
            set
            {
                this.myTimestamp = value;
            }
        }

        public List<ContextRule> Rules
        {
            get
            {
                return this.myRules;
            }
            set
            {
                this.myRules = value;
            }
        }

        public BaseFunction Function
        {
            get
            {
                return this.myFunction;
            }
            set
            {
                this.myFunction = value;
            }
        }

        #endregion

        #region Methods

        public override string  ToString()
        {
            String rules = "";
            foreach (ContextRule cr in Rules)
            {
                rules += cr.ToString() + " and ";
            }
            rules = rules.Substring(0, rules.Length - 5); //retirando o and
            return rules + " | " + this.Function.ToString();
        }

        #endregion

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            //Guid
            string cGuid = (string)parent.Deserialize(stream);
            //Timestamp
            long cTimestamp = (long)parent.Deserialize(stream);
            //Rule
            int nrules = (int)parent.Deserialize(stream);
            for (int i = 0; i < nrules; i++)
            {
                ContextRule rule = (ContextRule)parent.Deserialize(stream);
                this.myRules.Add(rule);
            }
            //string cRule = (string)parent.Deserialize(stream);
            //BaseFunction
            BaseFunction cFunction = (BaseFunction)parent.Deserialize(stream);

            this.myGuid = new Guid(cGuid);
            this.myTimestamp = cTimestamp;
            //this.myRule = cRule;
            this.myFunction = cFunction;
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            //Guid
            parent.Serialize(stream, this.myGuid.ToString());
            //Timestamp
            parent.Serialize(stream, this.myTimestamp);
            //Rule            
            //parent.Serialize(stream, this.myRule);
            parent.Serialize(stream, this.myRules.Count);
            foreach (ContextRule rule in this.myRules) 
            {
                parent.Serialize(stream, rule);
            }
            //Function
            parent.Serialize(stream, this.myFunction);            
        }

        #endregion

        public bool Evaluate(DeviceContext deviceContext, String area)
        {
            foreach (ContextRule cr in this.myRules)
            {
                if (!cr.Evaluate(deviceContext, area))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
