using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    using Elite_Hockey_Manager.Classes.Players;

    public partial class FreeAgencyForm : Form
    {
        #region Fields

        private List<Player> _freeAgents = new List<Player>();

        #endregion Fields

        #region Constructors

        public FreeAgencyForm(League league)
        {
            InitializeComponent();
            if (league != null)
            {
                GetFreeAgents(league);
            }
        }

        #endregion Constructors

        #region Methods

        private void FillLayoutPanel()
        {
            _freeAgents = _freeAgents.OrderByDescending(p => p.CurrentContract.ContractAmount).ToList();
            foreach (Player player in _freeAgents)
            {
                Label signingLabel = new Label
                {
                    //Stores the player object in the label so that it can be used to open up the player label
                    Tag = player,
                    Text = $"{player.FullName} ({player.PositionAbbreviation}) joined the {player.CurrentTeam.TeamName}, moving on from the " +
                    //Team they were previously signed on
                    //TODO Create ability to determine if the player was previously unsigned for the entire previous year
                    $"{player.CareerContracts[player.CareerContracts.Count() - 2].SigningTeam.TeamName} " +
                    $"{player.CurrentContract.ContractAmount} AAV for {player.CurrentContract.ContractDuration} years",
                    AutoSize = true
                };
                playersLayoutPanel.Controls.Add(signingLabel);
            }
        }

        private void FreeAgencyForm_Load(object sender, EventArgs e)
        {
            FillLayoutPanel();
            SetTotalMoneySpent();
        }

        private void GetFreeAgents(League league)
        {
            List<Player> baseFreeAgents = league.SignedPlayers.Where(p => p.CurrentContract.YearSigned == league.Year).ToList();
            _freeAgents = baseFreeAgents.Where(p => p.CareerContracts.Count > 1)
                .Where(p => p.CareerContracts[p.CareerContracts.Count() - 2].SigningTeam != p.CurrentTeam).ToList();
        }

        private void SetTotalMoneySpent()
        {
            double totalSpent = 0;
            foreach (Player player in _freeAgents)
            {
                totalSpent += player.CurrentContract.YearsRemaining * player.CurrentContract.ContractAmount;
            }
            totalSpentLabel.Text = $"Cash Spent: {(totalSpent * 1E6).ToString("C", CultureInfo.CurrentCulture)}";
        }

        #endregion Methods
    }
}