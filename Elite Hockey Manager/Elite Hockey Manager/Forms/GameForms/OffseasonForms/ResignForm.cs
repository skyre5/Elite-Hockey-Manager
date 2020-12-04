using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class ResignForm : Form
    {
        #region Fields

        private List<Player> _resignedPlayers = new List<Player>();

        #endregion Fields

        #region Constructors

        public ResignForm(League league)
        {
            InitializeComponent();
            _resignedPlayers = league?.ActivePlayers.Where(x => x.CurrentContract.YearSigned == league.Year).ToList();
        }

        #endregion Constructors

        #region Methods

        private void FillLayoutPanel()
        {
            _resignedPlayers = _resignedPlayers.OrderByDescending(p => p.CurrentContract.ContractAmount).ToList();
            foreach (Player player in _resignedPlayers)
            {
                Label signingLabel = new Label
                {
                    //Stores the player object in the label so that it can be used to open up the player label
                    Tag = player,
                    Text = $"{player.FullName} ({player.PositionAbbreviation}) resigned with the {player.CurrentTeam.TeamName} at " +
                    $"{player.CurrentContract.ContractAmount} AAV for {player.CurrentContract.ContractDuration} years",
                    AutoSize = true
                };
                playersLayoutPanel.Controls.Add(signingLabel);
            }
        }

        private void ResignForm_Load(object sender, EventArgs e)
        {
            SetTotalMoneySpent();
            FillLayoutPanel();
        }

        private void SetTotalMoneySpent()
        {
            double totalSpent = 0;
            foreach (Player player in _resignedPlayers)
            {
                totalSpent += player.CurrentContract.YearsRemaining * player.CurrentContract.ContractAmount;
            }
            totalSpentLabel.Text = $"Cash Spent: {(totalSpent * 1E6).ToString("C", CultureInfo.CurrentCulture)}";
        }

        #endregion Methods
    }
}