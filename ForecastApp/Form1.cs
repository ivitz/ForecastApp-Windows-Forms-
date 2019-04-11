/*
Made by Viktor Ivashchenko
victivitz @gmail.com
+380662697839
*/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForecastApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Load data on app start (form creation), if any
            SaveData.Load();
            cityNameBox.Text = SaveData.Instance.LastCity;
        }        

        //When user clicks Get Result button get the forecast info and display in TextBox below
        private void GetResultsButton_Click(object sender, EventArgs e)
        {            
            string cityName = cityNameBox.Text;

            GetForecast(cityName);         
        }     

        private void GetForecast(string cityName)
        {

            if (cityName != null && cityName.Length > 1)
            {
                //Make the city name start with upper case
                cityName = cityName.First().ToString().ToUpper() + cityName.Substring(1);

                SaveData.Instance.LastCity = cityName;

                //Get the appID for weather API
                string appID = "af3e755e44f732448ba8a5f8c5e3f6a4";

                //Generate the url using city name and appID
                string url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&APPID={appID}";

                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                string response;

                using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    response = reader.ReadToEnd();

                    //Deserialize json response from server
                    ForecastData data = JsonConvert.DeserializeObject<ForecastData>(response);                   

                    resultBox.Text = $"Weather Forecast: {data.ForecastList.First().Weather.First().Main} {Environment.NewLine}Minimum Temperature: {data.ForecastList.First().Main.Temp_min}{Environment.NewLine}Maximum Temperature: {data.ForecastList.First().Main.Temp_max}";                   

                    //Check the data for the city.
                    var cityData = SaveData.Instance.GetCity(cityName) ?? new SaveData.CityData();

                    //Check if the weather in json response is Rain AND if there was no notification already about rain today for the current city
                    if (data.ForecastList.First().Weather.First().Main == "Rain" &&
                        !cityData.RainNotifiedToday())
                    {
                        //Save the date the notification was displayed
                        cityData.LastDateRainNotified = DateTime.Now;
                        ShowNotification(cityName);
                    }

                    //Add the data about the city (city nade and rain notification bool) and save
                    SaveData.Instance.SetCity(cityName, cityData);
                    SaveData.Save();
                }
            }
            else
            {
                resultBox.Text = "Please enter a city name above.";
            }
        }

        /// <summary>
        /// Show pop up windows notification about rain
        /// </summary>
        /// <param name="cityName"></param>
        private void ShowNotification(string cityName)
        {          
            NotifyIcon notification = new NotifyIcon
            {
                Visible = true,
                Icon = SystemIcons.Application,
                BalloonTipTitle = $"Weather Warning",
                BalloonTipText = $"It will be raining in {cityName} today!"
            };
            notification.ShowBalloonTip(150000);            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveData.Save();
            Application.Exit();
        }
    }
}
