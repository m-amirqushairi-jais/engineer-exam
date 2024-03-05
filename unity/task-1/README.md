
# Client Engineer Examination: Unity and API Integration
> Created By Muhammad Amir Qushairi Jais & Sharif Tariq

> Updated By Mohammad Alwi Yahaya

## Task 1: API Integration Scene (Implementation)

1.  **Chosen API:**
    
    -   OpenWeatherMap:  [https://openweathermap.org/api](https://openweathermap.org/api))
    -   Use this API key: 7f3b9e93fc3156d761a240d3b4ac2d38
        
    -   Data 1: Geocoding data:
      
        - Prameters used: zipcode, country code, apikey
          
        - Points used: name (location name), country (country name), lat, lon (used as latitude/longitude parameter to fetch CurrentWeather data) 
  
    -   Data 2: CurrentWeather data:
    
        -   Parameters used: lat, lon, units, apikey
        
        -   Endpoints used: name (location name), main[0] (weather condition, possible for multiple condition), description, humidity, speed(wind speed), temp (temperature)
    
2.  **Unity Scene Setup:**
    
    -   Updated with input fields that require user to enter zip code and country code
    -   Create proper ui flow for requesting api data
    -   Fetched data displayed using TextMeshPro GUI Text
    -   Must get geocoding data first (no interaction flow check implemented)
    
3.  **API Interaction:**
    
    -   Written in a single C# script
    -   If given extra time, would have created input form and include API key encryption method
        
    
4.  **Error Handling:**
    
    -   Implement basic error handling for:
        
        -   Network connectivity issues
        -   Invalid or unexpected API responses (not tested)
     
-------------------------------------------------------------

This examination evaluates your core Unity development skills and the ability to integrate external data sources using APIs.

## Task 1: API Integration Scene

1.  **API Selection:**
    
    -   Choose a simple, freely accessible API that provides data suitable for display in a Unity scene. Some suggestions:
        
        -   Weather API (e.g., OpenWeatherMap:  [https://openweathermap.org/api](https://openweathermap.org/api))
        -   Waktu Solat API ([https://api.waktusolat.app/](https://api.waktusolat.app/))
        -   Public dataset API (e.g., NASA Open APIs:  [https://api.nasa.gov/](https://api.nasa.gov/))
        
    -   **Document your chosen API and endpoint in this README.**
    
2.  **Unity Scene Setup:**
    
    -   Create a new Unity project and scene.
    
3.  **API Interaction:**
    
    -   Write C# scripts to:
        
        -   Fetch data from the selected API endpoint.
        -   Parse the API response into usable data structures.
        -   Display this fetched data in a clear and visually appealing way in your Unity scene.
        
    
4.  **Error Handling:**
    
    -   Implement basic error handling for:
        
        -   Network connectivity issues
        -   API rate limiting or downtime
        -   Invalid or unexpected API responses
        
    

## Extension Task (Bonus)

-   **Local Caching:**
    
    -   Use Unity's PlayerPrefs or a simple data persistence mechanism to store fetched API data. Reduce unnecessary API calls and consider how to handle data updates gracefully.
    
-   **Custom UI Element**
    
    -   Design and implement a custom UI element to enhance the presentation of the fetched data. Consider how it integrates with the overall scene's aesthetics.
    

## Evaluation Criteria

-   **Functionality:** The core task requirements are met, and the scene demonstrates successful API interaction.
-   **Code Quality:** Code is well-organized, readable, and includes meaningful comments where necessary.
-   **API Usage:** Correctly parses API responses and demonstrates understanding of error handling.
-   **Unity Proficiency:** Exhibits good use of Unity components, UI systems, and general Unity workflows.
-   **Extensibility:** Bonus task (if completed) shows sound architectural thinking and a design open to future enhancements.
-   **Communication:** README updates clearly document the chosen API and any design decisions made.
