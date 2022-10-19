using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public const string URL = "https://microsoft-translator-text.p.rapidapi.com/translate";

    public const string API_KEY_NAME = "X-RapidAPI-Key";
    public const string API_KEY_VALUE = "YOUR_RAPID_API_MICROSOFT_TRANSLATOR_API";

    public const string HOST_NAME = "X-RapidAPI-Host";
    public const string HOST_VALUE = "microsoft-translator-text.p.rapidapi.com";

    public const string CONTENT_TYPE_NAME = "content-type";
    public const string CONTENT_TYPE_VALUE = "application/json";

    public const string API_VERSION_NAME = "api-version";
    public const string API_VERSION_VALUE = "3.0";
}
