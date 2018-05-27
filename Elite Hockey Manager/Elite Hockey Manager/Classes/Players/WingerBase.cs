﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class WingerBase : Forward
    {

        public WingerBase(string first, string last, int age, SkaterAttributes attributes) : base(first, last, age, attributes)
        {

        }
        public WingerBase(string first, string last, int age) : base(first, last, age)
        {
        }

        public WingerBase(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        public override int Overall
        {
            get
            {
                return _attributes.WingerRating();
            }
        }
    }
}
