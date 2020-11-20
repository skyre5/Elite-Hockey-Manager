using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.GameComponents.GameControls
{
    public partial class HomeLineControl : UserControl
    {
        public HomeLineControl()
        {
            InitializeComponent();
        }

        public void SetForwards(string players)
        {
            forwardsLabel.Text = players;
        }

        public void SetDefenders(string players)
        {
            DefendersLabel.Text = players;
        }

        public void SetGoalie(string player)
        {
            GoaliesLabel.Text = player;
        }

        private void linePanel_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}