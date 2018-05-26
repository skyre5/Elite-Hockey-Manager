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

namespace Elite_Hockey_Manager.Forms
{
    public partial class EditPlayerForm : Form
    {
        Player player;
        public EditPlayerForm(Player chosenPlayer)
        {
            player = chosenPlayer;
            InitializeComponent();
        }

        private void EditPlayerForm_Load(object sender, EventArgs e)
        {
            this.Text = player.FullName + " - Edit";
        }
    }
}
