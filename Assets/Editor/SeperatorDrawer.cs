using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SeperatorAttribute))]
public class SeperatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position) {
        // Get a reference to the attribute
        SeperatorAttribute seperateAttribute = attribute as SeperatorAttribute;
        // Define the line to draw
        Rect seperatorRect = new Rect(position.xMin, position.yMin + seperateAttribute.Spacing, position.width, seperateAttribute.Height);
        // Draw it
        EditorGUI.DrawRect(seperatorRect, Color.white);
    }

    public override float GetHeight() {
        SeperatorAttribute seperatorAttribute = attribute as SeperatorAttribute;

        float totalSpacing = seperatorAttribute.Spacing 
            + seperatorAttribute.Height 
            + seperatorAttribute.Spacing;

        return totalSpacing;
    }
}
