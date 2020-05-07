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
        public int CurrentPick
        {
            get
            {
                return _currentPick;
            }
        }
        public int CurrentRound
        {
            get
            {
                return _currentRound;
            }
        }
        //Static variable, changeable by options in the future
        public static int Rounds = 7;
        public readonly int Year;
        //Number of teams that are in the league, determines the length of each round and the total amount of draft picks to be made 
        public readonly int Teams;
        //Order the teams draft in, from worst in the league to best, each round
        public readonly Team[] TeamDraftOrder;
        public readonly DraftPick[] DraftPicks;
        //Pool of 18 year old players that are draft eligible, must always be greater than the number of draft picks 
        public readonly Player[] BaseDraftPool;
        //Draft pool after picks are made, will finished with only the players that will go undrafted
        //Will have players removed constantly, so is switched to list
        public readonly List<Player> RemainingDraftPool;
        private int _currentPick = 1;
        private int _currentRound = 1;
        private bool _doneDrafting = false;
        public Draft(int year, int teamsCount, Team[] draftOrder)
        {
            Year = year;
            Teams = teamsCount;
            //The amount of draft picks to be made in the draft is the # of teams in the league * the amount of rounds that is specified for the draft
            DraftPicks = new DraftPick[Rounds * Teams];
            BaseDraftPool = PlayerGenerator.GenerateDraftPool(Teams, Rounds);
            BaseDraftPool = BaseDraftPool.OrderByDescending(player => player.Overall).ToArray();
            //Switches the base draft pool to a list so that the original draft list can be stored as well as the players being chosen becoming unavailable to be picked
            RemainingDraftPool = BaseDraftPool.ToList();
            TeamDraftOrder = draftOrder;
        }
        public void SimPick()
        {
            if (_doneDrafting)
            {
                return;
            }
            MakePick();
            if (_currentPick == Rounds * Teams + 1)
            {
                _doneDrafting = true;
            }
        }
        public void SimRound()
        {
            if (_doneDrafting)
            {
                return;
            }
            int nextRoundFirstPick = _currentRound * Teams + 1;
            while (_currentPick < nextRoundFirstPick)
            {
                MakePick();
            }
        }
        public void SimDraft()
        {
            if (_doneDrafting)
            {
                return;
            }
            int lastPickInDraft = Teams * Rounds;
            while (_currentPick <= lastPickInDraft)
            {
                MakePick();
            }
            _doneDrafting = true;

        }
        private void MakePick()
        {
            //Current pick must be offset by 1 to get into zero index
            Team pickingTeam = TeamDraftOrder[(_currentPick - 1) % Teams];
            //Picks the highest overall player and removes them from the remaning draft pool list
            Player pickedPlayer = RemainingDraftPool[0];
            RemainingDraftPool.RemoveAt(0);

            DraftPicks[_currentPick - 1] = new DraftPick(pickingTeam, pickedPlayer, _currentRound, _currentPick);
            _currentPick++;
            _currentRound = ((_currentPick - 1) / Teams) + 1;
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
