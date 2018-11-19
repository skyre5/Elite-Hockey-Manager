using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class PlayerDisplayForm : Form
    {
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _player = value;
            }
        }
        public PlayerDisplayForm(Player player)
        {
            InitializeComponent();
            Player = player;
        }

        private void PlayerDisplayForm_Load(object sender, EventArgs e)
        {
            this.Text = _player.ToString();

            nameLabel.Text = String.Format("Name: {0}", _player.FullName);

            ageLabel.Text = String.Format("Age: {0}", _player.Age.ToString());

            //Sets player status depending on whether play is Forward, Defender, or Goalie
            int statusId = _player.PlayerStatusID;
            if (_player is Forward)
            {
                statusLabel.Text = String.Format("Status: {0}", ((ForwardPlayerStatus)statusId).ToString());
            }
            else if (_player is Defender)
            {
                statusLabel.Text = String.Format("Status: {0}", ((DefensePlayerStatus)statusId).ToString());
            }
            else if (_player is Goalie)
            {
                statusLabel.Text = String.Format("Status: {0}", ((GoaliePlayerStatus)statusId).ToString());
            }

            contractLabel.Text = String.Format("Contract: {0}M", _player.CurrentContract.ContractAmount);
            playerAttributesPanel.Player = _player;
        }

    }
}
