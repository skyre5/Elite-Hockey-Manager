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
            Center c = new Center("1", "2", 20);
            List<Forward> list1 = new List<Forward>();
            List<Center> list2 = new List<Center>();
            Team x = new Team("Philly Flyers");
            


        }
    }
}
