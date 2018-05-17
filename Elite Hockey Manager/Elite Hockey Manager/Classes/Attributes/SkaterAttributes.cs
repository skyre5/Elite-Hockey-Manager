using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class SkaterAttributes : Attributes
    {
        private int _wristShot = 50;
        private int _slapShot = 50;
        private int _deking = 50;
        private int _faceoff = 50;

        private int _speed = 50;
        private int _defense = 50;
        private int _checking = 50;

        public int WristShot
        {
            get
            {
                return _wristShot;
            }
            set
            {
                CheckRating(ref _wristShot, value);
            }
        }
        public int SlapShot
        {
            get
            {
                return _slapShot;
            }
            set
            {
                CheckRating(ref _slapShot, value);
            }
        }
        public int Deking
        {
            get
            {
                return _deking;
            }
            set
            {
                CheckRating(ref _deking, value);
            }
        }
        public int Faceoff
        {
            get
            {
                return _faceoff;
            }
            set
            {
                CheckRating(ref _faceoff, value);
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                CheckRating(ref _speed, value);
            }
        }
        public int Defense
        {
            get
            {
                return _defense;
            }
            set
            {
                CheckRating(ref _defense, value);
            }
        }
        public int Checking
        {
            get
            {
                return _checking;
            }
            set
            {
                CheckRating(ref _checking, value);
            }
        }

    }
}
