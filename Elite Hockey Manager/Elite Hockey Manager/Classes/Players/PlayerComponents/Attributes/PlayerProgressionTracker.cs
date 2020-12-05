using System;
using System.Collections.Generic;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes
{
    [Serializable]
    public class PlayerProgressionTracker
    {
        #region Constructors

        public PlayerProgressionTracker(int rookieYear, int baseOverall, BaseAttributes playerAttributes)
        {
            this.RookieYear = rookieYear;
            //Overall rating for year 1
            OverallTrackerList.Add(baseOverall);
            SetBaseAttributes(playerAttributes);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Dictionary of each players attributes with key as attribute and element as a tuple with players original attribute
        /// as well as list with the players overall by each year afterwards
        /// </summary>
        //Attribute Name -> (BaseAttributeValue when created, overalls for each season afterwards
        //AttributeTrackerDictionary["Wrist Shot"] = (80, [82, 84, 88, 81])
        public Dictionary<string, List<int>> AttributeTrackerDictionary { get; } = new Dictionary<string, List<int>>();

        /// <summary>
        /// Tracks player overall each year starting with rookie year
        /// </summary>
        public List<int> OverallTrackerList { get; } = new List<int>();

        /// <summary>
        /// Indicates the players rookie year
        /// Used to keep an offset so that a players changes can be tracked by personal history as well as league history
        /// </summary>
        public int RookieYear { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Function to get the history of a players career history in a certain specific attribute
        /// </summary>
        /// <param name="attributeKey">String name of the attribute thats history will be returned</param>
        /// <returns>Returns a list of all the attribute values the player has had in their career
        /// Returns null if empty
        /// </returns>
        public List<int> GetAttributeHistory(string attributeKey)
        {
            List<int> attributeHistoryList;
            if (AttributeTrackerDictionary.TryGetValue(attributeKey, out attributeHistoryList))
            {
                return attributeHistoryList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the latest cumulative changes in the players career from the players previous year to current
        /// </summary>
        /// <returns>Returns the cummulative attribute changes from the players previous season to this one
        /// Will return 0 if taken during the players rookie year since that would be their base stats
        /// </returns>
        public int LatestTotalChangeInAttributes()
        {
            int latestYear = OverallTrackerList.Count;
            return TotalChangeInAttributesByYear(latestYear);
        }

        /// <summary>
        /// Gets the cumulative changes from the players career by selecting a year to look at
        /// </summary>
        /// <param name="careerYear">Year to calculate total changes in attributes
        /// Year in the players career starting at 1 for rookie year
        /// </param>
        /// <returns>Returns the total cumulative attribute changes from that year in the players career</returns>
        public int TotalChangeInAttributesByYear(int careerYear)
        {
            int totalChangesInYear = 0;
            foreach (string key in AttributeTrackerDictionary.Keys)
            {
                int firstYear = AttributeTrackerDictionary[key][careerYear - 2];
                int secondYear = AttributeTrackerDictionary[key][careerYear - 1];
                totalChangesInYear += secondYear - firstYear;
            }
            return totalChangesInYear;
        }

        public void UpdatePlayerAttributes(int newOverall, BaseAttributes updatedAttributes)
        {
            OverallTrackerList.Add(newOverall);
            InputNewAttributes(updatedAttributes);
        }

        /// <summary>
        /// Inputs the latest attributes from either goalie or skater, appends the current attribute onto the end of the list
        /// Should only ever be called once a season for each player
        /// </summary>
        /// <param name="attributes">Attributes of either goalie or skater</param>
        private void InputNewAttributes(BaseAttributes attributes)
        {
            //GetAttributeNames returns every attribute within either the goalie or skater attributes as a tuple with <string, int> where
            //string is stat name and int is the value it currently holds
            //For every attribute name and value enter it int the dictionay and add it onto the end of the list
            foreach (Tuple<string, int> attribute in attributes.GetAttributeNames())
            {
                AttributeTrackerDictionary[attribute.Item1].Add(attribute.Item2);
            }
        }

        private void SetBaseAttributes(BaseAttributes attributes)
        {
            foreach (Tuple<string, int> attribute in attributes.GetAttributeNames())
            {
                AttributeTrackerDictionary[attribute.Item1] = new List<int>(new List<int>() { attribute.Item2 });
            }
        }

        #endregion Methods
    }
}