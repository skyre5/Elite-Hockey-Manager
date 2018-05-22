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
        //List of user created players
        List<Player> playerList;
        public PlayersForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fills the PlayerListBox with all the user created players
        /// </summary>
        private void FillPlayerListBox()
        {
            //Empties the playerListBox so can be redisplayed
            playerListBox.Items.Clear();
            foreach (Player x in playerList)
            {
                playerListBox.Items.Add(x.ToString());
            }
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
                playerList = (List<Player>)bf.Deserialize(playersStream);
                playersStream.Close();
                //Places players into list box
                FillPlayerListBox();
            }
            else
            {
                //If no playerList exists makes a new one
                playerList = new List<Player>();
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
            //Pushes added player to Player containing list box for dispaly
            FillPlayerListBox();
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
                    break;
                case 1:
                    CategorizePlayerList<Skater>();
                    break;
                case 2:
                    CategorizePlayerList<Goalie>();
                    break;
                case 3:
                    CategorizePlayerList<Forward>();
                    break;
                case 4:
                    CategorizePlayerList<Defender>();
                    break;
                case 5:
                    CategorizePlayerList<Center>();
                    break;
                case 6:
                    CategorizePlayerList<LeftWinger>();
                    break;
                case 7:
                    CategorizePlayerList<RightWinger>();
                    break;
                case 8:
                    CategorizePlayerList<LeftDefensemen>();
                    break;
                case 9:
                    CategorizePlayerList<RightDefensemen>();
                    break;
            }
        }
        public void CategorizePlayerList<T>()
        {
            playerListBox.Items.Clear();
            foreach (object x in playerList.OfType<T>())
            {
                Player p = (Player)x;
                playerListBox.Items.Add(p.ToString());
            }
        }
    }
}
