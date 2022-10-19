using System;
using System.Collections.Generic;

[Serializable]
public class TextToTranslateData 
{
    public List<TextToTranslate> textToTranslateList { get; set; }
    
    public TextToTranslateData()
    {
        textToTranslateList = new List<TextToTranslate>();

        TextToTranslate textToTranslate = new TextToTranslate();
        textToTranslateList.Add(textToTranslate);
    }
}