using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls
{
    public partial class PlayerStatsListControl : UserControl
    {
        public int LabelCount
        {
            get
            {
                return _LabelCount;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Label count must be positive");
                }
                _LabelCount = value;
                this.Height = LABELHEIGHT * (value + 1);
                ClearPlayerLabels();
            }
        }
        private const int LABELHEIGHT = 30;
        private int _LabelCount = 5;
        private Label[] _playerLabels = null;
        public PlayerStatsListControl()
        {
            InitializeComponent();
        }
        public void ClearPlayerLabels()
        {
            if (_playerLabels != null)
            {
                foreach (Label label in _playerLabels)
                {
                    this.Controls.Remove(label);
                    label.Dispose();
                }
                _playerLabels = null;
            }
        }
        public void AddPlayerLabels(Label[] playerLabels)
        {
            for (int i = 0; i < playerLabels.Count(); i++)
            {
                Label x = playerLabels[i];
                this.Controls.Add(x);
                x.Location = new Point(
                    x.Location.X,
                    (LABELHEIGHT * 30) + 1
                    );
            }
        }
    }
}
