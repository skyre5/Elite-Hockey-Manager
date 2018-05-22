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
        List<Player> playerList = new List<Player>();
        public PlayersForm()
        {
            InitializeComponent();
        }
        private void FillPlayerListBox()
        {
            playerListBox.Items.Clear();
            foreach (Player x in playerList)
            {
                playerListBox.Items.Add(x.ToString());
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LeftWinger c = new LeftWinger("John", "Smith", 31);

            Stream stream = File.Open("PlayerData.data", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, c);
            stream.Close();
            Stream stream = File.Open("PlayerData.data", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            RightWinger x = (RightWinger)bf2.Deserialize(stream);
            stream.Close();
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
                Console.WriteLine("Error: invalid tag was entered " + tag);
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
    }
}
