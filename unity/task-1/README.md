
# Client Engineer Examination: Unity and API Integration
> Created By Muhammad Amir Qushairi Jais & Sharif Tariq

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
