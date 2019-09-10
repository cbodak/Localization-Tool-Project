using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(KeySelect))]
public class KeySelectEditor : Editor {

    int newIndex = 0;
    public override void OnInspectorGUI()
    {
        KeySelect myKeySelect = (KeySelect)target;
        myKeySelect.setCurrentLanguage();
        WordObject[] words = myKeySelect.getWords();
        string[] keys = words.Select(x => x.key).ToArray();
        string[] values = words.Select(x => x.value).ToArray();

        newIndex = EditorGUILayout.Popup("Select Key: ", newIndex, keys, EditorStyles.popup);
       
        // set the key to ""
        myKeySelect.key = keys[newIndex];
    }

}
