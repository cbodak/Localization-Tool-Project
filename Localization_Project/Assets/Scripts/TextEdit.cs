using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEdit
{

    public Text theText;
    public Language currentLanguage;
    public Language resultLanguage;

    //translate text by converting to the key and then converting from the result languages key to its value
    public void changeText()
    {

        string wordText = theText.text;
        string[] textArray = wordText.Split(' ');
        theText.text = "";
        for(int i = 0; i < textArray.Length; i++)
        {
            foreach (WordObject currentWord in currentLanguage.words)
            {
                if(textArray[i] == currentWord.value)
                {
                    textArray[i] = currentWord.key;
                }
            }
        }

        for (int j = 0; j < textArray.Length; j++)
        {
            foreach (WordObject translatedWord in resultLanguage.words)
            {
                if (textArray[j] == translatedWord.key)
                {
                    textArray[j] = translatedWord.value;
                    theText.text += textArray[j] + " ";
                }
            }
        }
    }

    public void translateRunTime()
    {
        Language[] languages = Resources.FindObjectsOfTypeAll<Language>();
        Debug.Log(languages.Length);
        Language existingLanguage = (Language)ScriptableObject.CreateInstance<Language>();

        for (int i = 0; i < languages.Length; i++)
        {
            Debug.Log(languages.Length);
            foreach(WordObject w in languages[i].words)
            {
                Debug.Log("Working1");
                if(theText.text == w.value)
                {
                    Debug.Log("Working");
                    existingLanguage = languages[i];
                    break;
                }
            }
        }

        currentLanguage = existingLanguage;
        changeText();
    }
}
