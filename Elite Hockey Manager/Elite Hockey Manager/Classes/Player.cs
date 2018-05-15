using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public abstract class Player
    {
        private string _firstName;
        private string _lastName;

        public Player(string first, string last)
        {
            _firstName = first;
            _lastName = last;
        }

        public string getName()
        {
            return _firstName + " " + _lastName;
        }
        public string FirstName
        {
            get;
        }
        public string LastName
        {
            get;
        }
        public abstract int GetOverall();
        public static bool CheckRating(int rating)
        {
            if (rating < 1 || rating > 100)
            {
                return false;
            } 
            else
            {
                return true;
            }
            
        }
    }
}
