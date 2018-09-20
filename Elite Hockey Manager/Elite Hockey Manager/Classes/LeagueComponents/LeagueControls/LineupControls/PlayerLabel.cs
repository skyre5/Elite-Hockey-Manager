using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    public class PlayerLabel : System.Windows.Forms.Label
    {
        private Player _player;
        public PlayerLabel()
        {
            this.Font = new Font(this.Font, FontStyle.Underline);
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
                    this.Text = _player.ToString();
                }
            }
        }
    }
}
