using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StoreTextInput : MonoBehaviour
{
    public WeatherMapMain MyWeatherMap;
    public TMP_InputField myInputField;

    public void SendZipText()
    {
        String myString = myInputField.text;
        MyWeatherMap.AssignZipCode(myString);
    }

    public void SendCountryText()
    {
        String myString = myInputField.text;
        MyWeatherMap.AssignCountryCode(myString);
    }
}
