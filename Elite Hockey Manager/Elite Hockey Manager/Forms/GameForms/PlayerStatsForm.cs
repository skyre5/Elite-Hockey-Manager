using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    using System.Collections;

    using Elite_Hockey_Manager.Classes;
    using Elite_Hockey_Manager.Classes.Utility;

    public partial class PlayerStatsForm : Form
    {
        #region Constructors

        public PlayerStatsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStatsForm"/> class.
        /// </summary>
        /// <param name="league">
        /// League containing players
        /// </param>
        /// <param name="allTime">
        /// Whether the stats are for career stats or stats of the current season
        /// </param>
        public PlayerStatsForm(League league, bool allTime) : this()
        {
            if (allTime)
            {
            }
            else
            {
                this.SetCurrentSeasonStats(league);
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the DataGridView to the stats of the current season
        /// </summary>
        /// <param name="league">League containing the signed players from this season</param>
        private void SetCurrentSeasonStats(League league)
        {
            List<Skater> signedSkaters = league.SignedPlayers.OfType<Skater>().ToList();
            var query = from p in signedSkaters
                        where p.Stats.GamesPlayed > 0
                        orderby p.Stats.Points
                        select new
                        {
                            p.FullName,
                            p.Overall,
                            p.Position,
                            p.Age,
                            p.Stats.Goals,
                            p.Stats.Assists,
                            p.Stats.Points,
                            p.Stats.PlusMinus
                        };

            // Creates sortableBindingList from extension method in SortableBindingList class file
            var bindingList = query.ToList().ToSortableBindingList();
            this.playerStatsDataGridView.DataSource = bindingList;
        }

        #endregion Methods
    }
}