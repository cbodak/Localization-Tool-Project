using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to store key value pair object to use for words
[System.Serializable]
public class WordObject
{

    public string key;
    public string value;

    public WordObject(string _key, string _value)
    {
        key = _key;
        value = _value;
    }

}
