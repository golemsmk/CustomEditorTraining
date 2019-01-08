using UnityEditorInternal;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReoderableListExample))]
public class ReorderableListEditor : Editor {

    ReorderableList localReorderableList;

    void OnEnable()
    {
        var prop = serializedObject.FindProperty("character");
        localReorderableList = new ReorderableList(serializedObject, prop);

        localReorderableList.elementHeight = Mathf.Max(EditorGUIUtility.singleLineHeight*3+4,70);

        localReorderableList.drawElementCallback = (rect, index, isActive, isFocused)
            =>
        {
            var element = prop.GetArrayElementAtIndex(index);
            rect.height -= 4;
            rect.y += 2;
            EditorGUI.PropertyField(rect, element);
        };

        localReorderableList.drawHeaderCallback = (rect) =>
        {
            EditorGUI.LabelField(rect, prop.displayName);
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        localReorderableList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }
}
