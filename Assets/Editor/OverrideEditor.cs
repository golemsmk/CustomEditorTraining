using UnityEditor;
using UnityEngine;
using System.Reflection;

public abstract class OverrideEditor : Editor {

    readonly static BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
    readonly static MethodInfo methodInfo = typeof(Editor).GetMethod("OnHeaderGUI", bindingFlags);

    private Editor m_baseEditor;

    protected Editor baseEditor
    {
        get { return m_baseEditor ?? (m_baseEditor = GetBaseEditor()); }
        set { baseEditor = value; }
    }

    protected abstract Editor GetBaseEditor();

    public override void OnInspectorGUI()
    {
        baseEditor.OnInspectorGUI();
    }
}
