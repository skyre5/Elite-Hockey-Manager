using System;
using System.Linq;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    public static class Retirement
    {
        #region Methods

        /// <summary>
        /// Function that is called on every player every year as long as they are not retired
        /// Will determine whether the play chooses to retire based on several factors such as:
        /// Age
        /// Latest player progression changes
        /// Whether they are a starting level player on their team
        /// Whether they have a contract going into next season
        /// </summary>
        /// <param name="player"></param>
        /// <param name="playersTeam"></param>
        /// <param name="rand"></param>
        /// <returns></returns>
        public static bool ChooseToRetire(Player player, Team playersTeam, Random rand)
        {
            double basePercentage = AgeToPercentage(player.Age);
            //If the player is a currently a starting level player on their team, reduce chance of retirement by 30%
            if (IsStartingLevelPlayer(player, playersTeam))
            {
                basePercentage -= .30;
            }
            //If the player has last 10 or more attribute points since last season, increase retirement chance by 20%
            if (player.ProgressionTracker.LatestTotalChangeInAttributes() <= -10)
            {
                basePercentage += .20;
            }
            ModifyPercentageByCurrentContract(player, playersTeam, ref basePercentage);
            if (basePercentage <= 0)
            {
                return false;
            }
            else if (basePercentage >= 100)
            {
                return true;
            }
            //Chooses a random double between 0 and 1
            double randomNumber = rand.NextDouble();
            //If randomNumber is less than the base percentage calculated, the player will retire
            return randomNumber < basePercentage;
        }

        public static bool IsStartingLevelPlayer(Player player, Team team)
        {
            //If the team is null, then there is no chance they are a starting level player
            if (team is null)
            {
                return false;
            }

            int startingSpots;
            if (player is Forward)
                startingSpots = 4;
            else if (player is Defender)
                startingSpots = 3;
            else
                startingSpots = 2;

            //Finds the players rank among players at that position on the team
            int rosterRank = team.Roster.Where(p => p.Position == player.Position).OrderByDescending(x => x.Overall)
                .Where(p => p.Overall > player.Overall).Count() + 1;

            if (rosterRank <= startingSpots)
                return true;
            else
                return false;
        }

        private static double AgeToPercentage(int age)
        {
            switch (age)
            {
                //Max percentage for 18-24 is .07
                case int a when (a < 25):
                    return .01 * (a - 17);
                //Max percentage for 25-29 is .17
                case int a when (a < 30):
                    return .07 + .02 * (a - 24);
                //Max percentage for 30-34 is .42
                case int a when (a < 35):
                    return .17 + .05 * (a - 29);
                //Max percentage for 35-49 is 1.92
                case int a when (a < 50):
                    return .42 + .10 * (a - 34);

                default:
                    return 1;
            }
        }

        private static void ModifyPercentageByCurrentContract(Player player, Team playersTeam, ref double percentage)
        {
            //If the players team is null, they are 20% likely to retire since they did not play during the last year
            if (playersTeam is null)
            {
                percentage += .20;
            }
            //If the player is at the end of their current contract they are 20% more likely to retire
            else if (player.CurrentContract.YearsRemaining == 0)
            {
                percentage *= 1.20;
            }
            //If there is years remaining on their contract, they are half as likely to retire
            else
            {
                percentage *= .50;
            }
        }

        #endregion Methods
    }
}