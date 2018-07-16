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
        public int NumberOfTeams
        {
            get;
            private set;
        }
        public string LeagueName
        {
            get;
            private set;
        }
        public string Abbreviation
        {
            get;
            private set;
        }
        public string FirstConferenceName
        {
            get;
            private set;
        }
        public string SecondConferenceName
        {
            get;
            private set;
        }
        public List<Team> FirstConference
        {
            get;
            private set;
        } = new List<Team>();
        public List<Team> SecondConference
        {
            get;
            private set;
        } = new List<Team>();
        
        public League(string name, string abbreviation, int teamsCount)
        {
            this.LeagueName = name;
            this.Abbreviation = abbreviation;
            this.NumberOfTeams = teamsCount;

            this.FirstConferenceName = "West";
            this.SecondConferenceName = "East";
        }
        public League(string name, string abbreviation, int teamsCount, string firstName, string secondName)
        {
            this.LeagueName = name;
            this.Abbreviation = abbreviation;
            this.NumberOfTeams = teamsCount;

            this.FirstConferenceName = firstName;
            this.SecondConferenceName = secondName;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("LeagueName", this.LeagueName);
            info.AddValue("LeagueAbbreviation", this.Abbreviation);
            info.AddValue("TeamAmount", this.NumberOfTeams);

            info.AddValue("FirstConference", this.FirstConference);
            info.AddValue("FirstConferenceName", this.FirstConferenceName);

            info.AddValue("SecondConference", this.SecondConference);
            info.AddValue("SecondConferenceName", this.SecondConferenceName);
        }
        public League(SerializationInfo info, StreamingContext context)
        {
            this.LeagueName = (string)info.GetValue("LeagueName", typeof(string));
            this.Abbreviation = (string)info.GetValue("LeagueAbbreviation", typeof(string));
            this.NumberOfTeams = (int)info.GetValue("TeamAmount", typeof(int));

            this.FirstConference = (List<Team>)info.GetValue("FirstConference", typeof(List<Team>));
            this.FirstConferenceName = (string)info.GetValue("FirstConferenceName", typeof(string));

            this.SecondConference = (List<Team>)info.GetValue("SecondConference", typeof(List<Team>));
            this.SecondConferenceName = (string)info.GetValue("SecondConferenceName", typeof(string));
        }
        public override string ToString()
        {
            return String.Format("{0} - {1} - Teams:{2}", this.Abbreviation, this.LeagueName, this.NumberOfTeams);
        }
    }
}
