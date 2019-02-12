﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class GameDisplayControl : UserControl
    {
        private Game _game;
        public Game Game
        {
            get
            {
                return _game;
            }
            private set
            {
                _game = value;
                SetGameText();
            }
        }
        public GameDisplayControl(Game game)
        {
            InitializeComponent();
            Game = game;
        }
        private void SetGameText()
        {
            //TODO
            //Include record along with team name
            gameDisplayLabel.Text = String.Format("{0} @ {1}", _game.AwayTeam.FullName, _game.HomeTeam.FullName);
            if (_game.Finished)
            {
                scoreLabel.Text = String.Format("{0}-{1}", _game.AwayScore, _game.HomeScore);
            }
        }
        public void DisableButtons()
        {
            //Enabled to let players view game results
            //autoSimButton.Enabled = false;
            viewSimButton.Enabled = false;
        }
        private void viewSimButton_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(_game);
            form.ShowDialog();
        }

        private void autoSimButton_Click(object sender, EventArgs e)
        {
            _game.PlayGame();
            if (_game.AwayScore == _game.HomeScore)
            {
                Console.WriteLine("fsdfsdf");
            }
            scoreLabel.Text = String.Format("{0}-{1}", _game.AwayScore, _game.HomeScore);
            DisableButtons();
        }
    }
}
