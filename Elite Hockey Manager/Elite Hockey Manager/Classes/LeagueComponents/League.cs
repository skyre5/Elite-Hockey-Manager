using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Classes.LeagueComponents;

namespace Elite_Hockey_Manager.Classes
{
    [Serializable]
    public class League : ISerializable
    {
        private int _numberOfTeams;
        public const double MINSALARYCAP = 40;
        public int NumberOfTeams
        {
            get
            {
                return _numberOfTeams;
            }
            private set
            {
                if (value < 6 || value > 32)
                {
                    throw new ArgumentException("Error: Team value must be between 6 and 32");
                }
                else
                {
                    _numberOfTeams = value;
                }
            }
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
        public List<Team> AllTeams
        {
            get
            {
                return FirstConference.Concat(SecondConference).ToList();
            }
        }
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
        /// <summary>
        /// Creates random teams to fill out the rest of the leagues teams
        /// </summary>
        public  void FillRemainingTeams()
        {
            if (FirstConference.Count + SecondConference.Count == NumberOfTeams)
            {
                return;
            }
            //If the number of teams is odd
            if (NumberOfTeams % 2 == 1)
            {
                //gets the max conference size
                int largeConferenceSize = (NumberOfTeams + 1) / 2;
                if (FirstConference.Count != largeConferenceSize && SecondConference.Count != largeConferenceSize)
                {
                    FillConference(FirstConference, largeConferenceSize);
                    FillConference(SecondConference, largeConferenceSize - 1);
                }
                else
                {
                    if (FirstConference.Count == largeConferenceSize)
                    {
                        FillConference(SecondConference, largeConferenceSize - 1);
                    }
                    else
                    {
                        FillConference(FirstConference, largeConferenceSize - 1);
                    }
                }
            }
            else
            {
                int maxConferenceSize = (NumberOfTeams / 2);
                FillConference(FirstConference, maxConferenceSize);
                FillConference(SecondConference, maxConferenceSize);
            }
        }
        /// <summary>
        /// Fills a conference with randomly generated teams to fill the conferences size
        /// </summary>
        /// <param name="conference">Conference that will have teams added onto it</param>
        /// <param name="desiredSize">Desired size of conference</param>
        public static void FillConference(List<Team> conference, int desiredSize)
        {
            if (desiredSize < 0)
            {
                throw new ArgumentOutOfRangeException("Argument must be 0 or greater");
            }
            int addCount = desiredSize - conference.Count;
            for (int i = 0; i < addCount; i++)
            {
                Tuple<string, string> teamInfo = TeamGenerator.GetFullTeamName();
                Team addTeam = new Team(teamInfo.Item1, teamInfo.Item2);
                conference.Add(addTeam);
            }
        }
        /// <summary>
        /// Function that returns whether the league is at its specified size
        /// </summary>
        /// <returns>Returns boolean of whether league is full of teams</returns>
        public bool IsFull()
        {
            return FirstConference.Count + SecondConference.Count == _numberOfTeams;
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
        /// <summary>
        /// Checks if a team exists within the league. Exists for avoiding duplicates within the league
        /// </summary>
        /// <param name="team">Team to be checked within the league for its existence</param>
        /// <returns></returns>
        private bool DoesTeamExist(Team team)
        {
            return AllTeams.Contains(team);
        }
        /// <summary>
        /// Checks if a team can be added to a certain conference. 
        /// Used primarily for odd sized league logic
        /// </summary>
        /// <param name="conference">
        /// 1 - First Conference
        /// 2 - Second conference
        /// </param>
        /// <returns></returns>
        private bool ConferenceSpaceCheck(int conference)
        {
            int selectedConferenceSize;
            if (conference == 1)
            {
                selectedConferenceSize = FirstConference.Count;
            }
            else if (conference == 2)
            {
                selectedConferenceSize = SecondConference.Count;
            }
            else
            {
                //Error, not specified conference
                throw new ArgumentException("Invalid conference selection");
            }
            if (_numberOfTeams % 2 == 0)
            {
                int maxTeams = _numberOfTeams / 2;
                return !(selectedConferenceSize == maxTeams);
            }
            //If odd
            else
            {
                int maxTeams = (_numberOfTeams + 1) / 2;
                return !(selectedConferenceSize == maxTeams);

            }
        }
        public void AddTeam(Team team, int conference = 1)
        {
            if (team == null)
            {
                throw new ArgumentNullException("Team is not defined. Cannot be added to conference");
            }
            //Throws exception if an exact team object already exists in league
            if (DoesTeamExist(team))
            {
                throw new ArgumentException("Team already exists within the league, league can't have mutliples of a single team");
            }
            if (AllTeams.Count == _numberOfTeams)
            {
                throw new ArgumentException("League is full, can not add another team");
            }
            if (!ConferenceSpaceCheck(conference))
            {
                throw new ArgumentException("Conference is full, can only add to the other conference");
            }
            switch (conference)
            {
                case 1:
                    FirstConference.Add(team);
                    break;
                case 2:
                    SecondConference.Add(team);
                    break;
                default:
                    throw new ArgumentException("Conference is not defined");
            }
        }
        /// <summary>
        /// Fills each team in the league with the minimum number of players to function
        /// </summary>
        public void FillLeagueWithPlayers()
        {
            foreach (Team team in FirstConference)
            {
                TeamGenerator.FillTeam(team);
            }
            foreach (Team team in SecondConference)
            {
                TeamGenerator.FillTeam(team);
            }
        }
    }
}
