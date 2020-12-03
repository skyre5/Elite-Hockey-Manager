namespace Elite_Hockey_Manager.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using System.Windows.Forms;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Classes.LeagueComponents;
    using Elite_Hockey_Manager.Classes.Utility;
    using Elite_Hockey_Manager.Forms.GameForms;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The import form.
    /// </summary>
    public partial class ImportForm : Form
    {
        #region Fields

        /// <summary>
        /// Bool variable to alternate each team to have around an equal number of left and right defenders
        /// </summary>
        private static bool alternatingDefenderBool = true;

        /// <summary>
        /// Random object to be used across form to ensure random results
        /// </summary>
        private readonly Random rand = new Random();

        #endregion Fields

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

        #region Properties

        /// <summary>
        /// Gets or sets the selected season string that will be appended onto the API calls
        /// </summary>
        private string SelectedSeason { get; set; }

        #endregion Properties

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
        /// Calls the NHL API for that specific player, can get expensive when done for an entire league and send 600 API calls
        /// </summary>
        /// <param name="baseToken">Token containing player information and ID</param>
        /// <returns>Player object of the created player with information added</returns>
        private Player CreateDetailedPlayerFromToken(JToken baseToken)
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
        /// Creates simple player with just position and name
        /// Randomly creates age
        /// </summary>
        /// <param name="baseToken">
        /// Token containing player information
        /// </param>
        /// <returns>
        /// The <see cref="Player"/>.
        /// </returns>
        private Player CreateSimplePlayerFromToken(JToken baseToken)
        {
            Player returnPlayer;

            // Gets the useful info out of the JToken extracted from the API for each player
            string fullName = baseToken.SelectToken("person.fullName")?.ToString();
            string position = baseToken.SelectToken("position.code")?.ToString();
            int? playerNumber = baseToken.SelectToken("jerseyNumber")?.ToObject<int>();

            // If any of the info is null then the JToken is incomplete and import fails
            if (fullName == null || position == null)
            {
                throw new ArgumentNullException(nameof(baseToken), @"JToken doesn't contain player information");
            }

            // Some players have not been given player numbers from the API, in that case give a random number
            if (playerNumber == null)
            {
                playerNumber = this.rand.Next(1, 100);
            }

            // Splits the fullname given by the API into first and last name
            string[] names = fullName.Split(' ');

            // If the players full name splits into more than 2 names, append them into the 2nd array place
            // Example of a 3 length name is Michael Dal Colle, 4 length Jacob De La Rose
            if (names.Count() > 2)
            {
                for (int i = 2; i < names.Count(); i++)
                {
                    names[1] += names[i];
                }
            }

            // If the player is listed as a defender turn him into a left or right defender based on alternating static variable
            if (position == "D")
            {
                position = alternatingDefenderBool ? "LD" : "RD";

                // Switches the defenders position for the next creation of a defender
                alternatingDefenderBool = !alternatingDefenderBool;
            }

            switch (position)
            {
                case "C":
                    returnPlayer = PlayerGenerator.GenerateForward(1, this.rand.Next(1, 5));
                    break;

                case "R":
                    returnPlayer = PlayerGenerator.GenerateForward(2, this.rand.Next(1, 5));
                    break;

                case "L":
                    returnPlayer = PlayerGenerator.GenerateForward(0, this.rand.Next(1, 5));
                    break;

                case "LD":
                    returnPlayer = PlayerGenerator.GenerateDefender(0, this.rand.Next(1, 4));
                    break;

                case "RD":
                    returnPlayer = PlayerGenerator.GenerateDefender(0, this.rand.Next(1, 4));
                    break;

                case "G":
                    returnPlayer = PlayerGenerator.GenerateGoalie(this.rand.Next(1, 3));
                    break;

                default:
                    throw new ArgumentException("Unexpected position string in Token");
            }

            returnPlayer.FirstName = names[0];
            returnPlayer.LastName = names[1];
            returnPlayer.PlayerNumber = (int)playerNumber;
            return returnPlayer;
        }

        /// <summary>
        /// Gets the conference names from the online NHL API
        /// </summary>
        /// <returns>List of conference names</returns>
        private List<string> GetConferenceNames()
        {
            int season = int.Parse(this.SelectedSeason.Substring(0, 4));

            // If the year is between 1967 and 1973 there are no conferences and each team is in one of 2 divisions
            // When teams are added to league they will have to view the Division property of the JToken instead of conference
            if (season <= 1973 && season >= 1967)
            {
                return new List<string>() { "East", "West" };
            }

            // If the year is between 1974 and 1992 the conferences have a separate name prior to becoming eastern and wester conference
            if (season <= 1992 && season >= 1974)
            {
                return new List<string>() { "Clarence Campbell", "Prince of Wales" };
            }

            if (this.CallApi($"https://statsapi.web.nhl.com/api/v1/conferences?season={SelectedSeason}", out JObject conferenceData))
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
        /// Button that starts the process of importing online data from an API
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            this.importLeagueBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Setups form functionality upon form load
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        private void ImportForm_Load(object sender, EventArgs e)
        {
            // Begins loading of seasons from 1993 currently
            // TODO Add functionality for seasons prior to 1967 where there was only one conference
            // TODO Add functionality for season prior to 1974 and after 1967 where divisions represent conferences in the API
            // TODO Fix errors in 2004-2005 api call (lockout year)
            int firstYear = int.Parse(Properties.Resources.firstYearImport);
            int finalYear = int.Parse(Properties.Resources.finalYearImport);

            // Begins building list from most recent season to the first season available
            for (int year = finalYear; year >= firstYear; year--)
            {
                string displayString = $"{year}-{year + 1}";
                this.selectSeasonComboBox.Items.Add(displayString);
            }

            // Removes year that was not played and has issues in API
            this.selectSeasonComboBox.Items.Remove("2004-2005");

            // Sets the selected index to be the most recent year
            this.selectSeasonComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Imports league details from online API
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The DoWorkEvent args
        /// </param>
        private void ImportLeague_DoWork(object sender, DoWorkEventArgs e)
        {
            JObject teamsData;
            if (!this.CallApi($"https://statsapi.web.nhl.com/api/v1/teams?season={SelectedSeason}", out teamsData))
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

            // Stores how many percentage points go up for each team imported simplified to an integer
            int basePercentage = 100 / teamsArray.Count();

            // Stores how many teams have been successfully imported
            int teamsImported = 0;
            foreach (var teamInfo in teamsArray)
            {
                try
                {
                    // Constructs team out of JToken object
                    Team team = new Team(teamInfo);

                    // Imports player from online ROSTER into team roster
                    this.ImportPlayersIntoTeam(team);

                    // Holds the conference of the current team
                    string conferenceName;

                    // Gets the season of the import into an int
                    int season = int.Parse(this.SelectedSeason.Substring(0, 4));

                    // If the year is between 1967 and 1973 there are no conferences listed in API, but the divisions act as conferences for our purpose
                    if (season <= 1973 && season >= 1967)
                    {
                        conferenceName = Import.TrySelectToken(teamInfo, "division.name");
                    }
                    else
                    {
                        conferenceName = Import.TrySelectToken(teamInfo, "conference.name");
                    }

                    if (conferenceName == importLeague.FirstConferenceName)
                    {
                        importLeague.AddTeam(team, 1, false);
                    }
                    else if (conferenceName == importLeague.SecondConferenceName)
                    {
                        importLeague.AddTeam(team, 2, false);
                    }
                    else
                    {
                        throw new ArgumentException("Conference name not matched in importForm");
                    }

                    // Iterates and reports the amount of teams that have been imported correctly
                    this.importLeagueBackgroundWorker.ReportProgress(basePercentage * ++teamsImported);
                }
                catch (ArgumentException ex)
                {
                    this.statusLabel.Text = @"Data error: Check Console";
                    Console.WriteLine($@"null argument error{ex}");
                    break;
                }
            }

            this.CreatedLeague = importLeague;
        }

        /// <summary>
        /// Reports progress in importing of league
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ImportLeagueBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.importProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Runs when the import of the league is finished
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ImportLeagueBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.importProgressBar.Value = 100;

            // If the import successfully created a league then enable the player to start a league with it
            if (this.CreatedLeague != null)
            {
                this.statusLabel.Text = @"Import Successful: Imported League shown to the right";
                this.LoadConferencesIntoDisplay();
                this.startGameButton.Enabled = true;
            }
        }

        /// <summary>
        /// Imports players from NHL team into the team
        /// </summary>
        /// <param name="team">Team that is importing players</param>
        private void ImportPlayersIntoTeam(Team team)
        {
            JObject rosterData;
            this.CallApi($"https://statsapi.web.nhl.com/api/v1/teams/{team.TeamID}?expand=team.roster&season={SelectedSeason}", out rosterData);
            JToken playerList = rosterData.SelectToken("teams[0].roster.roster");
            if (playerList != null)
            {
                foreach (JToken playerToken in playerList)
                {
                    Player createdPlayer = this.CreateSimplePlayerFromToken(playerToken);

                    // Player createdPlayer = this.CreateDetailedPlayerFromToken(player);
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

        /// <summary>
        /// Stores the new selected season in a property upon selected index change
        /// </summary>
        /// <param name="sender">ComboBox sender</param>
        /// <param name="e">event args</param>
        private void SelectSeasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox selectedComboBox = (ComboBox)sender;
            string displayString = (string)selectedComboBox.SelectedItem;
            this.SelectedSeason = displayString.Remove(4, 1);
        }

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

    #endregion Methods
}