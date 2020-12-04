using Elite_Hockey_Manager.Classes;
using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class PlayerDisplayForm : Form
    {
        #region Fields

        private Player _player;

        #endregion Fields

        #region Constructors

        public PlayerDisplayForm(Player player)
        {
            InitializeComponent();
            Player = player;
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties

        #region Methods

        private void PlayerDisplayForm_Load(object sender, EventArgs e)
        {
            this.Text = _player.ToString();

            nameLabel.Text = $"Name: {_player.FullName}";

            ageLabel.Text = $"Age: {_player.Age.ToString()}";

            //Sets player status depending on whether play is Forward, Defender, or Goalie
            int statusId = _player.PlayerStatusId;
            if (_player is Forward)
            {
                statusLabel.Text = $"Status: {((ForwardPlayerStatus)statusId).ToString()}";
            }
            else if (_player is Defender)
            {
                statusLabel.Text = $"Status: {((DefensePlayerStatus)statusId).ToString()}";
            }
            else if (_player is Goalie)
            {
                statusLabel.Text = $"Status: {((GoaliePlayerStatus)statusId).ToString()}";
            }

            contractLabel.Text = $"Contract: {_player.CurrentContract.ContractAmount}M";
            playerAttributesPanel.Player = _player;
        }

        #endregion Methods
    }
}