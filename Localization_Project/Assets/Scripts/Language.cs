using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Class to store language data
[System.Serializable]
public class Language : ScriptableObject
{
    public List<WordObject> words;
    public string languageName;
    public string nameToSet;
    public string wordToSet;
    public string keyToSet; 

    //set the language name
    public void setName()
    {
        languageName = nameToSet;
    }

    //create the words list
    public void createWords()
    {
        words = new List<WordObject>();
    }

    //add a new word to the language
    public void addWord()
    {
        WordObject _wordToAdd = new WordObject(keyToSet, wordToSet);
        words.Add(_wordToAdd);
    }

    //remove a word from the language
    public void removeWord(string key)
    {
        for(int i = 0; i < words.Count; i++)
        {
            if(words[i].key == key)
            {
                words.RemoveAt(i);
                break;
            }
        }
    }

    //find a word in the language
    public string findWord(string key)
    {
        foreach(WordObject wordItem in words)
        {
            if(wordItem.key == key)
            {
                return wordItem.value;
            }
        }

        return "Not Found";
    }
}
