using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    public struct DraftPick
    {
        public readonly Team Team;
        public readonly Player Player;
        public readonly int Round;
        public readonly int Pick;
        public DraftPick(Team draftedTeam, Player draftedPlayer, int round, int pick)
        {
            Team = draftedTeam;
            Player = draftedPlayer;
            Round = round;
            Pick = pick;
        }
    }
    [Serializable]
    public class Draft : ISerializable
    {
        //Static variable, changeable by options in the future
        public static int Rounds = 7;
        //Number of teams that are in the league, determines the length of each round and the total amount of draft picks to be made 
        public readonly int Teams;
        public DraftPick[] DraftPicks;
        //Pool of 18 year old players that are draft eligible, must always be greater than the number of draft picks 
        public Player[] DraftPool;
        public Draft(int year, int teamsCount)
        {
            Teams = teamsCount;
            //The amount of draft picks to be made in the draft is the # of teams in the league * the amount of rounds that is specified for the draft
            DraftPicks = new DraftPick[Rounds * Teams];
            DraftPool = PlayerGenerator.GenerateDraftPool(Teams, Rounds);
        }
        protected Draft(SerializationInfo info, StreamingContext context)
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

    }
}
