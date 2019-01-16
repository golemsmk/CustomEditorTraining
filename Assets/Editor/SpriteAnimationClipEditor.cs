using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

[CustomEditor(typeof(AnimationClip)), InitializeOnLoad]
public class SpriteAnimationClipEditor : OverrideEditor {

    protected override Editor GetBaseEditor()
    {
        Editor editor = null;

        System.Type baseType = Assembly.Load("UnityEditor.dll").GetType("UnityEditor.AnimationClipEditor");

        CreateCachedEditor(targets, baseType, ref editor);

        return editor;
    }

    private Sprite[] GetSprites(AnimationClip anim)
    {
        Sprite[] sprites = new Sprite[0];

        if (anim != null)
        {
            var editorCurveBinding = EditorCurveBinding.PPtrCurve("", typeof(SpriteRenderer), "m_Sprite");

            var objectReferenceKeyframes = AnimationUtility.GetObjectReferenceCurve(anim, editorCurveBinding);

            sprites = objectReferenceKeyframes.Select(objectReferenceKeyframe => objectReferenceKeyframe.value).OfType<Sprite>().ToArray();
        }
        return sprites;
    }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    bool isPlaying;
    Sprite[] sprite;

    public void OnEnable()
    {
        sprite = GetSprites(target as AnimationClip);
    }

    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        if (sprite.Length!=0)
        { 
            AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings((AnimationClip)target);

            int currentSpriteIndex = Mathf.FloorToInt(TimeControl.GetCurrentTime(settings.stopTime) / settings.stopTime * sprite.Length);

            var texture = AssetPreview.GetAssetPreview(sprite[currentSpriteIndex]);
            EditorGUI.DrawTextureTransparent(r, texture, ScaleMode.ScaleToFit);
        } else
        {
            baseEditor.OnInteractivePreviewGUI(r, background);
        }
    }

    public override void OnPreviewSettings()
    {
        GUIContent playButtonContent = EditorGUIUtility.IconContent("PlayButton");
        GUIContent pauseButtonContent = EditorGUIUtility.IconContent("PauseButton");

        GUIStyle previewButtonSettingStyle = new GUIStyle("preButton");

        GUIContent buttonContent = TimeControl.isPlaying ? pauseButtonContent : playButtonContent;

        EditorGUI.BeginChangeCheck();

        isPlaying = GUILayout.Toggle(TimeControl.isPlaying, buttonContent, previewButtonSettingStyle);

        if (EditorGUI.EndChangeCheck())
        {
            if (isPlaying)
                TimeControl.Play();
            else
                TimeControl.Pause();
        }
    }


}
