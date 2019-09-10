using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class customEditor : EditorWindow {
    string addString = "";
    string removeString = "";
    string languageToAdd;

    //Create a menu item to open the edit languages window
    [MenuItem("Window/Edit Languages")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(customEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Current Language: ", EditorStyles.boldLabel);
        Editor languageEdit = null;
        SelectedLanguage[] l1 = Resources.FindObjectsOfTypeAll<SelectedLanguage>();
        Language current = l1[0].currentLanguage;
        languageEdit = Editor.CreateEditor(current);
        languageEdit.OnInspectorGUI();

        //Add a new key to all languages
        GUILayout.Label("Add Key", EditorStyles.boldLabel);
        addString = EditorGUILayout.TextField("Key: ", addString);
        if(GUILayout.Button("Add Key"))
        {
            Language[] languages = Resources.FindObjectsOfTypeAll<Language>();
            for(int i = 0; i < languages.Length; i++)
            {
                languages[i].keyToSet = addString;
                languages[i].wordToSet = "test";
                languages[i].addWord();
                EditorUtility.SetDirty(languages[i]);
            }
            AssetDatabase.SaveAssets();
            
        }

        //Remove a key from all languages
        GUILayout.Label("Remove Key", EditorStyles.boldLabel);
        removeString = EditorGUILayout.TextField("Key: ", removeString);
        if (GUILayout.Button("Remove Key"))
        {
            Language[] languages = Resources.FindObjectsOfTypeAll<Language>();
            for (int i = 0; i < languages.Length; i++)
            {
                languages[i].removeWord(removeString);
            }
            AssetDatabase.SaveAssets();

        }

        //Add a new language
        GUILayout.Label("Add Language", EditorStyles.boldLabel);
        languageToAdd = EditorGUILayout.TextField("Language Name: ", languageToAdd);
        if (GUILayout.Button("Add Language"))
        {
            Language createdLanguage = (Language)ScriptableObject.CreateInstance<Language>();
            createdLanguage.createWords();
            createdLanguage.nameToSet = languageToAdd;
            createdLanguage.setName();
            Language[] existingLanguage = Resources.FindObjectsOfTypeAll<Language>();
            Debug.Log("Languages count: " + existingLanguage.Length);
            if (existingLanguage.Length > 0)
            {
                Debug.Log("Hello");
                Debug.Log(existingLanguage[0].words.Count);
                for (int i = 0; i < existingLanguage[1].words.Count; i++)
                {
                    Debug.Log("Hello2");
                    createdLanguage.keyToSet = existingLanguage[1].words[i].key;
                    createdLanguage.wordToSet = "";
                    createdLanguage.addWord();
                }
            }
            //Create a new asset for the created language
            AssetDatabase.CreateAsset(createdLanguage, "Assets/Languages/" + languageToAdd + ".asset");

            //Save changes
            AssetDatabase.SaveAssets();
            EditorUtility.SetDirty(createdLanguage);
        }
    }
}
