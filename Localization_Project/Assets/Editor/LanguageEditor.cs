using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Language))]
public class LanguageEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Language myLanguage = (Language)target;

        EditorGUI.BeginChangeCheck();
        //set the name stored in nameToSet based on the text field input
        myLanguage.nameToSet = EditorGUILayout.TextField("Language Name", myLanguage.nameToSet);
        //display the name
        EditorGUILayout.LabelField("Name: ", myLanguage.languageName);

        //button to edit the name of the language
        if (GUILayout.Button("Edit Name"))
        {
            myLanguage.setName();
        }

        //display the existing words (showing key and value) and allow editing of value
        EditorGUILayout.LabelField("Existing Words");
        for (int i = 0; i < myLanguage.words.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(myLanguage.words[i].key);
            myLanguage.words[i].value = EditorGUILayout.TextField("Value: ", myLanguage.words[i].value);
            EditorGUILayout.EndHorizontal();
        }

        //save any changes
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(myLanguage);

            AssetDatabase.SaveAssets();
        }
        }

}
