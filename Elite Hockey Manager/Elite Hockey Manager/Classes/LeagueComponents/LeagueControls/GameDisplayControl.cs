using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elite_Hockey_Manager.Classes.GameComponents;
using Elite_Hockey_Manager.Forms.GameForms;

namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    public partial class GameDisplayControl : UserControl
    {
        private Game _game;
        public Game Game
        {
            get
            {
                return _game;
            }
            private set
            {
                _game = value;
                SetText();
            }
        }
        public GameDisplayControl(Game game)
        {
            InitializeComponent();
            Game = game;
        }
        private void SetText()
        {
            //TODO
            //Include record along with team name
            gameDisplayLabel.Text = String.Format("{0} @ {1}", _game.AwayTeam.FullName, _game.HomeTeam.FullName);
        }
        private void viewSimButton_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(_game);
            form.ShowDialog();
        }
    }
}
