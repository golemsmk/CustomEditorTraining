using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Character))]
public class CharacterDrawer : PropertyDrawer {

    //private Character character;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            EditorGUIUtility.labelWidth = 50;

            position.height = EditorGUIUtility.singleLineHeight;

            float halfWidth = position.width * 0.5f;

            Rect iconRect = new Rect(position)
            {
                width = 64,
                height = 64,
            };

            Rect nameRect = new Rect(position)
            {
                x = position.x + 64,
                width = position.width - 64,
            };

            Rect hpRect = new Rect(nameRect)
            {
                y = nameRect.y + EditorGUIUtility.singleLineHeight + 2,
            };

            Rect strRect = new Rect(hpRect)
            {
                y = hpRect.y + EditorGUIUtility.singleLineHeight + 2,
            };

            SerializedProperty iconProperty = property.FindPropertyRelative("icon");
            SerializedProperty nameProperty = property.FindPropertyRelative("name");
            SerializedProperty hpProperty = property.FindPropertyRelative("hp");
            SerializedProperty strProperty = property.FindPropertyRelative("str");

            iconProperty.objectReferenceValue = EditorGUI.ObjectField(iconRect, iconProperty.objectReferenceValue, typeof(Texture), false);
            nameProperty.stringValue = EditorGUI.TextField(nameRect, nameProperty.displayName, nameProperty.stringValue);
            hpProperty.intValue = EditorGUI.IntSlider(hpRect, hpProperty.displayName, hpProperty.intValue, 0, 100);
            strProperty.intValue = EditorGUI.IntSlider(strRect, strProperty.displayName, strProperty.intValue, 0, 20);
        }

    }

}
