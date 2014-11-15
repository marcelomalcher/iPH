using System;
using System.Collections.Generic;
using System.Text;
using CompactFormatter.Attributes;
using CompactFormatter.Interfaces;

using LAC.ContextInformation;

namespace iPH.Commons.Context
{
    [CompactFormatter.Attributes.Serializable(Custom = true)]
    public class ContextRule : ICSerializable
    {        

        private int contextField;
        /*
         * 0 - Cpu Usage
         * 1 - Energy Level
         * 2 - Free Memory
         * 3 - Area
         * */
        private int contextOperator; 
        /*
         * 0 - Equal
         * 1 - Different
         * 2 - Greater
         * 3 - Greater or Equal
         * 4 - Lower
         * 5 - Lower or Equal
         * */
        private string contextValue;

        public ContextRule()
        {
        }

        public ContextRule(int field, int oper, string value)
        {
            this.contextField = field;
            this.contextOperator = oper;
            this.contextValue = value;
        }


        public int Field
        {
            get
            {
                return this.contextField;
            }
        }

        public int Operator
        {
            get
            {
                return this.contextOperator;
            }
        }

        public String Value
        {
            get
            {
                return this.contextValue;
            }
        }

        public override string ToString()
        {
            //
            String field = "?";
            if (contextField == 0)
                field = "CpuUsage";
            else if (contextField == 1)
                field = "EnergyLevel";
            else if (contextField == 2)
                field = "FreeMemory";
            else if (contextField == 3)
                field = "Area";

            //
            String op = "?";
            //
            if (contextOperator == 0) //Equal
                op = "=";
            else if (contextOperator == 1) //Different
                op = "<>";
            else if (contextOperator == 2) // Greater
                op = ">";
            else if (contextOperator == 3)
                op = ">=";
            else if (contextOperator == 4) // Lower
                op = "<";
            else if (contextOperator == 5)
                op = "<=";

            return field + op + this.contextValue;
        }

        #region ICSerializable Members

        public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            int cField = (int)parent.Deserialize(stream);
            int cOperator = (int)parent.Deserialize(stream);
            string cValue = (string)parent.Deserialize(stream);
            this.contextField = cField;
            this.contextOperator = cOperator;
            this.contextValue = cValue;
        }

        public void SendObjectData(CompactFormatter.CompactFormatter parent, System.IO.Stream stream)
        {
            parent.Serialize(stream, this.contextField);
            parent.Serialize(stream, this.contextOperator);
            parent.Serialize(stream, this.contextValue);
        }

        #endregion

        public bool Evaluate(DeviceContext deviceContext, String area)
        {
            if (deviceContext == null || area == null)
            {
                return false;
            }
            //
            switch (Field)
            {
                case 0:
                    return EvaluateLong(deviceContext.CpuUsage);                    
                case 1:
                    return EvaluateLong(deviceContext.EnergyLevel);
                case 2:
                    return EvaluateLong(deviceContext.FreeMemory);
                case 3:
                    return EvaluateArea(area);
                default:
                    return false;
            }
        }

        private bool EvaluateLong(Int64 theValue)
        {
            long lValue;
            try 
            {
                lValue = Int64.Parse(this.Value);
            } catch (Exception ex)
            {
                return false ;
            }
            //
            switch (Operator)
            {
                case 0:
                    return (theValue == lValue);
                case 1:
                    return (theValue != lValue);
                case 2:
                    return (theValue > lValue);
                case 3:
                    return (theValue >= lValue);
                case 4:
                    return (theValue < lValue);
                case 5:
                    return (theValue <= lValue);
                default:
                    return false;
            }
        }

        private bool EvaluateArea(String area)
        {
            //
            switch (Operator)
            {
                case 0:
                    return (this.Value.Equals(area));
                case 1:
                    return (!(this.Value.Equals(area)));
                default:
                    return false;
            }
        }
    }
}
