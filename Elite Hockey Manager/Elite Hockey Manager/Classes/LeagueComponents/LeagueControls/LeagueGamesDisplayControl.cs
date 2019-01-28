using System;
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

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class LeagueGamesDisplayControl : UserControl
    {
        public LeagueGamesDisplayControl()
        {
            InitializeComponent();
        }
        public void SetSchedule(List<Game> games)
        {
            foreach (Game game in games)
            {
                gameLayoutPanel.Controls.Add(new GameDisplayControl(game));
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
    }
}
