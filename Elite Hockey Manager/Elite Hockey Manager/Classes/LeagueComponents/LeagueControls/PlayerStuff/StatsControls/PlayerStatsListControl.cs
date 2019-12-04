using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                ClearPlayerLabels();
            }
        }
        //public variables
        //Set by classes container 
        public Label[] PlayerLabels = null;

        //private variables
        private const int LABELHEIGHT = 30;
        private string _title = "statName";
        private int _LabelCount = 5;
        private Label[] _playerLabelsForDisplay = null;
        public PlayerStatsListControl()
        {
            InitializeComponent();
        }
        public void UpdateDisplay()
        {
            ClearPlayerLabels();
            //If the PlayerLabel's have not been initialized by another class, throws null argument exception
            if (PlayerLabels != null)
            {
                //Sets counter to given labelCount and if # of players given is lower, set counter to that # of players. Doesn't change size of control
                int labelsToDisplay = _LabelCount;
                if (PlayerLabels.Count() > labelsToDisplay)
                {
                    labelsToDisplay = PlayerLabels.Count();
                }
                //Initializes array for the displayed labels
                _playerLabelsForDisplay = new Label[labelsToDisplay];
                //Shallow copies over copies of labels from PlayerLabels until it has gotten the desired # for display
                for (int i = 0; i < labelsToDisplay; i++)
                {
                    _playerLabelsForDisplay[i] = PlayerLabels[i];
                }
                //Displays 
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
        private void AddPlayerLabelsToDisplay(Label[] displayedPlayerLabels)
        {
            for (int i = 0; i < displayedPlayerLabels.Count(); i++)
            {
                Label x = displayedPlayerLabels[i];
                this.Controls.Add(x);
                x.Location = new Point(
                    x.Location.X,
                    (LABELHEIGHT * 30) + 1
                    );
            }
        }
    }
}
