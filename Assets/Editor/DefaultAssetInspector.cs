using System;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DefaultAsset))]
public class DefaultAssetInspector : Editor {

    private Editor editor;
    private static Type[] customAssetTypes;

    [InitializeOnLoadMethod]
    static void Init()
    {
        customAssetTypes = GetCustomAssetTypes();
    }

    private static Type[] GetCustomAssetTypes()
    {
        var assemblyPaths = Directory.GetFiles("Library/ScriptAssemblies", "*.dll");
        List<Type> types = new List<Type>();
        List<Type> customAssetType = new List<Type>();

        for (int i = 0; i<assemblyPaths.Length; i++)
        {
            types.AddRange(Assembly.LoadFile(assemblyPaths[i]).GetTypes());
        }

        for (int i = 0; i<types.Count; i++)
        {
            var customAttributes = types[i].GetCustomAttributes(typeof(CustomAssetAttribute), false) as CustomAssetAttribute[];
            if (customAttributes.Length > 0)
                customAssetType.Add(types[i]);
        }

        return customAssetType.ToArray();
    }

    private Type GetCustomAssetEditorType(string extension)
    {
        CustomAssetAttribute[] customAttributes;

        if (customAssetTypes != null)
        {
            for (int i = 0; i < customAssetTypes.Length; i++)
            {
                customAttributes = customAssetTypes[i].GetCustomAttributes(typeof(CustomAssetAttribute), false) as CustomAssetAttribute[];
                for (int j = 0; j < customAttributes.Length; j++)
                {
                    if (customAttributes[j].extensions.Contains(extension))
                    {
                        return customAssetTypes[i];
                    }
                }
            }
        }
        return (typeof(DefaultAsset));
    }

    private void OnEnable()
    {
        string assetPath = AssetDatabase.GetAssetPath(target);
        string extension = Path.GetExtension(assetPath);
        Type customAssetEditorType = GetCustomAssetEditorType(extension);
        editor = CreateEditor(target, customAssetEditorType);
    }

    public override void OnInspectorGUI()
    {
        if (editor != null)
        {
            GUI.enabled = true;
            editor.OnInspectorGUI();
        }
    }

    public override bool HasPreviewGUI()
    {
        return (editor != null) ? editor.HasPreviewGUI() : base.HasPreviewGUI();
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        if (editor!=null)
           editor.OnPreviewGUI(r, background);
    }

    public override void OnPreviewSettings()
    {
        if (editor != null)
           editor.OnPreviewSettings();
    }

    public override string GetInfoString()
    {
        return (editor != null) ? editor.GetInfoString() : base.GetInfoString();
    }
}
