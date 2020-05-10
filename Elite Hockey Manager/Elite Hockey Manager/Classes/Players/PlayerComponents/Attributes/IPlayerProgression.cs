using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.Players.PlayerComponents.Attributes
{
    public interface IPlayerProgression 
    {
        /// <summary>
        /// Indicates the players rookie year
        /// Used to keep an offset so that a players changes can be tracked by personal history as well as league history
        /// </summary>
        int RookieYear { get; }
        /// <summary>
        /// Keeps track of if the player is currently retired
        /// If player is retired, then no further additions should be made to this history
        /// </summary>
        bool IsRetired { get; }
        /// <summary>
        /// Dictionary of each players attributes with key as attribute and element as a tuple with players original attribute
        /// as well as list with the players overall by each year afterwards
        /// </summary>
        //Attribute Name -> (BaseAttributeValue when created, overalls by season first element is 1 year post rookie )
        //AttributeTrackerDictionary["Wrist Shot"] = (80, [80, 84, 88, 81])
        Dictionary<string, Tuple<int, List<int>>> AttributeTrackerDictionary { get; }
        /// <summary>
        /// Tracks player overall each year starting with rookie year
        /// </summary>
        List<int> OverallTrackerList { get;  }
        /// <summary>
        /// Gets the latest cumulative changes in the players career from the players previous year to current
        /// </summary>
        /// <returns>Returns the cummulative attribute changes from the players previous season to this one
        /// Will return 0 if taken during the players rookie year since that would be their base stats
        /// </returns>
        int TotalChangeInAttributes();
        /// <summary>
        /// Gets the cumulative changes from the players career by selecting a year to look at 
        /// </summary>
        /// <param name="careerYear">Year to calculate total changes in attributes
        /// Year in the players career starting at 1 for rookie year
        /// </param>
        /// <returns>Returns the total cumulative attribute changes from that year in the players career</returns>
        int TotalChangeInAttributes(int careerYear);
        /// <summary>
        /// Function to get the history of a players career history in a certain specific attribute
        /// </summary>
        /// <param name="attributeKey">String name of the attribute thats history will be returned</param>
        /// <returns>Returns a list of all the attribute values the player has had in their career</returns>
        List<int> GetAttributeHistory(string attributeKey);
    }
}
