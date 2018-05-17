using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public class Team
    {
        private string _teamName;
        private Forward[,] forwards = new Forward[4, 3];
        private Defender[,] defenders = new Defender[3, 2];
        private Goalie[] goalies = new Goalie[2];
        private Skater[] scratched = new Skater[3];
    }
}
