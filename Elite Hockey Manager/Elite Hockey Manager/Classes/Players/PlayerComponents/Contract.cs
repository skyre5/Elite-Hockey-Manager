using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents
{
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
        private int _contractDuration = 1;
        private double _contractAmount = 1;
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
        
        public Contract(int year, int duration, int amount)
        {
            this.YearSigned = year;
            this.ContractDuration = duration;
            this.ContractAmount = amount;
        }
        public Contract()
        {

        }
        public Contract(SerializationInfo info, StreamingContext context)
        {
            this._yearSigned = (int)info.GetValue("Year", typeof(int));
            this._contractDuration = (int)info.GetValue("Duration", typeof(int));
            this._contractAmount = (double)info.GetValue("Amount", typeof(double));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Year", this._yearSigned);
            info.AddValue("Duration", this._contractDuration);
            info.AddValue("Amount", this._contractAmount);
        }
    }
}
