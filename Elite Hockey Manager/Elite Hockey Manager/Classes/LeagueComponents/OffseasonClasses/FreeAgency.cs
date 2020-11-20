using System;
using System.Collections.Generic;
using System.Linq;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    public static class FreeAgency
    {
        public static void SimulateFreeAgencyPeriod(League league, Random rand)
        {
            List<Player> freeAgents = league.UnsignedPlayers;
            freeAgents = freeAgents.OrderByDescending(p => p.Overall).ToList();
            foreach (Player player in freeAgents)
            {
                //Each player will get 3 opportunities to sign with a new team
                //If all 3 passes fail then the player will remain unsigned for next season
                for (int i = 0; i < 3; i++)
                {
                    Team signingTeam = league.AllTeams[rand.Next(league.NumberOfTeams)];
                    if (Retirement.IsStartingLevelPlayer(player, signingTeam))
                    {
                        ContractGenerator.GenerateContract(player, signingTeam, league.Year);
                        signingTeam.AddNewPlayer(player);
                        player.CurrentTeam = signingTeam;
                        league.UnsignedPlayers.Remove(player);
                        break;
                    }
                }
            }
        }
    }
}