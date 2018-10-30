using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff
{
    public class PlayerAttributesTableLayoutPanel : System.Windows.Forms.TableLayoutPanel
    {
        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid player object");
                }
                else
                {
                    _player = value;
                    LoadTable();
                }
            }
        }
        public PlayerAttributesTableLayoutPanel()
        {
            this.RowCount = 1;
            this.ColumnCount = 1;
        }
        private void LoadTable()
        {

        }
    }
}
