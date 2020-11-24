namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The free agency class to simulate signing of unsigned players to new teams
    /// </summary>
    public static class FreeAgency
    {
        #region Methods

        /// <summary>
        /// Simulates the free agency period
        /// </summary>
        /// <param name="league">League to simulate free agency</param>
        /// <param name="rand">Random object shared across project</param>
        public static void SimulateFreeAgencyPeriod(League league, Random rand)
        {
            List<Player> freeAgents = league.UnsignedPlayers;
            freeAgents = freeAgents.OrderByDescending(p => p.Overall).ToList();
            foreach (Player player in freeAgents)
            {
                // Each player will get 3 opportunities to sign with a new team
                // If all 3 passes fail then the player will remain unsigned for next season
                for (int i = 0; i < 3; i++)
                {
                    Team signingTeam = league.AllTeams[rand.Next(league.NumberOfTeams)];
                    if (Retirement.IsStartingLevelPlayer(player, signingTeam))
                    {
                        // Adds the player to the team and generates contract with that team
                        signingTeam.AddNewPlayerAndContract(player);
                        player.CurrentTeam = signingTeam;
                        league.UnsignedPlayers.Remove(player);
                        break;
                    }
                }
            }
        }

        #endregion Methods
    }
}