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
        private PlayoffRounds _selectedRounds = PlayoffRounds.Two;
        private Panel[] panels;
        public PlayoffDisplayControl()
        {
            InitializeComponent();
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
                    return;
                case PlayoffRounds.Three:
                    panels = new Panel[5];
                    return;
                case PlayoffRounds.Four:
                    panels = new Panel[7];
                    return;
                default:
                    throw new ArgumentException("Invalid playoffRounds in PlayoffDisplayControl.CreatePanels function");
            }
        }
    }
}
