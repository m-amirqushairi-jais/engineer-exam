using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;

/*
OPENWEATHERMAP REFERENCE
-------------------------
web request reference for GeoCoding: get latitude, longitude and city name based on zip and country code
http://api.openweathermap.org/geo/1.0/zip?zip={zip code},{country code}&appid={API key}

web request reference for Current Weather Data: get all weather data based on given latitude and longitude
https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}
*/

public class WeatherMapMain : MonoBehaviour
{
    // Replace 'YOUR_API_KEY' with your actual OpenWeatherMap API key
    [SerializeField]
    private string apiKey = "Enter your OpenWeatherMap API key";
    private const string geoApiUrl = "http://api.openweathermap.org/geo/1.0/zip";
    private const string weatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";

    
    
    public GeoCodeData MyGeoCodeData;

    [Tooltip("eg: 81550")]
    public string zipCode;
    [Tooltip("eg: MY")]
    public string countryCode;

    public TextMeshProUGUI tmpTextGUI_geoData;
    public TextMeshProUGUI tmpTextGUI_weatherData;

    void Start()
    {
        
    }

    public void AssignZipCode(String z)
    {
        zipCode = z;
    }

    public void AssignCountryCode(String c)
    {
        countryCode = c;
    }

    public void SubmitRequestGeoData()
    {
        StartCoroutine(GetGeoCodeData());
    }

    public void SubmitRequestWeatherData()
    {
        StartCoroutine(GetWeatherData());
    }

    IEnumerator GetGeoCodeData()
    {
        string url = $"{geoApiUrl}?zip={zipCode},{countryCode}&appid={apiKey}";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                tmpTextGUI_geoData.text = webRequest.error;
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                // Parse the JSON response
                string json = webRequest.downloadHandler.text;
                MyGeoCodeData = JsonUtility.FromJson<GeoCodeData>(json);

                tmpTextGUI_geoData.text = "Zip Code: " + MyGeoCodeData.zip +
                    "\nLocation: " + MyGeoCodeData.name +
                    "\nLatitude: " + MyGeoCodeData.lat +
                    "\nLongitude: " + MyGeoCodeData.lon +
                    "\nCountry: " + MyGeoCodeData.country;
            }
        }
    }

    IEnumerator GetWeatherData()
    {
        string url = $"{weatherApiUrl}?lat={MyGeoCodeData.lat}&lon={MyGeoCodeData.lon}&appid={apiKey}&units=metric";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                tmpTextGUI_weatherData.text = webRequest.error;
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                // Parse the JSON response
                string json = webRequest.downloadHandler.text;
                WeatherData MyWeatherData = JsonUtility.FromJson<WeatherData>(json);

                // Access the weather data as needed                
                tmpTextGUI_weatherData.text = "Location: " + MyGeoCodeData.name +
                    "\nWeather: " + MyWeatherData.weather[0].main +
                    "\nDescription: " + MyWeatherData.weather[0].description +
                    "\nTemperature: " + MyWeatherData.main.temp +
                    "\nHumidity: " + MyWeatherData.main.humidity +
                    "\nWind Spd: " + MyWeatherData.wind.speed;
            }
        }
    }

    [System.Serializable]
    public class GeoCodeData
    {
        public string zip;
        public string name;
        public float lat;
        public float lon;
        public string country;
    }

    // Define a class to represent the structure of the JSON response
    [System.Serializable]
    public class WeatherData
    {
        public Main main;
        public Weather [] weather;
        public Wind wind;
    }

    [System.Serializable]
    public class Clouds
    {
        public int all;
    }

    [System.Serializable]
    public class Coord
    {
        public double lon;
        public double lat;
    }

    [System.Serializable]
    public class Main
    {
        public double temp;
        public double feels_like;
        public double temp_min;
        public double temp_max;
        public int pressure;
        public int humidity;
        public int sea_level;
        public int grnd_level;
    }

    [System.Serializable]
    public class Root
    {
        public Coord coord;
        public List<Weather> weather;
        public string @base;
        public Main main;
        public int visibility;
        public Wind wind;
        public Clouds clouds;
        public int dt;
        public Sys sys;
        public int timezone;
        public int id;
        public string name;
        public int cod;
    }

    [System.Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public int sunrise;
        public int sunset;
    }

    [System.Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    [System.Serializable]
    public class Wind
    {
        public double speed;
        public int deg;
        public double gust;
    }
}
