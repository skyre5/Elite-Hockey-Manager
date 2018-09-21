using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    public class PlayerLabel : System.Windows.Forms.Label
    {
        private Player _player;
        public PlayerLabel(Player player)
        {
            this.Font = new Font(this.Font, FontStyle.Underline);
            this.Text = "No Player";
            this.AutoSize = true;
            this.DoubleClick += LabelDoubleClicked;
            Player = player;
        }
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (value != null)
                {
                    _player = value;
                    this.Text = _player.ToString().Trim();
                }
            }
        }
        private void LabelDoubleClicked(object sender, EventArgs e)
        {
            if (_player != null)
            {
                PlayerDisplayForm form = new PlayerDisplayForm(_player);
                form.ShowDialog();
            }
        }
    }
}
