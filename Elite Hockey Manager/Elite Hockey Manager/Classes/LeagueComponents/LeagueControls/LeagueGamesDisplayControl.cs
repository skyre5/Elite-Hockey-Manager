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
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls;
using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class LeagueGamesDisplayControl : UserControl
    {
        public List<GameDisplayControl> viewableGameDisplayControls = new List<GameDisplayControl>();
        public LeagueGamesDisplayControl()
        {
            InitializeComponent();
        }
        public void SetSchedule(List<Game> games)
        {
            gameLayoutPanel.Controls.Clear();
            viewableGameDisplayControls.Clear();
            foreach (Game game in games)
            {
                GameDisplayControl gameDisplayControl = new GameDisplayControl(game);
                gameLayoutPanel.Controls.Add(gameDisplayControl);
                viewableGameDisplayControls.Add(gameDisplayControl);
            }
        }
        public void LinkPlayoffMatchupViewControlEvents(List<PlayoffMatchupViewControl> playoffControls)
        {
            for (int i = 0; i < viewableGameDisplayControls.Count; i++)
            {
                int gameId = viewableGameDisplayControls[i].Game.GameNumber;
                //If the game being show to the user to manually/auto sim is the same game as is being tracked in the series tracking control
                //gameId is being offset by 1 because it is 1 based when set in game but zero based when being accessed to grab
                if (viewableGameDisplayControls[i].Game == playoffControls[i].Series.GetGameByIndex(gameId - 1)) {
                    viewableGameDisplayControls[i].PlayerSimmedGameEvent += playoffControls[i].UpdateDisplayByManualUserSim;
                }
            }
        }
        public void SetDay(int day)
        {
            if (day < 1)
            {
                throw new ArgumentException("Day must be greater or equal to 1");
            }
            dayLabel.Text = String.Format("Day: {0}", day);
        }
        public void SetPlayoffRoundAndDay(int round, int day)
        {
            dayLabel.Text = String.Format("Round {0} Day:{1}", round, day);
        }
    }
}
