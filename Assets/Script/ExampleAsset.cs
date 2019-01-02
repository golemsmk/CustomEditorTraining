using UnityEditor;
using UnityEngine;

public class ExampleAsset : ScriptableObject {

    public int highFive;

    [MenuItem("CustomMenu/Example/Child1 %#j")]
    static void Create()
    {
        var exampleObject = ScriptableObject.CreateInstance<ExampleAsset>();
        AssetDatabase.CreateAsset(exampleObject, "Assets/Example Asset.asset");
        AssetDatabase.Refresh();
    }
}
