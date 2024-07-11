using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Codice.Utils;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{

    private SerializedProperty _typeOfMonster;
     
    private SerializedProperty _name;
    private SerializedProperty _battleCry;
     
    private SerializedProperty _changeToDropItem;
    private SerializedProperty _rangeOfAwareness;
     
    private SerializedProperty _canEnterCombat;
     
    private SerializedProperty _damage;
    private SerializedProperty _health;
    private SerializedProperty _speed;

    private void OnEnable() {
        // Getting data from Monster Data
        _name = serializedObject.FindProperty("_name");
        _battleCry = serializedObject.FindProperty("_battleCry");
        _changeToDropItem = serializedObject.FindProperty("_changeToDropItem");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");
        _damage = serializedObject.FindProperty("_damage");
        _health = serializedObject.FindProperty("_health");
        _speed = serializedObject.FindProperty("_speed");
        _typeOfMonster = serializedObject.FindProperty("_typeOfMonster");
    }

    public override void OnInspectorGUI() {

        MonsterData data = (MonsterData)target;

        string monsterTitleLabel = _name.stringValue.ToUpper() + " - " + _typeOfMonster.stringValue.ToUpper();

        EditorGUILayout.LabelField(monsterTitleLabel.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Difficulty Bar
        float difficulty = _health.intValue + _damage.intValue + _speed.intValue;
        ProgressBar(difficulty / 100, SetDifficultyLevelOnInspector(difficulty));

        // Add before
        
        base.OnInspectorGUI();

        // Redraw with our custom code...

        // Add after

        // Help Box
        if (_name.stringValue == string.Empty) {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the monster!", MessageType.Warning);
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
