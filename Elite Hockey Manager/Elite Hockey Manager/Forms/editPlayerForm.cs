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
            firstText.Text = player.FirstName;
            lastText.Text = player.LastName;
            ageText.Text = player.Age.ToString();
            idText.Text = player.ID.ToString();
            FillStats();

        }
        private void FillStats()
        {
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = "Hello";
                label.Location = new System.Drawing.Point(13,  150 + (i * 10));
                statsGroup.Controls.Add(label);
            }
        }
    }
}
