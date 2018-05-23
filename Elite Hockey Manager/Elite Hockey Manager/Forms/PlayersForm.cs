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
        public PlayersForm()
        {
            InitializeComponent();
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
            //Saves the contents of the playerList into a data file
            //Creates it if one did not exist
            Stream playersStream = File.Open("PlayerData.data", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(playersStream, playerList);
            playersStream.Close();
            //Closes player window form
            this.Close();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            //Loads the user created players if they are found
            if (File.Exists("PlayerData.data"))
            {
                Stream playersStream = File.Open("PlayerData.data", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                //Takes the list of players and deserializes it into playerList class object
                playerList = (BindingList<Player>)bf.Deserialize(playersStream);
                playersStream.Close();
                //Places players into list box
                FillPlayerListBox();
            }
            else
            {
                //If no playerList exists makes a new one
                playerList = new BindingList<Player>();
            }
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
    }
}
