﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes;
using Elite_Hockey_Manager.Forms.GameForms;
using Elite_Hockey_Manager.Classes.LeagueComponents;

namespace Elite_Hockey_Manager.Forms.HelperForms
{
    public partial class NewGameForm : Form
    {
        private BindingList<League> leagueList;
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void newLeagueButton_Click(object sender, EventArgs e)
        {
            LeagueInfoForm newTeamForm = new LeagueInfoForm();
            newTeamForm.ShowDialog();
            if (newTeamForm.createdLeague != null)
            {
                League league = newTeamForm.createdLeague;
                league.FillRemainingTeams();
                league.FillLeagueWithPlayers();
                MainMenuForm gameForm = new MainMenuForm(league);
                gameForm.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            League league1 = new League("Test", "Test", 32);
            LeagueControl lg1 = new LeagueControl(league1);
            leaguesLayoutPanel.Controls.Add(lg1);
            league1.FillRemainingTeams();
            LeagueControl lg2 = new LeagueControl(league1);
            leaguesLayoutPanel.Controls.Add(lg2);
        }

        private void NewGameForm_Load(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.LoadListToFile<League>("LeagueData.data", out leagueList))
            {
                MessageBox.Show("Saved league list did not load in correctly");
            }
            //Loads each league into the form as leagueControl
            foreach (League league in leagueList)
            {
                LeagueControl lg = new LeagueControl(league);
                leaguesLayoutPanel.Controls.Add(lg);
                lg.SelectButtonClicked += SelectTeamLeagueControlClick;
            }
        }
        private void SelectTeamLeagueControlClick(object leagueControl, EventArgs e)
        {
            try
            {
                LeagueControl lg = (LeagueControl)leagueControl;
                League league = lg.League;
                MainMenuForm form = new MainMenuForm(league);
                form.Show();
                this.Close();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error casting event object to LeagueControl object");
            }

        }
    }
}