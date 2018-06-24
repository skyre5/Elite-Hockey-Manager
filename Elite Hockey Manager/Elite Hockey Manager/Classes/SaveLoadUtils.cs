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
        public static bool SaveListToFile<T>(string fileName, BindingList<T> bindingList)
        {
            try
            {
                //Saves the contents of the playerList into a data file
                //Creates it if one did not exist
                Stream playersStream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(playersStream, bindingList);
                playersStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public static bool LoadListToFile<T>(string fileName, out BindingList<T> bindingList)
        {
            //Loads the file of the given name if it is found
            if (File.Exists(fileName))
            {
                try
                {
                    Stream playersStream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    //Takes the list of players and deserializes it into playerList class object
                    bindingList = (BindingList<T>)bf.Deserialize(playersStream);
                    playersStream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    bindingList = new BindingList<T>();
                    return false;
                }
            }
            else
            {
                //If no playerList exists makes a new one
                bindingList = new BindingList<T>();
                return true;
            }
        }
    }
}
