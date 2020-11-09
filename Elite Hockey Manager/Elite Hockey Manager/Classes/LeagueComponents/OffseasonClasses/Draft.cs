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
        public int CurrentPick { get; private set; } = 1;
        public int CurrentRound { get; private set; } = 1;
        public bool DoneDrafting { get; private set; } = false;
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

        public Draft(int year, int teamsCount, Team[] draftOrder)
        {
            Year = year;
            Teams = teamsCount;
            //The amount of draft picks to be made in the draft is the # of teams in the league * the amount of rounds that is specified for the draft
            DraftPicks = new DraftPick[Rounds * Teams];
            BaseDraftPool = PlayerGenerator.GenerateDraftPool(Teams, Rounds);
            //Gives each potential drack pack an initial progress tracker
            InitializePlayerTrackerToDraftClass();
            BaseDraftPool = BaseDraftPool.OrderByDescending(player => player.Overall).ToArray();
            //Switches the base draft pool to a list so that the original draft list can be stored as well as the players being chosen becoming unavailable to be picked
            RemainingDraftPool = BaseDraftPool.ToList();
            TeamDraftOrder = draftOrder;
        }
        public void SimPick()
        {
            if (DoneDrafting)
            {
                return;
            }
            MakePick();
            if (CurrentPick == Rounds * Teams + 1)
            {
                DoneDrafting = true;
            }
        }
        public void SimRound()
        {
            if (DoneDrafting)
            {
                return;
            }
            int nextRoundFirstPick = CurrentRound * Teams + 1;
            while (CurrentPick < nextRoundFirstPick)
            {
                MakePick();
            }
            if (CurrentPick == Rounds * Teams + 1)
            {
                DoneDrafting = true;
            }
        }
        public void SimDraft()
        {
            if (DoneDrafting)
            {
                return;
            }
            int lastPickInDraft = Teams * Rounds;
            while (CurrentPick <= lastPickInDraft)
            {
                MakePick();
            }
            DoneDrafting = true;

        }
        private void InitializePlayerTrackerToDraftClass()
        {
            foreach (Player player in BaseDraftPool)
            {
                //Players rookie year would be year 2 
                player.InitializePlayerProgressionTracker(this.Year + 1);
            }
        }
        private void MakePick()
        {
            //Current pick must be offset by 1 to get into zero index
            Team pickingTeam = TeamDraftOrder[(CurrentPick - 1) % Teams];
            //Picks the highest overall player and removes them from the remaning draft pool list
            Player pickedPlayer = RemainingDraftPool[0];
            RemainingDraftPool.RemoveAt(0);

            //Adds newly picked player to teams roster
            pickingTeam.AddNewPlayer(pickedPlayer);
            //Generates contract for newly drafted player
            ContractGenerator.GenerateContract(pickedPlayer);

            DraftPicks[CurrentPick - 1] = new DraftPick(pickingTeam, pickedPlayer, CurrentRound, CurrentPick);
            CurrentPick++;
            CurrentRound = ((CurrentPick - 1) / Teams) + 1;
        }
        protected Draft(SerializationInfo info, StreamingContext context)
        {
            //this.LeagueName = (string)info.GetValue("LeagueName", typeof(string));
            this.CurrentRound = (int)info.GetValue("CurrentPick", typeof(int));
            this.CurrentRound = (int)info.GetValue("CurrentRound", typeof(int));

            this.DoneDrafting = (bool)info.GetValue("DoneDrafting", typeof(bool));

            this.Year = (int)info.GetValue("Year", typeof(int));
            this.Teams = (int)info.GetValue("Teams", typeof(int));

            this.TeamDraftOrder = (Team[])info.GetValue("TeamDraftOrder", typeof(Team[]));
            this.DraftPicks = (DraftPick[])info.GetValue("DraftPicks", typeof(DraftPick[]));
            this.RemainingDraftPool = (List<Player>)info.GetValue("RemainingDraftPool", typeof(List<Player>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("State", this.State);
            info.AddValue("CurrentPick", this.CurrentPick);
            info.AddValue("CurrentRound", this.CurrentRound);

            info.AddValue("DoneDrafting", this.DoneDrafting);

            info.AddValue("Year", this.Year);
            info.AddValue("Teams", this.Teams);

            info.AddValue("TeamDraftOrder", this.TeamDraftOrder);
            info.AddValue("DraftPicks", this.DraftPicks);
            info.AddValue("RemainingDraftPool", this.RemainingDraftPool);
        }

    }
}
