using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class League : ISerializable
    {
        private string _leagueName;
        private string _leagueAbbreviation;

        private string _firstConferenceName;
        private List<Team> _firstConference;

        private string _secondConferenceName;
        private List<Team> _secondConference;
        
        public League(string name, string abbreviation)
        {
            _leagueName = name;
            _leagueAbbreviation = abbreviation;
            _firstConferenceName = "West";
            _secondConferenceName = "East";
        }
        public League(string name, string abbreviation, string firstName, string secondName)
        {
            _leagueName = name;
            _leagueAbbreviation = abbreviation;
            _firstConferenceName = firstName;
            _secondConferenceName = secondName;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeagueName", this._leagueName);
            info.AddValue("LeagueAbbreviation", this._leagueAbbreviation);

            info.AddValue("FirstConference", this._firstConference);
            info.AddValue("FirstConferenceName", this._firstConferenceName);

            info.AddValue("SecondConference", this._secondConference);
            info.AddValue("SecondConferenceName", this._secondConferenceName);
        }
        public League(SerializationInfo info, StreamingContext context)
        {
            this._leagueName = (string)info.GetValue("LeagueName", typeof(string));
            this._leagueAbbreviation = (string)info.GetValue("LeagueAbbreviation", typeof(string));

            this._firstConference = (List<Team>)info.GetValue("FirstConference", typeof(List<Team>));
            this._firstConferenceName = (string)info.GetValue("FirstConferenceName", typeof(string));

            this._secondConference = (List<Team>)info.GetValue("SecondConference", typeof(List<Team>));
            this._secondConferenceName = (string)info.GetValue("SecondConferenceName", typeof(string));
        }
    }
}
