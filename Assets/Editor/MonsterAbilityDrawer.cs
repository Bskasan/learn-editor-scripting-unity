using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MonsterAbility))]
public class MonsterAbilityDrawer : PropertyDrawer
{
    // ...Property Drawing...

    private SerializedProperty _name;
    private SerializedProperty _damage;
    private SerializedProperty _elmement;

    // How to draw to the Inspector window.
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        EditorGUI.BeginProperty(position, label, property);

        // Drawing instructions here...

        // Potential Rectangle on Inspector.
        Rect foldOutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);

        EditorGUI.EndProperty();
        
    }

    // Request more vertical spacing, return it..
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

        int totalLines = 1;

        float lineHeight = EditorGUIUtility.singleLineHeight; // Height of a single line..

        // Increase our height if we expand arrow
        if (property.isExpanded) {
            totalLines += 3;
        }


        return (EditorGUIUtility.singleLineHeight * totalLines);
    }

}
