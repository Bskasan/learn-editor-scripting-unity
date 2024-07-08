using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Codice.Utils;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    public override void OnInspectorGUI() {

        MonsterData data = (MonsterData)target;

        string monsterTitleLabel = data.Name + " - " + data.TypeOfMonster;

        EditorGUILayout.LabelField(monsterTitleLabel.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Difficulty Bar
        float difficulty = data.Health + data.Damage + data.Speed;
        ProgressBar(difficulty / 100, SetDifficultyLevelOnInspector(difficulty));

        // Add before
        base.OnInspectorGUI();

        // Add after

        // Help Box
        if (data.Name == string.Empty) {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the monster!", MessageType.Warning);
        }

        if (data.TypeOfMonster == MonsterType.None) {
            EditorGUILayout.HelpBox("No Monster type selected!", MessageType.Warning);
        }

        if (data.Health <= 0) {
            EditorGUILayout.HelpBox("Shouldn't have a negative value for health!", MessageType.Warning);
        }

        
    }

    public string SetDifficultyLevelOnInspector(float value) {

        if (value <= 25) {
            return "Beginner Level";
        } else if (value > 25 && value <= 75) {
            return "Medium Level";
        } else {
            return "Hard - Boss Character";
        }

        return null;
    }


    // Progress Bar...
    private void ProgressBar(float value, string label) {

        Rect rect = GUILayoutUtility.GetRect(18, 30, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }
}
