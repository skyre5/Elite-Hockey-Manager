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
        public ShotCounterControl()
        {
            InitializeComponent();
            homeLabels = new Label[] {homeFirstLabel, homeSecondLabel, homeThirdLabel, homeOvertimeLabel, homeTotalLabel };
            awayLabels = new Label[] {awayFirstLabel, awaySecondLabel, awayThirdLabel, awayOvertimeLabel, awayTotalLabel };
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
        public void SetShotCounter(int team, int period, int periodShots)
        {
            if (period < 1 || period > 3 || periodShots < 0 || team < 0 || team > 1)
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
