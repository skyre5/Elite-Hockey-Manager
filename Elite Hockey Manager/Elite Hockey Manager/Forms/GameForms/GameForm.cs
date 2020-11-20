using Elite_Hockey_Manager.Classes.GameComponents;
using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class GameForm : Form
    {
        public Game Game
        {
            get;
            private set;
        } = null;

        public GameForm(Game game)
        {
            Game = game;
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            if (Game != null)
            {
                SetPage();
                gameControl.Game = Game;
            }
        }

        /// <summary>
        /// Called when a game is set for the form
        /// Sets up the titles and page's components
        /// </summary>
        private void SetPage()
        {
            this.Text = Game.Title;
        }
    }
}