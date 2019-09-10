using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySelect : MonoBehaviour
{
    public Language currentLanguage;
    public string key;

    public void setCurrentLanguage()
    {

        SelectedLanguage s = Resources.Load<SelectedLanguage>("SelectedLanguage");
        currentLanguage = s.currentLanguage;
    }

    public WordObject[] getWords()
    {

        return currentLanguage.words.ToArray();
    }

    public void Start()
    {
        for(int i = 0; i < currentLanguage.words.Count; i++)
        {
            if(key == currentLanguage.words[i].key)
            {
                this.gameObject.GetComponent<Text>().text = currentLanguage.words[i].value;
                break;
            }
        }
    }

}
