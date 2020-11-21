using Elite_Hockey_Manager.Classes.GameComponents;
using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    public partial class GameForm : Form
    {
        #region Constructors

        public GameForm(Game game)
        {
            Game = game;
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public Game Game
        {
            get;
            private set;
        } = null;

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}