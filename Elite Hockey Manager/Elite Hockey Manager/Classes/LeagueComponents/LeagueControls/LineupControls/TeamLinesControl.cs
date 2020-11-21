using Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class TeamLinesControl : UserControl
    {
        #region Fields

        private Team _team;

        #endregion Fields

        #region Constructors

        public TeamLinesControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public Team Team
        {
            get
            {
                return _team;
            }
            set
            {
                if (value != null)
                {
                    _team = value;
                    DisplayLines();
                }
            }
        }

        #endregion Properties

        #region Methods

        public void DisplayLines()
        {
            FillTableLayout<LeftWinger>(ForwardLayoutPanel, 0, 4);
            FillTableLayout<Center>(ForwardLayoutPanel, 1, 4);
            FillTableLayout<RightWinger>(ForwardLayoutPanel, 2, 4);
            FillTableLayout<LeftDefensemen>(defenseLayoutPanel, 0, 3);
            FillTableLayout<RightDefensemen>(defenseLayoutPanel, 1, 3);
            FillTableLayout<Goalie>(goalieLayoutPanel, 0, 2);
        }

        private void FillTableLayout<T>(TableLayoutPanel panel, int column, int rowSize)
        {
            List<Player> players = _team.GetPlayersOfType<T>();
            if (players.Count < rowSize)
            {
                rowSize = players.Count;
            }
            for (int i = 0; i < rowSize; i++)
            {
                panel.Controls.Add(new PlayerLabel(players[i]), column, i);
            }
        }

        private void TeamLinesControl_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}