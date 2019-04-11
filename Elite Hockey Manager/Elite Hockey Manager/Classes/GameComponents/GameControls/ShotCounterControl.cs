using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameControls
{
    public partial class ShotCounterControl : UserControl
    {
        private Label[] homeLabels;
        private int[] homeShots = new int[] { 0, 0, 0, 0 };
        private Label[] awayLabels;
        private int[] awayShots = new int[] { 0, 0, 0, 0 };
        /// <summary>
        /// Constructor putting control labels into an array
        /// </summary>
        public ShotCounterControl()
        {
            InitializeComponent();
            homeLabels = new Label[] {homeFirstLabel, homeSecondLabel, homeThirdLabel, homeOvertimeLabel, homeTotalLabel };
            awayLabels = new Label[] {awayFirstLabel, awaySecondLabel, awayThirdLabel, awayOvertimeLabel, awayTotalLabel };
        }
        /// <summary>
        /// Takes game object and sets shots in control to games stats
        /// </summary>
        /// <param name="game">Game the stats are taken from</param>
        public void UpdateShotControl(Game game)
        {
            for (int i = 0; i <= 3; i++)
            {
                SetShotCounter(0, i + 1, game.HomeShotsArray[i]);
                SetShotCounter(1, i + 1, game.AwayShotsArray[i]);
            }
            UpdateTotal(0);
            UpdateTotal(1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="team">
        /// 0 - Home
        /// 1 - Away
        /// </param>
        /// <param name="period">
        /// 1-3
        /// 4 for overtime
        /// </param>
        /// <param name="periodShots">
        /// Updated shots for that period
        /// </param>
        private void SetShotCounter(int team, int period, int periodShots)
        {
            if (period < 1 || period > 4 || periodShots < 0 || team < 0 || team > 1)
            {
                throw new ArgumentException();
            }
            switch(team)
            {
                case 0:
                    homeLabels[period - 1].Text = periodShots.ToString();
                    homeShots[period - 1] = periodShots;
                    UpdateTotal(team);
                    break;
                case 1:
                    awayLabels[period - 1].Text = periodShots.ToString();
                    awayShots[period - 1] = periodShots;
                    UpdateTotal(team);
                    break;
            }
        }
        /// <summary> Updates the shot totals</summary>
        /// <param name="team">
        /// 0 - Home
        /// 1 - Away
        /// </param>
        private void UpdateTotal(int team)
        {
            if (team == 0)
            {
                homeLabels.Last().Text = homeShots.Sum().ToString();
            }
            else
            {
                awayLabels.Last().Text = awayShots.Sum().ToString();
            }
        }
    }
}
