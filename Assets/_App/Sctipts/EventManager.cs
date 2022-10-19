using System;

public static class EventManager 
{
    public static Action<string, string> TranslateEvent;
    public static Action<string> TextTranslatedEvent;

    public static void CallTranslateEvent(string textToTranslate, string targetLanguage) => TranslateEvent?.Invoke(textToTranslate, targetLanguage);
    public static void CallTextTranslatedEvent(string translatedText) => TextTranslatedEvent?.Invoke(translatedText);
}
