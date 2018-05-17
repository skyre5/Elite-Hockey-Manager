using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public class Team
    {
        private string _teamName;
        private int _teamID;
        private static int idCount = 0;
        private Forward[,] forwards = new Forward[4, 3];
        private Defender[,] defenders = new Defender[3, 2];
        private Goalie[] goalies = new Goalie[2];
        private Skater[] scratched = new Skater[3];
        List<Player> farm = new List<Player>();
        public Team(string teamName)
        {
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
        public int TeamID
        {
            get
            {
                return _teamID;
            }
        }
    }
}
