﻿using System;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents
{
    [Serializable]
    public class Contract //: ISerializable
    {
        #region Fields

        private double _contractAmount = .5;

        private int _contractDuration = 1;

        private int _yearSigned = 1;

        #endregion Fields

        #region Constructors

        public Contract(int year, int duration, double amount, Team signingTeam)
        {
            this.YearSigned = year;
            this.ContractDuration = duration;
            this.YearsRemaining = duration;
            this.ContractAmount = amount;
            this.SigningTeam = signingTeam;
        }

        public Contract()
        {
        }

        #endregion Constructors

        #region Properties

        public double ContractAmount
        {
            get
            {
                return _contractAmount;
            }
            set
            {
                if (value < .5)
                {
                    throw new ArgumentOutOfRangeException("Contract amount must be between .50 and 10");
                }
                else
                {
                    _contractAmount = value;
                }
            }
        }

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
                    _contractDuration = value;
                }
            }
        }

        public Team SigningTeam { get; private set; } = null;

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

        public int YearsRemaining { get; set; } = 1;

        #endregion Properties

        //protected Contract(SerializationInfo info, StreamingContext context)
        //{
        //    this._yearSigned = (int)info.GetValue("Year", typeof(int));
        //    this._contractDuration = (int)info.GetValue("Duration", typeof(int));
        //    this._contractAmount = (double)info.GetValue("Amount", typeof(double));
        //    //Versioning of contracts prior to contracts having remaining years
        //    try
        //    {
        //        this.YearsRemaining = (int)info.GetValue("YearsRemaining", typeof(int));
        //    }
        //    catch
        //    {
        //        this.YearsRemaining = 1;
        //    }
        //}
        //public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("Year", this._yearSigned);
        //    info.AddValue("Duration", this._contractDuration);
        //    info.AddValue("Amount", this._contractAmount);
        //    info.AddValue("YearsRemaining", this.YearsRemaining);
        //}
    }
}