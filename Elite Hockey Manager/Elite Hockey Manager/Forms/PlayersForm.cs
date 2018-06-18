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
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace Elite_Hockey_Manager.Forms
{
    public partial class PlayersForm : Form
    {
        int randomChoice = 0;
        Type sortType = typeof(Player);
        //List of user created players
        BindingList<Player> playerList;
        BindingList<Player> displayList = new BindingList<Player>();
        //Bool variable to track whether to ask player to save before exiting
        private bool changeMade = false;
        public PlayersForm()
        {
            InitializeComponent();
            createPositionDropdown.SelectedIndex = 0;
        }
        /// <summary>
        /// Fills the PlayerListBox with all the user created players
        /// </summary>
        private void FillPlayerListBox()
        {
            playerListBox.DataSource = null;
            CategorizePlayerList<Player>();
            playerListBox.DataSource = displayList;
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            //If no changes have been made or it has been saved it will close without prompt
            if (!changeMade)
            {
                this.Close();
            }
            else
            {
                DialogResult x = MessageBox.Show("Do you want to save before exiting?", "Save", MessageBoxButtons.YesNoCancel);
                //Close player form with saving
                if (x == DialogResult.Yes)
                {
                    if (SaveLoadUtils.SavePlayersToFile<Player>("PlayerData.data", playerList))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Save Failed: Check Console for details");
                        this.Close();
                    }
                }
                else if (x == DialogResult.No)
                {
                    this.Close();
                }
            }
        }
        private void PlayersForm_Load(object sender, EventArgs e)
        {
            if (!SaveLoadUtils.LoadPlayersToFile<Player>("PlayerData.data", out playerList))
            {
                MessageBox.Show("Saved player data not loaded in correctly");
            }
            FillPlayerListBox();
        }

        private void randomCheckChange(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            string tag = (string)button.Tag;
            try
            {
                randomChoice = int.Parse(tag);
                
            }
            catch (Exception ex)
            {
                randomChoice = -1;
                Console.WriteLine(ex);
                Console.WriteLine("Error: invalid tag was entered: " + tag);
            }
        }

        private void createRandomBtn_Click(object sender, EventArgs e)
        {
            if (randomChoice == -1)
            {
                MessageBox.Show("Invalid choice, Select one of the positions");
            }
            else if (PlayerGenerator.Status == -1)
            {
                MessageBox.Show("Invalid name file configuration");
            }
            else
            {
                //A change will have been made at this point
                changeMade = true;
                switch (randomChoice)
                {
                    case 0:
                        playerList.Add(PlayerGenerator.CreateRandomCenter());
                        break;
                    case 1:
                        playerList.Add(PlayerGenerator.CreateRandomLeftWing());
                        break;
                    case 2:
                        playerList.Add(PlayerGenerator.CreateRandomRightWing());
                        break;
                    case 3:
                        playerList.Add(PlayerGenerator.CreateRandomLeftDefender());
                        break;
                    case 4:
                        playerList.Add(PlayerGenerator.CreateRandomRightDefender());
                        break;
                    case 5:
                        playerList.Add(PlayerGenerator.CreateRandomGoalie());
                        break;
                    default:
                        Console.WriteLine("Invalid entry from creating random players:" + randomChoice.ToString());
                        break;
                }
            }
            //Pushes added player to Player containing list box for display
            //Only if it matches the current sort type
            Player newPlayer = playerList[playerList.Count - 1];
            if (sortType.IsInstanceOfType(newPlayer)) 
            {
                displayList.Add(newPlayer);
            }
        }
        private void sortRadioChange(object sender, EventArgs e)
        {
            int sortChoice;
            RadioButton button = (RadioButton)sender;
            string tag = (string)button.Tag;
            try
            {
                sortChoice = int.Parse(tag);
            }
            catch (Exception ex)
            {
                sortChoice = -1;
                Console.WriteLine(ex);
                Console.WriteLine("Error: Invalid sort tag index: " + tag);
            }
            switch (sortChoice)
            {
                case 0:
                    CategorizePlayerList<Player>();
                    sortType = typeof(Player);
                    break;
                case 1:
                    CategorizePlayerList<Skater>();
                    sortType = typeof(Skater);
                    break;
                case 2:
                    CategorizePlayerList<Goalie>();
                    sortType = typeof(Goalie);
                    break;
                case 3:
                    CategorizePlayerList<Forward>();
                    sortType = typeof(Forward);
                    break;
                case 4:
                    CategorizePlayerList<Defender>();
                    sortType = typeof(Defender);
                    break;
                case 5:
                    CategorizePlayerList<Center>();
                    sortType = typeof(Center);
                    break;
                case 6:
                    CategorizePlayerList<LeftWinger>();
                    sortType = typeof(LeftWinger);
                    break;
                case 7:
                    CategorizePlayerList<RightWinger>();
                    sortType = typeof(RightWinger);
                    break;
                case 8:
                    CategorizePlayerList<LeftDefensemen>();
                    sortType = typeof(LeftDefensemen);
                    break;
                case 9:
                    CategorizePlayerList<RightDefensemen>();
                    sortType = typeof(RightDefensemen);
                    break;
            }
        }
        public void CategorizePlayerList<T>()
        {
            displayList = new BindingList<Player>();
            foreach (object x in playerList.OfType<T>())
            {
                Player p = (Player)x;
                displayList.Add(p);
            }
            playerListBox.DataSource = displayList;
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            //change will probably have been made at this point
            changeMade = true;

            List<Player> removedPlayers = new List<Player>();
            foreach (Player player in playerListBox.SelectedItems)
            {
                removedPlayers.Add(player);
            }
            foreach (Player player in removedPlayers)
            {
                displayList.Remove(player);
                playerList.Remove(player);
            }
        }

        private void createPositionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO Can probably be done in a better way 
            string position = (string)createPositionDropdown.SelectedItem;
            if (position == "G")
            {
                stat1Label.Text = "High:";
                stat2Label.Text = "Low:";
                stat3Label.Text = "Speed:";
                stat4Label.Text = "Rebound Control:";
                stat5Label.Visible = false;
                stat5Text.Visible = false;
                stat6Label.Visible = false;
                stat6Text.Visible = false;
                stat7Label.Visible = false;
                stat7Text.Visible = false;
            }
            else if (!stat7Text.Visible)
            {
                stat1Label.Text = "Wrist Shot:";
                stat2Label.Text = "Slap Shot:";
                stat3Label.Text = "Awareness:";
                stat4Label.Text = "Checking:";
                stat5Label.Text = "Deking:";
                stat6Label.Text = "Speed:";
                stat7Label.Text = "Faceoff:";
                stat5Label.Visible = true;
                stat5Text.Visible = true;
                stat6Label.Visible = true;
                stat6Text.Visible = true;
                stat7Label.Visible = true;
                stat7Text.Visible = true;
            }
        }

        private void createPlayerBtn_Click(object sender, EventArgs e)
        {
            changeMade = true;
            string pos = (string)createPositionDropdown.SelectedItem;
            if (pos == "G")
            {
                GoalieAttributes GA = new GoalieAttributes();
                string firstName = firstText.Text;
                string lastName = lastText.Text;
                int age = int.Parse(ageText.Text);
                if (!string.IsNullOrWhiteSpace(stat1Text.Text)) { GA.High = int.Parse(stat1Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat2Text.Text)) { GA.Low = int.Parse(stat2Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat3Text.Text)) { GA.Speed = int.Parse(stat3Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat4Text.Text)) { GA.ReboundControl = int.Parse(stat4Text.Text); }
                Goalie newPlayer = new Goalie(firstName, lastName, age, GA);
                playerList.Add(newPlayer);
                if (sortType.IsInstanceOfType(newPlayer))
                {
                    displayList.Add(newPlayer);
                }
            }
            else
            {
                Skater newPlayer = null;
                SkaterAttributes SA = new SkaterAttributes();
                string firstName = firstText.Text;
                string lastName = lastText.Text;
                int age = int.Parse(ageText.Text);
                if (!string.IsNullOrWhiteSpace(stat1Text.Text)) { SA.WristShot = int.Parse(stat1Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat2Text.Text)) { SA.SlapShot = int.Parse(stat2Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat3Text.Text)) { SA.Awareness = int.Parse(stat3Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat4Text.Text)) { SA.Checking = int.Parse(stat4Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat5Text.Text)) { SA.Deking = int.Parse(stat5Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat6Text.Text)) { SA.Speed = int.Parse(stat6Text.Text); }
                if (!string.IsNullOrWhiteSpace(stat7Text.Text)) { SA.Faceoff = int.Parse(stat7Text.Text); }
                switch (pos)
                {
                    case "C":
                        newPlayer = new Center(firstName, lastName, age, SA);
                        break;
                    case "LW":
                        newPlayer = new LeftWinger(firstName, lastName, age, SA);
                        break;
                    case "RW":
                        newPlayer = new RightWinger(firstName, lastName, age, SA);
                        break;
                    case "LD":
                        newPlayer = new LeftDefensemen(firstName, lastName, age, SA);
                        break;
                    case "RD":
                        newPlayer = new RightDefensemen(firstName, lastName, age, SA);
                        break;
                }
                if (newPlayer != null)
                {
                    playerList.Add(newPlayer);
                    if (sortType.IsInstanceOfType(newPlayer))
                    {
                        displayList.Add(newPlayer);
                    }
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            changeMade = true;
            int index = playerListBox.SelectedIndex;
            if (index != -1) {
                Player editPlayer = displayList[index];
                OpenEditPlayer(editPlayer);
            }
        }
        private void OpenEditPlayer(Player editPlayer)
        {
            EditPlayerForm form = new EditPlayerForm(editPlayer);
            form.ShowDialog();
            //Will show player changes
            //TODO set property change up
            playerListBox.DataSource = null;
            playerListBox.DataSource = displayList;
        }

        private void playerListBox_DoubleClicked(object sender, EventArgs e)
        {
            int index = playerListBox.SelectedIndex;
            if (index != -1)
            {
                Player editPlayer = displayList[index];
                OpenEditPlayer(editPlayer);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            changeMade = false;
            if (!SaveLoadUtils.SavePlayersToFile<Player>("PlayerData.data", playerList))
            {
                MessageBox.Show("Save Failed: Check console");
            }
        }
    }
}
