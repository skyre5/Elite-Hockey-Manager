using Elite_Hockey_Manager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    public partial class ProgressionAndRetirementForm : Form
    {
        private League _league;
        public ProgressionAndRetirementForm()
        {
            InitializeComponent();
        }
        public ProgressionAndRetirementForm(League league) : base()
        {
            _league = league;
        }
        private void ProgressionAndRetirementForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
