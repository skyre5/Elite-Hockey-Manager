using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents
{
    [Serializable]
    public class Contract : ISerializable
    {
        public int YearSigned
        {
            get
            {
                return _yearSigned;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Year signed must be at least 1");
                }
                else
                {
                    _yearSigned = value;
                }
            }
        }
        private int _yearSigned = 1;
        private int _yearsRemaining = 1;
        private int _contractDuration = 1;
        private double _contractAmount = 0;
        public int ContractDuration
        {
            get
            {
                return _contractDuration;
            }
            private set
            {
                if (value > 8 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Contract years must be between 0 and 8 years");
                }
                else
                {
                    _contractAmount = value;
                }
            }
        }
        public double ContractAmount
        {
            get
            {
                return _contractAmount;
            }
            set
            {
                if (value > 10 || value < .50)
                {
                    throw new ArgumentOutOfRangeException("Contract amount must be between .50 and 10");
                }
                else
                {
                    _contractAmount = value;
                }
            }
        }
        public int YearsRemaining
        {
            get
            {
                return _yearsRemaining;
            }
        }
        public Contract(int year, int duration, double amount)
        {
            this.YearSigned = year;
            this.ContractDuration = duration;
            this._yearsRemaining = duration;
            this.ContractAmount = amount;
        }
        public Contract()
        {

        }
        protected Contract(SerializationInfo info, StreamingContext context)
        {
            this._yearSigned = (int)info.GetValue("Year", typeof(int));
            this._contractDuration = (int)info.GetValue("Duration", typeof(int));
            this._contractAmount = (double)info.GetValue("Amount", typeof(double));
            //Versioning of contracts prior to contracts having remaining years
            try
            {
                this._yearsRemaining = (int)info.GetValue("YearsRemaining", typeof(int));
            }
            catch
            {
                this._yearsRemaining = 1;
            }
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Year", this._yearSigned);
            info.AddValue("Duration", this._contractDuration);
            info.AddValue("Amount", this._contractAmount);
            info.AddValue("YearsRemaining", this._yearsRemaining);
        }
    }
}
