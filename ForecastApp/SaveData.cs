using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForecastApp
{

    [Serializable]
    public class SaveData
    {
        //Only one instance of SaveData
        public static SaveData Instance { get; set; }
      
        [Serializable]
        public class CityData
        {
            //Store the date of notification about Rain
            public DateTime LastDateRainNotified { get; set; }

            //Compare stored notification date with current date. Return false if there was no notifications today.
            public bool RainNotifiedToday()
            {
                return (LastDateRainNotified.Date.AddDays(1) > DateTime.Now.Date);
            }
        }

        //The last city that was used in search
        public string LastCity { get; set; }

        private Dictionary<string, CityData> Cities { get; set; } = new Dictionary<string, CityData>();

        /// <summary>
        /// Pass the city name to look if it has been already searched for and see about Rain notification
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CityData GetCity(string name)
        {
            name = name?.ToLower();
            return Cities.TryGetValue(name ?? "", out CityData result) ? result : null;
        }

        public bool CityRainNotifiedToday(string name)
        {
            var city = GetCity(name);

            //if city is not null - return true. if null - return false
            return city?.RainNotifiedToday() == true;
        }

        /// <summary>
        /// Add the city to disctionary.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void SetCity(string name, CityData data)
        {
            name = name?.ToLower();
            Cities[name] = data;
        }

        /// <summary>
        /// Use binary serialization to save the data
        /// </summary>
        public static void Save()
        {
            using (FileStream stream = new FileStream(Application.StartupPath + "/SaveData.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(stream, SaveData.Instance);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to save data: " + e.Message);
                    throw;
                }
            }    
        }

        //Load all of the data that was saved, if any
        public static void Load()
        {
            if (File.Exists(Application.StartupPath + "/SaveData.dat"))
            {
                using (FileStream stream = new FileStream(Application.StartupPath + "/SaveData.dat", FileMode.OpenOrCreate))
                {
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();

                        //Deserialize the data to this instance
                        Instance = (SaveData)formatter.Deserialize(stream);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed to load data: " + e.Message);
                        throw;
                    }
                }
            }
            else
            {
                //If there was no previous save data - make a new SaveData static instance
                Instance = new SaveData();
            }
        }
    }
}
