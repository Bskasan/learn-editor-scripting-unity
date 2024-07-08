using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        ProgressBar(difficulty / 100, "Difficulty");

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


    // Progress Bar...
    private void ProgressBar(float value, string label) {

        Rect rect = GUILayoutUtility.GetRect(18, 30, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }
}
