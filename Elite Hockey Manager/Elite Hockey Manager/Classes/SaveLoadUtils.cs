using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Hockey_Manager.Classes
{
    public static class SaveLoadUtils
    {
        public static bool SavePlayersToFile(string fileName, BindingList<Player> playerList)
        {
            try
            {
                //Saves the contents of the playerList into a data file
                //Creates it if one did not exist
                Stream playersStream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(playersStream, playerList);
                playersStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public static bool LoadPlayersToFile(string fileName, out BindingList<Player> playerList)
        {
            //Loads the user created players if they are found
            if (File.Exists(fileName))
            {
                try
                {
                    Stream playersStream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    //Takes the list of players and deserializes it into playerList class object
                    playerList = (BindingList<Player>)bf.Deserialize(playersStream);
                    playersStream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    playerList = new BindingList<Player>();
                    return false;
                }
            }
            else
            {
                //If no playerList exists makes a new one
                playerList = new BindingList<Player>();
                return true;
            }
        }
    }
}
