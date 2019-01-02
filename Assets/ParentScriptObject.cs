using UnityEngine;
using UnityEditor;
public class ParentScriptObject : ScriptableObject {

    const string PATH = "Assets/Editor/New ParentScriptObject.asset";

    [SerializeField]
    ChildScriptObject child;

    [MenuItem("Assets/Create Scriptable Object")]
    static void CreateScriptableObject()
    {
        ParentScriptObject parent = ScriptableObject.CreateInstance<ParentScriptObject>();
        parent.child = ScriptableObject.CreateInstance<ChildScriptObject>();
        parent.child.name = "ChildScriptableObject";
        AssetDatabase.AddObjectToAsset(parent.child, PATH);

        AssetDatabase.CreateAsset(parent, PATH);
        AssetDatabase.ImportAsset(PATH);
    }
}
