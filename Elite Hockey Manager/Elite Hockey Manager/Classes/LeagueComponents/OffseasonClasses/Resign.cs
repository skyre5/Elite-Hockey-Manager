namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elite_Hockey_Manager.Classes.Players;

    /// <summary>
    /// The resign class handling resign period of league where players can resign with their existing team
    /// </summary>
    public static class Resign
    {
        #region Methods

        /// <summary>
        /// Simulates the given league through its entire resign period that sees players remain on the same team
        /// or choose to go to free agency
        /// </summary>
        /// <param name="league">league that will have resign simulated</param>
        /// <param name="rand">random object shared in project</param>
        public static void SimulateResignPeriod(League league, Random rand)
        {
            List<Team> teams = league.AllTeams;
            foreach (Team team in teams)
            {
                SimulateTeamResign(league, team, rand);
            }
        }

        /// <summary>
        /// Simulates the resign phase of a team
        /// </summary>
        /// <param name="league">league that resign is taking place in</param>
        /// <param name="team">team of player choosing whether or not to resign</param>
        /// <param name="rand">random object shared amongst project</param>
        private static void SimulateTeamResign(League league, Team team, Random rand)
        {
            List<Player> expiringPlayers = team.Roster.Where(p => p.CurrentContract.YearsRemaining == 0).ToList();
            foreach (Player player in expiringPlayers)
            {
                if (player.Age < 25)
                {
                    ContractGenerator.GenerateContract(player, team, league.Year);
                    return;
                }
                else
                {
                    // n% chance of player resigning with team
                    // 80% if the player is a starting level player, 30% otherwise
                    int percentage = Retirement.IsStartingLevelPlayer(player, team) ? 80 : 30;

                    // Number between 0 and 99
                    int rollValue = rand.Next(100);

                    // If the percentage chance succeeds, the player will resign with a contract calculated in the GenerateContract class
                    if (rollValue < percentage)
                    {
                        ContractGenerator.GenerateContract(player, team, league.Year);
                    }
                    else
                    {
                        // The player will choose to not resign and be removed from the team and placed in the unsigned player list
                        player.CurrentTeam = null;
                        league.UnsignedPlayers.Add(player);
                        team.Roster.Remove(player);
                    }
                }
            }
        }

        #endregion Methods
    }
}