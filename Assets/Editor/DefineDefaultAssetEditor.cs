using UnityEngine;
using UnityEditor;

[CustomAsset(".zip")]
public class ZipInspector : Editor {

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Anything to do with this zip file");
    }
}

[CustomAsset(".xlsx", ".xlsm", ".xls")]
public class ExcelInspector : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Button("Press for fun, not gonna edit that excel file");
    }
}
