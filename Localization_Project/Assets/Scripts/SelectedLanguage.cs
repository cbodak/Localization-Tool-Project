using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedLanguage : ScriptableObject
{

    public Language currentLanguage;

    public void languageSelect(Language current)
    {
        currentLanguage = current;
    }

}
