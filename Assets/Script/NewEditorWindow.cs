using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

public class NewEditorWindow : EditorWindow {

    [MenuItem("Window/Example")]
	static void Open()
    {
        GetWindow<NewEditorWindow>(typeof(SceneView));
    }

    List<Object> targetObject;
    float angle = 0;
    bool one, two, three;
    int selector;

    void OnEnable()
    {
        targetObject = new List<Object>();
    }

    void OnGUI()
    {
        int max = targetObject.Count;
        if (Event.current.type == EventType.Repaint)
        {
            if (max == 0 || targetObject[max - 1] != null)
            {
                targetObject.Add(null);

            }
        }
        EditorGUILayout.BeginHorizontal();
        GUILayoutOption[] option = new[] { GUILayout.Width(120) };
        angle = EditorGUILayout.Knob(Vector2.one * 64, Mathf.Clamp(max-1,0,100), 0, 100, "% capability", Color.gray, Color.green, true, option);
        EditorGUILayout.BeginVertical();
        for (int i = 0; i<max; )
        {
            targetObject[i] = EditorGUILayout.ObjectField(targetObject[i], typeof(GameObject), false);
            if (targetObject[i]==null&&i<max-1)
            {
                targetObject.RemoveAt(i);
                max--;
            } else
            {
                i++;
            }
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        using (new EditorGUILayout.HorizontalScope())
        {
            one = GUILayout.Toggle(one, "Button 1", EditorStyles.miniButtonLeft);
            two = GUILayout.Toggle(two, "Button 2", EditorStyles.miniButtonMid);
            three = GUILayout.Toggle(three, "Button 3", EditorStyles.miniButtonRight);
        }
        selector = GUILayout.SelectionGrid(selector, new string[] { "1", "2", "3" }, 1, "PreferencesKeysElement", GUILayout.Width(50));
    }
}
