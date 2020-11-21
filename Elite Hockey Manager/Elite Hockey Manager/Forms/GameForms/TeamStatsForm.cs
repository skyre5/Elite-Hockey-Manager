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
    using Elite_Hockey_Manager.Classes;

    public partial class TeamStatsForm : Form
    {
        #region Constructors

        public TeamStatsForm()
        {
            InitializeComponent();
        }

        public TeamStatsForm(League league, bool allTime) : base()
        {
        }

        #endregion Constructors
    }
}