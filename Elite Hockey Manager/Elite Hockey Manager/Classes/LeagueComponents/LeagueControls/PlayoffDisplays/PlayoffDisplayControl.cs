using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    public enum PlayoffRounds
    {
        Two = 2,
        Three = 3,
        Four = 4
    }
    static class PlayoffRoundsMethods
    {
        public static int GetTotalPlayoffTeams(this PlayoffRounds rounds)
        {
            switch (rounds)
            {
                case PlayoffRounds.Four:
                    return 16;
                case PlayoffRounds.Three:
                    return 8;
                case PlayoffRounds.Two:
                    return 4;
                default:
                    throw new ArgumentException("PlayoffRounds is set to an unknown value");
            }
        }
    }
    public partial class PlayoffDisplayControl : UserControl
    {
        public PlayoffRounds SelectedRounds
        {
            get
            {
                return _selectedRounds;
            }
            set
            {
                _selectedRounds = value;
                //Creates an array of Panels to store the display data
                CreatePanels();
                //Puts the Panels in the control
                UpdateDisplay();
            }
        }
        public League League
        {
            get
            {
                return _league;
            }
            set
            {
                _league = value;
                if (_league != null)
                {
                    SelectedRounds = _league.PlayoffRounds;
                }
            }
        }
        private League _league;
        private PlayoffRounds _selectedRounds = PlayoffRounds.Two;
        private Panel[] panels;
        public PlayoffDisplayControl()
        {
            InitializeComponent();
        }
        public List<PlayoffMatchupViewControl> GetActivePlayoffMatchupViewControls(int currentRound)
        {
            List<PlayoffMatchupViewControl> matchupControls = new List<PlayoffMatchupViewControl>();
            matchupControls.AddRange(panels[currentRound - 1].Controls.OfType<PlayoffMatchupViewControl>().Where(x => !x.Series.SeriesFinished));
            //Gets all the playoffMatchupViewControls from the right side of the display
            //panels.count() - 1 = end of panels - current round which is base 1 so remove 1 to make it base 0
            matchupControls.AddRange(panels[panels.Count() - 1 - (currentRound - 1)].Controls.OfType<PlayoffMatchupViewControl>().Where(x => !x.Series.SeriesFinished));
            return matchupControls;
        }
        public void UpdatePlayoffs()
        {
            UpdateDisplay();
            Playoff playoff = _league.currentPlayoff;
            if (playoff == null || playoff.PlayoffYear != _league.Year)
            {
                throw new ArgumentException("Playoff being set on is invalid or null");
            }
            for (int i = 0; i < playoff.CurrentRound; i++)
            {
                AddPlayoffRoundToDisplay(playoff, i);
            }
        }

        private void AddPlayoffRoundToDisplay(Playoff playoff, int currentRound)
        {
            //If the current round is the finals
            if (currentRound + 1 == (int)playoff.PlayoffRounds)
            {
                PlayoffMatchupViewControl[] matchupViewControls = panels[(int)_selectedRounds - 1].Controls.OfType<PlayoffMatchupViewControl>().ToArray();
                PlayoffSeries finalSeries = playoff.playoffSeriesArray[playoff.playoffSeriesArray.Count() - 1][0];
                matchupViewControls[0].SetSeries(finalSeries);
            }
            //Else if the playoffs are still in the conference stage
            else
            {
                //Round is base zero in this context coming from the for loop in addPlayoffs function
                PlayoffSeries[] currentRoundSeries = playoff.playoffSeriesArray[currentRound];
                DefineSeriesInPanel(panels[currentRound], currentRoundSeries.Take(currentRoundSeries.Length / 2).ToArray());
                DefineSeriesInPanel(panels[panels.Length - 1 - currentRound], currentRoundSeries.Skip(currentRoundSeries.Length / 2).ToArray());
            }
        }
        private void DefineSeriesInPanel(Panel panel, PlayoffSeries[] seriesArray)
        {
            PlayoffMatchupViewControl[] matchupViewControls = panel.Controls.OfType<PlayoffMatchupViewControl>().ToArray();
            if (matchupViewControls.Length != seriesArray.Length)
            {
                throw new ArgumentOutOfRangeException("PlayoffMatchupViewControls and series in seriesArray have to be identical in size");
            }
            for (int i = 0; i < matchupViewControls.Length; i++)
            {
                matchupViewControls[i].SetSeries(seriesArray[i]);
            }
        }
        /// <summary>
        /// Adds Panels to control to corespond with the amount of playoff rounds in the league
        /// 2 rounds will create 3 panels
        /// 3 rounds will create 5 panels
        /// 4 rounds will create 7 panels
        /// </summary>
        private void UpdateDisplay()
        {
            //Removes all old panels upon SelectedRounds property being changed
            this.Controls.Clear();

            int totalPanels = panels.Count();
            //To get a base width of PlayoffMatchupViewControl... TODO Figure out a better way to do this
            PlayoffMatchupViewControl baseViewControl = new PlayoffMatchupViewControl();
            for (int i = 0; i < totalPanels; i++)
            {
                panels[i] = new Panel();
                Panel selectedPanel = panels[i];
                selectedPanel.BorderStyle = BorderStyle.FixedSingle;
                //Sets the height of the panel to the height of this control
                //Width will be set to base width of PlayoffMatchupViewControl
                selectedPanel.Size = new Size(baseViewControl.Size.Width, this.Size.Height);

                //Adds PlayoffMatchupViewControls to this panel based on the amount of rounds it is away from the middle of the array
                AddPlayoffMatchupViewControls(selectedPanel, i + 1);

                int baseX = (int)((double)this.Size.Width * ((double)(i + 1) / (double)(totalPanels + 1)));
                int offsetX = baseX - (selectedPanel.Width / 2);
                if (offsetX < 0)
                {
                    offsetX = 0;
                }
                this.Controls.Add(selectedPanel);
                selectedPanel.Location = new Point(offsetX, 0);
            }

            SetRoundTitles();
        }
        private void AddPlayoffMatchupViewControls(Panel panel, int offset)
        {
            int middlePlayoffIndex = (int)_selectedRounds;
            int controlsToAdd;
            //If the middle panel is being filled, one 1 view will be needed to be added
            if (middlePlayoffIndex == offset)
            {
                controlsToAdd = 1;
            }
            else
            {
                //The absolute value of the middle round minus the given offset will give the distance of rounds between the final and selected round
                //Subtracting that minus 1 and raising 2 to this power will give the amount of games in this round and side of the bracked 
                //I.E 4 rounds - middle index is 4 - round 1 will give 3 - subtract 1 and raise 2 to 2 will give 4 playoff games on that side of the bracket
                controlsToAdd = (int)Math.Pow(2, (Math.Abs(middlePlayoffIndex - offset) - 1));
            }
            //Will be used to arrange the controls within the panel based on the height of this panel
            int totalHeight = panel.Size.Height;
            for (int i = 0; i < controlsToAdd; i++)
            {
                PlayoffMatchupViewControl playoffViewControl = new PlayoffMatchupViewControl();
                //
                int baseY = (int)((double)totalHeight * ((double)(i + 1) / (double)(controlsToAdd + 1)));
                int offsetY = baseY - (playoffViewControl.Size.Height / 2);
                if (offsetY < 0)
                {
                    offsetY = 0;
                }
                panel.Controls.Add(playoffViewControl);
                playoffViewControl.Location = new Point(0, offsetY);
            }
        }
        /// <summary>
        /// Creates an array of panels to be added to control
        /// </summary>
        private void CreatePanels()
        {
            //Private PlayoffRounds enum class variable
            switch (_selectedRounds)
            {
                case PlayoffRounds.Two:
                    panels = new Panel[3];
                    break;
                case PlayoffRounds.Three:
                    panels = new Panel[5];
                    break;
                case PlayoffRounds.Four:
                    panels = new Panel[7];
                    break;
                default:
                    throw new ArgumentException("Invalid playoffRounds in PlayoffDisplayControl.CreatePanels function");
            }
        }
        /// <summary>
        /// Adds a label to each of the panels in panels array to specify title of the round
        /// </summary>
        private void SetRoundTitles()
        {
            int finalIndex = (int)SelectedRounds;
            for (int i = 1; i <= finalIndex; i++)
            {
                switch (finalIndex - i)
                {
                    //League Finals
                    case (0):
                        CreateLabelAddToPanel("Finals", finalIndex - 1);
                        break;
                    //Conference Finals
                    case (1):
                        CreateLabelAddToPanel(String.Format("{0} Conference Finals", _league?.FirstConferenceName), finalIndex + 1 - 1);
                        CreateLabelAddToPanel(String.Format("{0} Conference Finals", _league?.SecondConferenceName), finalIndex - 1 - 1);
                        break;
                    //Conference Semi Finals
                    case (2):
                        CreateLabelAddToPanel(String.Format("{0} Semi-Finals", _league?.FirstConferenceName), finalIndex + 2 - 1);
                        CreateLabelAddToPanel(String.Format("{0} Semi-Finals", _league?.SecondConferenceName), finalIndex - 2 - 1);
                        break;
                    //Conference quarter finals
                    case (3):
                        CreateLabelAddToPanel(String.Format("{0} Quarter-Finals", _league?.FirstConferenceName), finalIndex + 3 - 1);
                        CreateLabelAddToPanel(String.Format("{0} Quarter-Finals", _league?.SecondConferenceName), finalIndex - 3 - 1);
                        break;
                }
            }
        }
        /// <summary>
        /// Creates a label with specificied properties and adds it to panel at given index
        /// </summary>
        /// <param name="title">String of the type of playoff series the label will be added to, I.E finals, semifinals, quarterfinals as well as conference titles</param>
        /// <param name="panelIndex">Index of the panel in panels array to add this label to</param>
        private void CreateLabelAddToPanel(string title, int panelIndex)
        {
            Label label = new Label();
            label.Text = title;
            label.AutoSize = false;
            label.Size = new Size(panels[0].Size.Width, label.Size.Height);
            label.TextAlign = ContentAlignment.MiddleCenter;
            panels[panelIndex].Controls.Add(label);
            label.Location = new Point(0, 0);
        }
    }
}
