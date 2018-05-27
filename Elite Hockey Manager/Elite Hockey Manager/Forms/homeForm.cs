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
using Elite_Hockey_Manager.Forms;

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
            SkaterAttributes attrib = new SkaterAttributes();
            Center center2 = new Center("1", "2", 22, attrib);
            List<Forward> list1 = new List<Forward>();
            List<Center> list2 = new List<Center>();
            Team x = new Team("Philly Flyers");
            


        }

        private void playersBtn_Click(object sender, EventArgs e)
        {
            PlayersForm form = new PlayersForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SkaterAttributes x = new SkaterAttributes();
            x.GetType().GetProperty("WristShot").SetValue(x, 99);
        }
    }
}
