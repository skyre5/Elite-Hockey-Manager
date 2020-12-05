namespace Elite_Hockey_Manager.Classes.LeagueComponents.OffseasonClasses
{
    using System;
    using System.Linq;

    using Elite_Hockey_Manager.Classes.Players;

    /// <summary>
    /// Retirement class that handles the retirement functions of the league
    /// </summary>
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
        /// <param name="player">player deciding whether to retire</param>
        /// <param name="playersTeam">team of the player</param>
        /// <param name="rand">random object shared amongst project</param>
        /// <returns>Whether the player chooses to retire</returns>
        public static bool ChooseToRetire(Player player, Team playersTeam, Random rand)
        {
            double basePercentage = AgeToPercentage(player.Age);

            // If the player is a currently a starting level player on their team, reduce chance of retirement by 30%
            if (IsStartingLevelPlayer(player, playersTeam))
            {
                basePercentage -= .30;
            }

            // If the player has last 10 or more attribute points since last season, increase retirement chance by 20%
            if (player.ProgressionTracker.LatestTotalChangeInAttributes() <= -10)
            {
                basePercentage += .20;
            }

            ModifyPercentageByCurrentContract(player, playersTeam, ref basePercentage);
            if (basePercentage <= 0)
            {
                return false;
            }

            if (basePercentage >= 100)
            {
                return true;
            }

            // Chooses a random double between 0 and 1
            double randomNumber = rand.NextDouble();

            // If randomNumber is less than the base percentage calculated, the player will retire
            return randomNumber < basePercentage;
        }

        /// <summary>
        /// Function that determines whether the player is good enough to have a starting position on their team based on overall
        /// </summary>
        /// <param name="player">player to compare to his teammates</param>
        /// <param name="team">team of player</param>
        /// <returns>Whether the player is a starting level player</returns>
        public static bool IsStartingLevelPlayer(Player player, Team team)
        {
            // If the team is null, then there is no chance they are a starting level player
            if (team is null)
            {
                return false;
            }

            int startingSpots;
            if (player is Forward)
            {
                startingSpots = 4;
            }
            else if (player is Defender)
            {
                startingSpots = 3;
            }
            else
            {
                // The player is a goalie
                startingSpots = 2;
            }

            // Finds the players rank among players at that position on the team
            int rosterRank = team.Roster.Where(p => p.PositionAbbreviation == player.PositionAbbreviation)
                                 .OrderByDescending(x => x.Overall).Count(p => p.Overall > player.Overall) + 1;

            // If the player is within the top starting spots of their team, they are a starting player
            return rosterRank <= startingSpots;
        }

        /// <summary>
        /// Function that gives a base percentage for retirement based on age
        /// </summary>
        /// <param name="age">age of the player</param>
        /// <returns>base percentage of retirement based on age</returns>
        private static double AgeToPercentage(int age)
        {
            switch (age)
            {
                // Max percentage for 18-24 is .07
                case int a when a < 25:
                    return .01 * (a - 17);

                // Max percentage for 25-29 is .17
                case int a when a < 30:
                    return .07 + (.02 * (a - 24));

                // Max percentage for 30-34 is .42
                case int a when a < 35:
                    return .17 + (.05 * (a - 29));

                // Max percentage for 35-49 is 1.92
                case int a when a < 50:
                    return .42 + (.10 * (a - 34));

                default:
                    return 1;
            }
        }

        /// <summary>
        /// Modifies the percentage of the player retiring based on their current contract
        /// </summary>
        /// <param name="player">the player that is deciding whether or not to retire</param>
        /// <param name="playersTeam">team of player if they have one</param>
        /// <param name="percentage">base percentage of retiring that will be modified</param>
        private static void ModifyPercentageByCurrentContract(Player player, Team playersTeam, ref double percentage)
        {
            // If the players team is null, they are 20% additionally likely to retire since they did not play during the last year
            if (playersTeam is null)
            {
                percentage += .20;
            }
            else if (player.CurrentContract.YearsRemaining == 0)
            {
                // If the player is at the end of their current contract they are 20% more likely to retire
                percentage *= 1.20;
            }
            else
            {
                // If there is years remaining on their contract, they are half as likely to retire
                percentage *= .50;
            }
        }

        #endregion Methods
    }
}