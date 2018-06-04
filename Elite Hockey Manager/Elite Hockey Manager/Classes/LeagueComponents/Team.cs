using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Team
    {
        private string _location;
        private string _teamName;
        private int _teamID;
        private static int idCount = 0;
        private List<Player> roster = new List<Player>();
        private List<Player> farm = new List<Player>();

        private Forward[,] forwards = new Forward[4, 3];
        private Defender[,] defenders = new Defender[3, 2];
        private Goalie[] goalies = new Goalie[2];
        private Skater[] scratched = new Skater[3];
        public Team(string city, string teamName)
        {
            _location = city;
            _teamName = teamName;
            idCount++;
            _teamID = idCount;
        }
        public string TeamName
        {
            get
            {
                return _teamName;
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
        }
        public string FullName
        {
            get
            {
                return _location + _teamName;
            }
        }
        public int TeamID
        {
            get
            {
                return _teamID;
            }
        }
    }
}
