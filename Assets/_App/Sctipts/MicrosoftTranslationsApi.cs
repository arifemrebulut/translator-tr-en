using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MicrosoftTranslationsApi : MonoBehaviour
{
    HttpClient client;
    HttpRequestMessage request;

    public MicrosoftTranslationsApi()
    {
        client = new HttpClient();
        request = new HttpRequestMessage();
    }

    private async Task<string> GenerateRequest(string text, string languageToTranslate)
    {
        // Body
        TextToTranslateData textToTranslateData = new TextToTranslateData();
        TextToTranslate textToTranslate = textToTranslateData.textToTranslateList[0];
        textToTranslate.Text = text;

        string jsonFromObject = JsonConvert.SerializeObject(textToTranslateData.textToTranslateList, Formatting.Indented);
        var body = jsonFromObject;

        // Query Paramaters
        var query = new Dictionary<string, string>()
        {
            { "to", languageToTranslate },
            { Constants.API_VERSION_NAME, Constants.API_VERSION_VALUE }
        };

        request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(Utils.GetUriWithQueryString(Constants.URL, query)),
            Headers =
            {
                { Constants.API_KEY_NAME, Constants.API_KEY_VALUE },
                { Constants.HOST_NAME, Constants.HOST_VALUE },
            },
            Content = new StringContent(body, Encoding.UTF8)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue(Constants.CONTENT_TYPE_VALUE)
                },
            }
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            TranslationResponseData translationResponseData = new TranslationResponseData();
            translationResponseData.translatedTextDataList = JsonConvert.DeserializeObject<List<TranslatedTextData>>(content);

            return translationResponseData.translatedTextDataList[0].translations[0].text;
        }
    }
}
