using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEditorAttributes {
    public enum EColor {
        White,
        Black,
        Green,
        Violet
    }

    public static class EColorExtensions {

        public static Color GetColor(this EColor color) {
            switch (color) {
                case EColor.White: return new Color32(255, 255, 255, 255);
                case EColor.Black: return new Color32(0, 0, 0, 255);
                case EColor.Green: return new Color32(98, 200, 79, 255);
                case EColor.Violet: return new Color32(128, 0, 255, 255);
                default: return new Color32(0, 0, 0, 255);
            }
        }
    }
}
