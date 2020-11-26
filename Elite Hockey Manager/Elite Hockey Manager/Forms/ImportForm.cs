namespace Elite_Hockey_Manager.Forms
{
    using System;
    using System.Linq;
    using System.Net;
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
            var client = new System.Net.Http.HttpClient();
            string teamsString = "https://statsapi.web.nhl.com/api/v1/teams/";
            var response = client.GetAsync(teamsString).Result;
            bool responseSuccessful = response.IsSuccessStatusCode;
            while ((!responseSuccessful) && (response.StatusCode != HttpStatusCode.NotFound))
            {
                response = client.GetAsync(teamsString).Result;
                responseSuccessful = response.IsSuccessStatusCode;
            }

            var stringResult = response.Content.ReadAsStringAsync().Result;
            var json = JObject.Parse(stringResult);

            var teamsArray = json.SelectToken("teams");

            // Checks whether there is any info to process
            if (teamsArray == null)
            {
                return;
            }

            League importLeague = new League("National Hockey League", "NHL", teamsArray.Count());
            foreach (var teamInfo in teamsArray)
            {
                try
                {
                    Team team = new Team(teamInfo);
                    string conference = teamInfo.SelectToken("conference.name")?.ToString();
                    if (conference == "Eastern")
                    {
                        importLeague.AddTeam(team, 2);
                    }
                    else if (conference == "Western")
                    {
                        importLeague.AddTeam(team);
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
            this.CreatedLeague.FillLeagueWithPlayers();
            MainMenuForm form = new MainMenuForm(this.CreatedLeague);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}