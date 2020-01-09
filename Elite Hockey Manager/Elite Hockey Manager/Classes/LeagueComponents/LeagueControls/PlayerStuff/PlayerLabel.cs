using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    public class PlayerLabel : System.Windows.Forms.Label
    {
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (value != null)
                {
                    _player = value;
                }
            }
        }
        public bool DisplayTeamAbbreviation
        {
            get
            {
                return _displayTeamAbbreviation;
            }
            set
            {
                _displayTeamAbbreviation = value;
                UpdateTeamAbbreviation();
            }
        }
        private Player _player;
        private bool _displayTeamAbbreviation = false;
        private string displayPlayerString;
        public PlayerLabel()
        {
            //this.Font = new Font(this.Font, FontStyle.Underline);
            //this.Text = "No Player";
            //Both found using System.Windows.Forms;
            //Centers label within each table cell
            this.Anchor = AnchorStyles.None;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.AutoSize = true;
            this.DoubleClick += LabelDoubleClicked;
        }
        public PlayerLabel(Player player): this()
        {
            Player = player;
            displayPlayerString = _player.ToString().Trim();
            this.Text = displayPlayerString;
        }
        public PlayerLabel(Player player, double statToDisplay) : this()
        {
            Player = player;
            displayPlayerString = String.Format("{0}:{1} {2:0.##}", _player.Position, _player.FullName, statToDisplay);
            this.Text = displayPlayerString;
        }
        private void LabelDoubleClicked(object sender, EventArgs e)
        {
            if (_player != null)
            {
                PlayerDisplayForm form = new PlayerDisplayForm(_player);
                form.ShowDialog();
            }
        }
        /// <summary>
        /// Updates the text of this label on a change in the DisplayTeamAbbreviation public property
        /// </summary>
        private void UpdateTeamAbbreviation()
        {
            //If the displaying the team abbreviation is set to true
            //If player has a team then add the abbreviation of their team in parenthesis before the displayPlayerString
            if (_displayTeamAbbreviation)
            {
                if (_player.CurrentTeam != null)
                {
                    this.Text = String.Format("({0}){1}", _player.CurrentTeam.Abbreviation, displayPlayerString);
                }
            }
            //If the display appreviation boolean is false, Set the text of this label to the base displayPlayerString
            else
            {
                this.Text = displayPlayerString;
            }
        }
    }
}
