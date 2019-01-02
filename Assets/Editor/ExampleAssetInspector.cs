using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExampleAsset))]
public class ExampleAssetInspector : Editor {

    public override bool HasPreviewGUI()
    {
        return true;
    }

    PreviewRenderUtility previewRenderUltility;
    GameObject previewObject;

    void OnEnable()
    {
        previewRenderUltility = new PreviewRenderUtility(true);

        previewRenderUltility.cameraFieldOfView = 30f;

        previewRenderUltility.camera.nearClipPlane = 0.3f;
        previewRenderUltility.camera.farClipPlane = 100;

    }
}
