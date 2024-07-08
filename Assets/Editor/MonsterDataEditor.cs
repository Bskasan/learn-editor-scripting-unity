using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    public override void OnInspectorGUI() {

        MonsterData data = (MonsterData)target;

        EditorGUILayout.LabelField(data.Name.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Difficulty Bar
        float difficulty = data.Health + data.Damage + data.Speed;
        ProgressBar(difficulty / 100, "Difficulty");

        // Add before
        base.OnInspectorGUI();

        // Add after

        

    }

    private void ProgressBar(float value, string label) {

        Rect rect = GUILayoutUtility.GetRect(18, 30, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }
}
