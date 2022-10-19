using System;

[Serializable]
public class TranslatedTextData
{
    public DetectedLanguage detectedLanguage { get; set; }
    public Translation[] translations { get; set; }
}
