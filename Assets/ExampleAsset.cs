using UnityEditor;
using UnityEngine;

public class ExampleAsset : ScriptableObject {

    [MenuItem("Tetsing Scriptable Object/Data type 01")]
	static void CreateExampleAssetInstance()
    {
        ExampleAsset exampleAsset = CreateInstance<ExampleAsset>();

        AssetDatabase.CreateAsset(exampleAsset, "Assets/Editor/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }


}
