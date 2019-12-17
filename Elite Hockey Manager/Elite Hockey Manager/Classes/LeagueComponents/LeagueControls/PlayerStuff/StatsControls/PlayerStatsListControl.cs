using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls
{
    public partial class PlayerStatsListControl : UserControl
    {
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                titleLabel.Text = value;
            }
        }
        public int LabelCount
        {
            get
            {
                return _LabelCount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Label count must be positive");
                }
                _LabelCount = value;
                this.Height = ((LABELHEIGHT * (value + 1)) + 20);
                //ClearPlayerLabels();
            }
        }
        //public variables
        //Set by classes container 
        public Label[] PlayerLabels;

        //private variables
        private const int LABELHEIGHT = 30;
        private string _title = "statName";
        private int _LabelCount;
        private PlayerLabel[] _playerLabelsForDisplay = null;
        public PlayerStatsListControl()
        {
            InitializeComponent();
            LabelCount = 5;
        }
        public void UpdateDisplay(PlayerLabel[] InputPlayersLabels)
        {
            PlayerLabels = new Label[InputPlayersLabels.Count()];
            InputPlayersLabels.CopyTo(PlayerLabels, 0);
            ClearPlayerLabels();
            //If the PlayerLabel's have not been initialized by another class, throws null argument exception
            if (InputPlayersLabels != null && InputPlayersLabels.Length != 0)
            {
                //Sets counter to given labelCount and if # of players given is lower, set counter to that # of players. Doesn't change size of control
                int labelsToDisplay = _LabelCount;
                if (InputPlayersLabels.Count() < labelsToDisplay)
                {
                    labelsToDisplay = InputPlayersLabels.Count();
                }
                //Initializes array for the displayed labels
                _playerLabelsForDisplay = new PlayerLabel[labelsToDisplay];
                //Shallow copies over copies of labels from PlayerLabels until it has gotten the desired # for display
                for (int i = 0; i < labelsToDisplay; i++)
                {
                    _playerLabelsForDisplay[i] = InputPlayersLabels[i];
                }
                AddPlayerLabelsToDisplay(_playerLabelsForDisplay);
            }
            else
            {
                throw new ArgumentNullException("PlayerStatsListControl _playerLabels was not initialized.");
            } 
        }
        private void ClearPlayerLabels()
        {
            if (_playerLabelsForDisplay != null)
            {
                foreach (Label label in _playerLabelsForDisplay)
                {
                    this.Controls.Remove(label);
                }
                _playerLabelsForDisplay = null;
            }
        }
        public void AddPlayerLabelsToDisplay(PlayerLabel[] displayedPlayerLabels)
        {
            for (int i = 0; i < displayedPlayerLabels.Count(); i++)
            {
                displayedPlayerLabels[i].Location = new Point(
                    0,
                    (LABELHEIGHT * (i + 1)) + 1
                    );
                this.Controls.Add(displayedPlayerLabels[i]);
            }
        }
    }
}
