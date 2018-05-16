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

namespace Elite_Hockey_Manager
{
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void homeForm_Load(object sender, EventArgs e)
        {
            GoalieStats x = new GoalieStats(0, 2);
            Console.WriteLine(x.ShotsFaced);
            Console.WriteLine(x.SavePercentage);
        }
    }
}
