namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The draft pick structure holding all the information for a single pick
    /// </summary>
    public struct DraftPick
    {
        #region Fields

        /// <summary>
        /// The place number of the draft pick
        /// </summary>
        public readonly int Pick;

        /// <summary>
        /// The player picked
        /// </summary>
        public readonly Player Player;

        /// <summary>
        /// The round the pick was placed in
        /// </summary>
        public readonly int Round;

        /// <summary>
        /// The team that placed the draft pick
        /// </summary>
        public readonly Team Team;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DraftPick"/> struct.
        /// </summary>
        /// <param name="draftedTeam">
        /// The drafted team
        /// </param>
        /// <param name="draftedPlayer">
        /// The drafted player
        /// </param>
        /// <param name="round">
        /// The round number
        /// </param>
        /// <param name="pick">
        /// The pick number
        /// </param>
        public DraftPick(Team draftedTeam, Player draftedPlayer, int round, int pick)
        {
            this.Team = draftedTeam;
            this.Player = draftedPlayer;
            this.Round = round;
            this.Pick = pick;
        }

        #endregion Constructors
    }

    /// <summary>
    /// The draft
    /// </summary>
    [Serializable]
    public class Draft
    {
        #region Fields

        /// <summary>
        /// The draft picks made of this draft
        /// </summary>
        public readonly DraftPick[] DraftPicks;

        /// <summary>
        /// The draft pick eligible players that remain in the draft, once a player is chosen they are removed from the list
        /// </summary>
        public readonly List<Player> DraftPool;

        /// <summary>
        /// Array in the order the teams draft in, from worst in the league to best, each round
        /// </summary>
        public readonly Team[] TeamDraftOrder;

        /// <summary>
        /// Number of teams that are in the league
        /// </summary>
        public readonly int Teams;

        /// <summary>
        /// The year of the draft
        /// </summary>
        public readonly int Year;

        /// <summary>
        /// The amount of rounds in the draft
        /// </summary>
        private static int rounds = 7;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Draft"/> class.
        /// </summary>
        /// <param name="year">
        /// The year of the draft
        /// </param>
        /// <param name="teamsCount">
        /// The number of teams in the league
        /// </param>
        /// <param name="draftOrder">
        /// The draft order of the teams
        /// </param>
        public Draft(int year, int teamsCount, Team[] draftOrder)
        {
            this.Year = year;
            this.Teams = teamsCount;

            // The amount of draft picks to be made in the draft is the # of teams in the league * the amount of rounds that is specified for the draft
            this.DraftPicks = new DraftPick[rounds * this.Teams];
            this.DraftPool = PlayerGenerator.GenerateDraftPool(this.Teams, rounds).ToList();

            // Gives each potential draft pick an initial progress tracker
            this.InitializePlayerTrackerToDraftClass();
            this.DraftPool = this.DraftPool.OrderByDescending(player => player.Overall).ToList();

            // Switches the base draft pool to a list so that the original draft list can be stored as well as the players being chosen becoming unavailable to be picked
            this.DraftPool = this.DraftPool.ToList();
            this.TeamDraftOrder = draftOrder;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the current pick of the draft
        /// </summary>
        public int CurrentPick { get; private set; } = 1;

        /// <summary>
        /// Gets the current round of the draft
        /// </summary>
        public int CurrentRound { get; private set; } = 1;

        /// <summary>
        /// Gets a value indicating whether the draft is done simulating
        /// </summary>
        public bool DoneDrafting { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Simulates the entirety of the remaining draft
        /// </summary>
        public void SimDraft()
        {
            // If the draft is done simulating, no need to run rest of function
            if (this.DoneDrafting)
            {
                return;
            }

            int lastPickInDraft = this.Teams * rounds;

            // While there are still remaining picks to be made, keep making picks
            while (this.CurrentPick <= lastPickInDraft)
            {
                this.MakePick();
            }

            this.DoneDrafting = true;
        }

        /// <summary>
        /// Simulates a single pick as long as there are draft spots remaining
        /// </summary>
        public void SimPick()
        {
            // If the draft is done, no pick can be made
            if (this.DoneDrafting)
            {
                return;
            }

            this.MakePick();

            // If the pick made is the final pick in the draft, set DoneDrafting to true
            if (this.CurrentPick == (rounds * this.Teams) + 1)
            {
                this.DoneDrafting = true;
            }
        }

        /// <summary>
        /// Simulates the rest of the current round of the draft
        /// </summary>
        public void SimRound()
        {
            // If the draft is done, then no simulation can be done
            if (this.DoneDrafting)
            {
                return;
            }

            // The first pick of the next round will be the stopping point
            int nextRoundFirstPick = (this.CurrentRound * this.Teams) + 1;
            while (this.CurrentPick < nextRoundFirstPick)
            {
                this.MakePick();
            }

            // If the final pick of the round is also the final pick of the draft, set DoneDrafting to true
            if (this.CurrentPick == (rounds * this.Teams) + 1)
            {
                this.DoneDrafting = true;
            }
        }

        /// <summary>
        /// Initializes a player progression tracker to all newly created skaters, will track their attribute progression throughout career
        /// </summary>
        private void InitializePlayerTrackerToDraftClass()
        {
            foreach (Player player in this.DraftPool)
            {
                player.InitializePlayerProgressionTracker(this.Year);
            }
        }

        /// <summary>
        /// Makes a single pick for a team based on best player available and adds that player to new team as well as logs it in this class
        /// </summary>
        private void MakePick()
        {
            // Current pick must be offset by 1 to get into zero index
            Team pickingTeam = this.TeamDraftOrder[(this.CurrentPick - 1) % this.Teams];

            // Picks the highest overall player and removes them from the remaining draft pool list
            Player pickedPlayer = this.DraftPool[0];
            this.DraftPool.RemoveAt(0);

            // Adds newly picked player to teams roster
            pickingTeam.AddNewPlayerAndContract(pickedPlayer);
            pickedPlayer.CurrentTeam = pickingTeam;

            // Generates contract for newly drafted player
            ContractGenerator.GenerateContract(pickedPlayer, pickingTeam, this.Year);

            this.DraftPicks[this.CurrentPick - 1] =
                new DraftPick(pickingTeam, pickedPlayer, this.CurrentRound, this.CurrentPick);
            this.CurrentPick++;
            this.CurrentRound = ((this.CurrentPick - 1) / this.Teams) + 1;
        }

        #endregion Methods
    }
}