﻿using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    public partial class LeagueControl : UserControl
    {
        public event EventHandler SelectButtonClicked;

        private League _league;

        public League League
        {
            get
            {
                return _league;
            }
        }

        public LeagueControl(League league)
        {
            _league = league;
            InitializeComponent();

            if (league == null)
            {
                throw new NullReferenceException("League for LeagueControl componenent is null");
            }
            CheckIsLeagueFullTeams();
        }

        private void PlayerValidation()
        {
            lblPlayersHeader.Text = $"Players: {_league.ActivePlayerCount}";
            int errorCount = _league.GetTeamErrorCount();
            lblPlayersCheck.Text = $"Teams With Errors: {errorCount}";
            if (errorCount == 0)
            {
                picPlayersCheck.Image = Properties.Resources.checkmark;
                btnFillPlayers.Enabled = false;
                btnDisplayPlayersErrors.Enabled = false;
                //Allows user to select league when the league becomes valid for play
                btnSelect.Enabled = true;
            }
            else
            {
                picPlayersCheck.Image = Properties.Resources.xmark;
                btnFillPlayers.Enabled = true;
                btnDisplayPlayersErrors.Enabled = true;
            }
        }

        private void btnFillTeams_Click(object sender, EventArgs e)
        {
            _league.FillRemainingTeams();
            CheckIsLeagueFullTeams();
        }

        private void CheckIsLeagueFullTeams()
        {
            lblName.Text = $@"{_league.LeagueName}({_league.Abbreviation})";
            lblTeamsCount.Text = $@"{_league.TeamCount}/{_league.NumberOfTeams}";
            if (_league.IsFull())
            {
                picTeamsCheck.Image = Properties.Resources.checkmark;
                btnFillTeams.Enabled = false;
                PlayerValidation();
            }
        }

        private void btnFillPlayers_Click(object sender, EventArgs e)
        {
            _league.FillLeagueWithPlayers();
            PlayerValidation();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectButtonClicked(this, e);
        }

        private void btnDisplayPlayersErrors_Click(object sender, EventArgs e)
        {
            string errorList = "These Teams Have Invalid Rosters:\n";
            errorList += _league.GetTeamErrorMessage();
            MessageBox.Show(errorList);
        }
    }
}