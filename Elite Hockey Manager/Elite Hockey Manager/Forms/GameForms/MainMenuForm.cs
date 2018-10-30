using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class MainMenuForm : Form
    {
        private League _league;
        public League League
        {
            get
            {
                return _league;
            }
        }
        public MainMenuForm(League league)
        {
            _league = league;
            this.Text = String.Format("{0} - Home", _league.LeagueName);
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            standingsControl.ActiveLeague = _league;
            standingsControl.LoadConferences();
        }
    }
}
