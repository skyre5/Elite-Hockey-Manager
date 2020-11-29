namespace Elite_Hockey_Manager.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Forms.GameForms;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The import form.
    /// </summary>
    public partial class ImportForm : Form
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportForm"/> class.
        /// </summary>
        public ImportForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the created league from the import
        /// </summary>
        public League CreatedLeague { get; private set; }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Calls the online API and returns the data returned in a JObject object
        /// </summary>
        /// <param name="callString">
        /// string for online API call
        /// </param>
        /// <param name="data">
        /// The data returned from the API call
        /// </param>
        /// <returns>
        /// JObject response
        /// </returns>
        private bool CallApi(string callString, out JObject data)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(callString).Result;
                bool responseSuccessful = response.IsSuccessStatusCode;
                while ((!responseSuccessful) && response.StatusCode != HttpStatusCode.NotFound)
                {
                    response = client.GetAsync(callString).Result;
                    responseSuccessful = response.IsSuccessStatusCode;
                }

                string stringResult = response.Content.ReadAsStringAsync().Result;
                data = JObject.Parse(stringResult);
                return true;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($@"API request failed {ex}");
                data = null;
                return false;
            }
        }

        /// <summary>
        /// Creates a player with the information from the JToken for the specified player imported from NHL API
        /// </summary>
        /// <param name="baseToken">Token containing player information and ID</param>
        /// <returns>Player object of the created player with information added</returns>
        private Player CreatePlayerFromToken(JToken baseToken)
        {
            string id = baseToken.SelectToken("person.id")?.ToString();
            JObject playerObject;
            this.CallApi($"https://statsapi.web.nhl.com/api/v1/people/{id}", out playerObject);
            JToken playerToken = playerObject.SelectToken("people[0]");

            // Gets the players position as a short designation {C, RW, LW, D, G}
            string position = playerToken?.SelectToken("primaryPosition.code")?.ToString();

            // API doesn't give left or right defense designation so set it as their shooting hand
            if (position == "D")
            {
                position = playerToken.SelectToken("shootsCatches")?.ToString() == "L" ? "LD" : "RD";
            }

            switch (position)
            {
                case "C":
                    return new Center(playerToken);

                case "R":
                    return new RightWinger(playerToken);

                case "L":
                    return new LeftWinger(playerToken);

                case "LD":
                    return new LeftDefensemen(playerToken);

                case "RD":
                    return new RightDefensemen(playerToken);

                case "G":
                    return new Goalie(playerToken);

                default:
                    throw new ArgumentException("Unexpected position string in Token");
            }
        }

        /// <summary>
        /// Gets the conference names from the online NHL API
        /// </summary>
        /// <returns>List of conference names</returns>
        private List<string> GetConferenceNames()
        {
            if (this.CallApi("https://statsapi.web.nhl.com/api/v1/conferences", out JObject conferenceData))
            {
                JToken conferences = conferenceData.SelectToken("conferences");
                return conferences?.Select(conference => conference.SelectToken("name")?.ToString()).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The import function that loads in NHL data from the API upon form load
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args
        /// </param>
        /// <exception cref="ArgumentException"> Thrown when the API doesn't give expected data
        /// </exception>
        private void ImportForm_Load(object sender, EventArgs e)
        {
            JObject teamsData;
            if (!this.CallApi("https://statsapi.web.nhl.com/api/v1/teams/", out teamsData))
            {
                this.statusLabel.Text = @"API request failed";
                return;
            }

            var teamsArray = teamsData.SelectToken("teams");

            // Checks whether there is any info to process
            if (teamsArray == null)
            {
                return;
            }

            // Gets the conference names from the API
            List<string> conferenceNames = this.GetConferenceNames();
            League importLeague;

            // If the GetConferenceNames function had an error or returned invalid data then use default values
            if (conferenceNames != null && conferenceNames.Count == 2 && !conferenceNames.Contains(null))
            {
                importLeague = new League(
                    "National Hockey League",
                    "NHL",
                    teamsArray.Count(),
                    conferenceNames[0],
                    conferenceNames[1]);
            }
            else
            {
                importLeague = new League("National Hockey League", "NHL", teamsArray.Count());
            }

            foreach (var teamInfo in teamsArray)
            {
                try
                {
                    // Constructs team out of JToken object
                    Team team = new Team(teamInfo);

                    // Imports player from online ROSTER into team roster
                    this.ImportPlayersIntoTeam(team);
                    string conference = teamInfo.SelectToken("conference.name")?.ToString();
                    if (conference == importLeague.FirstConferenceName)
                    {
                        importLeague.AddTeam(team);
                    }
                    else if (conference == importLeague.SecondConferenceName)
                    {
                        importLeague.AddTeam(team, 2);
                    }
                    else
                    {
                        throw new ArgumentException("Conference name not matched in importForm");
                    }
                }
                catch (ArgumentException ex)
                {
                    this.statusLabel.Text = @"Data error: Check Console";
                    Console.WriteLine($@"null argument error{ex}");
                    break;
                }
            }

            this.CreatedLeague = importLeague;
            this.statusLabel.Text = @"Import Successful: Imported League shown to the right";
            this.LoadConferencesIntoDisplay();
        }

        /// <summary>
        /// Imports players from NHL team into the team
        /// </summary>
        /// <param name="team">Team that is importing players</param>
        private void ImportPlayersIntoTeam(Team team)
        {
            JObject rosterData;
            this.CallApi($"https://statsapi.web.nhl.com/api/v1/teams/{team.TeamID}?expand=team.roster", out rosterData);
            JToken playerList = rosterData.SelectToken("teams[0].roster.roster");
            if (playerList != null)
            {
                foreach (JToken player in playerList)
                {
                    Player createdPlayer = this.CreatePlayerFromToken(player);
                    team.AddNewPlayerAndContract(createdPlayer);
                    createdPlayer.AddStats(1, team.TeamID, false);
                }
            }
        }

        /// <summary>
        /// Loads the created leagues conferences into labels to show successful import from online API
        /// </summary>
        private void LoadConferencesIntoDisplay()
        {
            if (this.CreatedLeague == null)
            {
                return;
            }

            this.firstConferenceLabel.Text = $@"{CreatedLeague.FirstConferenceName}:{Environment.NewLine}";
            foreach (Team team in this.CreatedLeague.FirstConference)
            {
                this.firstConferenceLabel.Text += $@"{team.Abbreviation}{Environment.NewLine}";
            }

            this.secondConferenceLabel.Text = $@"{CreatedLeague.SecondConferenceName}:{Environment.NewLine}";
            foreach (Team team in this.CreatedLeague.SecondConference)
            {
                this.secondConferenceLabel.Text += $@"{team.Abbreviation}{Environment.NewLine}";
            }
        }

        #endregion Methods

        /// <summary>
        /// Starts a game based on the imported league
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args
        /// </param>
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            // this.CreatedLeague.FillLeagueWithPlayers();
            MainMenuForm form = new MainMenuForm(this.CreatedLeague);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}