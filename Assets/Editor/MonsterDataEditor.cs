using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Codice.Utils;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor {

    private SerializedProperty _typeOfMonster;

    private SerializedProperty _name;
    private SerializedProperty _battleCry;
    private SerializedProperty _abilities;

    private SerializedProperty _chanceToDropItem;
    private SerializedProperty _rangeOfAwareness;

    private SerializedProperty _canEnterCombat;

    private SerializedProperty _damage;
    private SerializedProperty _health;
    private SerializedProperty _speed;

    private void OnEnable() {
        // Getting data from Monster Data
        _name = serializedObject.FindProperty("_name");
        _battleCry = serializedObject.FindProperty("_battleCry");
        _chanceToDropItem = serializedObject.FindProperty("_chanceToDropItem");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");
        _damage = serializedObject.FindProperty("_damage");
        _health = serializedObject.FindProperty("_health");
        _speed = serializedObject.FindProperty("_speed");
        _typeOfMonster = serializedObject.FindProperty("_typeOfMonster");
        _abilities = serializedObject.FindProperty("_abilities");
    }

    public override void OnInspectorGUI() {

        // -----------------------------------
        // Update if we make a change...
        serializedObject.UpdateIfRequiredOrScript();
        // -----------------------------------

        MonsterData data = (MonsterData)target;

        string monsterTitleLabel = _name.stringValue.ToUpper();

        EditorGUILayout.LabelField(monsterTitleLabel.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Difficulty Bar
        float difficulty = _health.intValue + _damage.intValue + _speed.intValue;
        ProgressBar(difficulty / 100, SetDifficultyLevelOnInspector(difficulty));

        // Add before

        // base.OnInspectorGUI();

        // -----------------------------------
        // Redraw with our custom code... 
        // Custom GUI --- Our Version 0.001
        EditorGUILayout.LabelField("General Stats", EditorStyles.boldLabel);
        EditorGUILayout.Space(10);
        EditorGUILayout.PropertyField(_name, new GUIContent("Name"));
        EditorGUILayout.PropertyField(_typeOfMonster, new GUIContent("Monster Type"));
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Item Drop Chance : ");

        // Slider with float value.
        _chanceToDropItem.floatValue = EditorGUILayout.Slider(_chanceToDropItem.floatValue, 0, 100);

        EditorGUILayout.PropertyField(_rangeOfAwareness, new GUIContent("Awareness"));
        EditorGUILayout.PropertyField(_canEnterCombat, new GUIContent("Can Enter Combat?"));

        // If Monster can enter the combat, show properties...
        EditorGUILayout.Space(10);
        if (_canEnterCombat.boolValue == true) {
            EditorGUI.indentLevel++;

            EditorGUILayout.LabelField("Combat Stats", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 70;
            EditorGUILayout.PropertyField(_health, new GUIContent("Health"));
            EditorGUILayout.PropertyField(_damage, new GUIContent("Damage"));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(10);

            if (_health.intValue <= 0) {
                EditorGUILayout.HelpBox("Shouldn't have a negative value for health!", MessageType.Warning);
            }


            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 70;
            EditorGUILayout.PropertyField(_speed, new GUIContent("Speed"));

            if (GUILayout.Button("Random Stats")) {
                RandomizeStats();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogue", EditorStyles.boldLabel);
        EditorGUILayout.Space(20);
        EditorGUILayout.PropertyField(_battleCry, new GUIContent("Battle Cry"));
        EditorGUILayout.PropertyField(_abilities, new GUIContent("Abilities"));


        // -----------------------------------


        // Add after

        // Help Box
        if (_name.stringValue == string.Empty) {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the monster!", MessageType.Warning);
        }


        

        // -----------------------------------
        // Apply these changes that we made...
        serializedObject.ApplyModifiedProperties();
        // -----------------------------------

    }

    public string SetDifficultyLevelOnInspector(float value) {

        if (value <= 25) {
            return "Beginner Level";
        } else if (value > 25 && value <= 75) {
            return "Medium Level";
        } else {
            return "Hard - Boss Character";
        }

    }


    // Progress Bar...
    private void ProgressBar(float value, string label) {

        Rect rect = GUILayoutUtility.GetRect(18, 30, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }

    private void RandomizeStats() {
        _damage.intValue = Random.Range(1, 50);
        _health.intValue = Random.Range(1, 100);
        _speed.intValue = Random.Range(1, 30);
    }
}