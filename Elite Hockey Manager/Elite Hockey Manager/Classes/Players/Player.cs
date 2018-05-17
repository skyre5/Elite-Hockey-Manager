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
        private int _age;
        //Incrementing int that will hold all players that play in the league
        private static int idCount = 0;
        //Set in constructor after incrementing the id count
        private int _playerID;

        List<Stats> careerStats = new List<Stats>();

        public Player(string first, string last, int age)
        {
            //Input validation done in private setters
            FirstName = first;
            LastName = last;
            Age = age;
            //Increments player id
            idCount++;
            _playerID = idCount;
        }

        public string getName()
        {
            return _firstName + " " + _lastName;
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: First name entered must contain a valid value");
                }
                else
                {
                    _firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Error: Last name entered must contain a value");
                }
                else
                {
                    _lastName = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            private set
            {
                if (value < 17 || value > 50)
                {
                    throw new ArgumentException("Error: Age set should be within the range of 17 to 50");
                }
                else
                {
                    _age = value;
                }
            }
        }
        public abstract int GetOverall();
        public void IncrementYear()
        {
            _age++;
        }
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
