using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class TranslationEditor : EditorWindow
{
    TextEdit edit = new TextEdit();

    [MenuItem("Window/Translate Text")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TranslationEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Translate Text", EditorStyles.boldLabel);
        edit.theText = (Text)EditorGUILayout.ObjectField("Text to Modify: ", edit.theText, typeof(Text), true);
        edit.currentLanguage = (Language)EditorGUILayout.ObjectField("Current Language: ", edit.currentLanguage, typeof(Language), true);
        edit.resultLanguage = (Language)EditorGUILayout.ObjectField("Language to Translate to: ", edit.resultLanguage, typeof(Language), true);
        if (GUILayout.Button("Translate Text"))
        {
            edit.changeText();
        }

        GUILayout.Label("Set Current Language", EditorStyles.boldLabel);
        edit.resultLanguage = (Language)EditorGUILayout.ObjectField("Current Language: ", edit.resultLanguage, typeof(Language), true);
        
        if (GUILayout.Button("Set Languages"))
        {
            //edit.changeText();
            SelectedLanguage[] l1 = Resources.FindObjectsOfTypeAll<SelectedLanguage>();
            SelectedLanguage l;
            if (l1.Length < 1)
            {
                l = (SelectedLanguage)ScriptableObject.CreateInstance<SelectedLanguage>();
                AssetDatabase.CreateAsset(l, "Assets/Languages/SelectedLanguage.asset");
            }

            else
            {
                l = l1[0];
            }

            l.languageSelect(edit.resultLanguage);
            EditorUtility.SetDirty(l);
            AssetDatabase.SaveAssets();
        }

    }
}