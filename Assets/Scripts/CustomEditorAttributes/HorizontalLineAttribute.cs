using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEditorAttributes {

    [AttributeUsage(AttributeTargets.Field, Inherited = true)]
    public class HorizontalLineAttribute : PropertyAttribute {

        // Default Line Height
        public const float DEFAULT_HEIGHT = 1.0f;

        // A compile-time constant is required, so Unity's built-in Color type can't be used.
        public const EColor DEFAULT_COLOR = EColor.Green;

        // Public auto-proeperties for height and color
        public float Height { get; private set; }
        public EColor Color { get; private set; }

        // Constructor to set height and color via attributes
        public HorizontalLineAttribute(float height = DEFAULT_HEIGHT, EColor color = DEFAULT_COLOR) {
            Height = height;
            Color = color;
        }
    }
}
