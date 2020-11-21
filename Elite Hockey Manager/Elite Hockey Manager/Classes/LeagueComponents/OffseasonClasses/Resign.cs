using System;
using System.Collections.Generic;
using System.Linq;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    public static class Resign
    {
        #region Methods

        public static void SimulateResignPeriod(League league, Random rand)
        {
            List<Team> teams = league.AllTeams;
            foreach (Team team in teams)
            {
                SimulateTeamResign(league, team, rand);
            }
        }

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
                    //n% chance of player resigning with team
                    int percentage;
                    Type playerType = player.GetType();
                    if (Retirement.IsStartingLevelPlayer(player, team))
                    {
                        percentage = 80;
                    }
                    else
                    {
                        percentage = 30;
                    }
                    //Number between 0 and 99
                    int rollValue = rand.Next(100);
                    //If the percentage chance succeeds, the player will resign with a contract calculated in the GenerateContract class
                    if (rollValue < percentage)
                    {
                        ContractGenerator.GenerateContract(player, team, league.Year);
                    }
                    //The player will choose to not resign and be removed from the team and placed in the unsigned player list
                    else
                    {
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