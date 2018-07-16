using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Forms.HelperForms;
using Elite_Hockey_Manager.Classes;

namespace Elite_Hockey_Manager.Forms
{
    public partial class LeagueForm : Form
    {
        BindingList<League> LeagueList = new BindingList<League>();
        public LeagueForm()
        {
            InitializeComponent();
        }

        private void createLeagueBtn_Click(object sender, EventArgs e)
        {
            LeagueInfoForm leagueForm = new LeagueInfoForm();
            leagueForm.ShowDialog();
            if (leagueForm.createdLeague != null)
            {
                League newLeague = leagueForm.createdLeague;
                LeagueList.Add(newLeague);
            }
        }

        private void LeagueForm_Load(object sender, EventArgs e)
        {
            leagueListBox.DataSource = LeagueList;
        }
    }
}
