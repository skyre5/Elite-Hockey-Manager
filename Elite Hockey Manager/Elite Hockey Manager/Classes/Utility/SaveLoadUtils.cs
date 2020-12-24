using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Elite_Hockey_Manager.Classes
{
    public static class SaveLoadUtils
    {
        #region Methods

        /// <summary>
        /// Loads a serialized file into a league object to be loaded into game
        /// </summary>
        /// <param name="leagueName">name of the league to load from a file</param>
        /// <param name="saveName">name of the save from the league to be loaded</param>
        /// <returns>The league object or null if failed</returns>
        public static League LoadLeague(string leagueName, string saveName)
        {
            League returnLeague;
            string filePathName = $@"Files\Saves\{leagueName}\{saveName}";
            if (File.Exists(filePathName))
            {
                try
                {
                    Stream leagueStream = File.Open(filePathName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    returnLeague = (League)bf.Deserialize(leagueStream);
                    leagueStream.Close();
                    return returnLeague;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Loads a BindingList of type t from a serialized file
        /// </summary>
        /// <typeparam name="T">type of binding list</typeparam>
        /// <param name="fileName">file name</param>
        /// <param name="bindingList">out binding list</param>
        /// <returns>Whether the load was successful</returns>
        public static bool LoadListToFile<T>(string fileName, out BindingList<T> bindingList)
        {
            //Loads the file of the given name if it is found
            if (File.Exists(fileName))
            {
                Stream playersStream;
                try
                {
                    playersStream = File.Open(fileName, FileMode.Open);
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
                    playersStream = null;
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

        /// <summary>
        /// Loads a list of strings in a text document into a list of strings
        /// </summary>
        /// <param name="filePathAndName">the file path with file name to the desired file</param>
        /// <returns>List of line separated strings from file</returns>
        public static List<string> ReadFromFile(string filePathAndName)
        {
            List<string> list = new List<string>();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePathAndName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (reader != null)
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }

                reader.Close();

                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Saves a league into a file in the files\saves folder of the project
        /// </summary>
        /// <param name="league">league object in its most current state</param>
        /// <param name="autosave">whether the save is done automatically or by user input</param>
        /// <returns>Whether the save worked successfully</returns>
        public static bool SaveLeague(League league, bool autosave = false)
        {
            // Creates a directory for the saves if one does not exist
            Directory.CreateDirectory(@"Files\Saves\");

            // Creates a folder for saves of this league if one does not already exist
            Directory.CreateDirectory($@"Files\Saves\{league.LeagueName}");

            // Tries to save the league under a file in the saves folder with the leagues name as its file name
            // Will overwrite any existing prior save
            try
            {
                using (Stream leagueStream = File.Open($@"Files\Saves\{league.LeagueName}\{league.SaveStateName}.save", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(leagueStream, league);
                    leagueStream.Close();
                    return true;
                }
            }
            // If fails, gives user error in console and returns false so save failed
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// <summary>
        /// Saves a BindingList of type T to a file by serializing
        /// </summary>
        /// <typeparam name="T">Type of binding list</typeparam>
        /// <param name="fileName">The desired file name</param>
        /// <param name="bindingList">BindingList object</param>
        /// <returns>Whether the save was successful</returns>
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

        #endregion Methods
    }
}