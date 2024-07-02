using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CustomEditorAttributes {
    // Specify the property {attribute} to draw
    [CustomPropertyDrawer(typeof(HorizontalLineAttribute))]
    public class HorizontalLineDecoratorDrawer : DecoratorDrawer {

        // Override the default GetHeight method to increase the space between previous and next
        public override float GetHeight() {
            HorizontalLineAttribute lineAttr = (HorizontalLineAttribute)attribute;
            return EditorGUIUtility.singleLineHeight + lineAttr.Height;
        }

        // Override the OnGUI method to draw the line
        public override void OnGUI(Rect position) {
            // Create the editor rect, set the position, and get the attribute data.
            Rect rect = EditorGUI.IndentedRect(position);
            rect.y += EditorGUIUtility.singleLineHeight ;
            HorizontalLineAttribute lineAttr = (HorizontalLineAttribute)attribute;

            // Draw the line in the chosen color using the attribute data.
            rect.height = lineAttr.Height;
            EditorGUI.DrawRect(rect, lineAttr.Color.GetColor());
        }
    }
}

