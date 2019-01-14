using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomPreview(typeof(AnimationClip))]
public class AnimationCustomPreview : ObjectPreview {

    private GUIContent previewTitle = new GUIContent("Sprite Clip");

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override void Initialize(Object[] targets)
    {
        base.Initialize(targets);

        var sprites = new Object[0];

        for (int i = 0; i<targets.Length; i++)
        {
            ArrayUtility.AddRange(ref sprites, GetSprites((AnimationClip)targets[i]));
        }

        m_Targets = sprites;
    }

    public override GUIContent GetPreviewTitle()
    {
        return previewTitle;
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

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        var previewTexture = AssetPreview.GetAssetPreview(target);
        EditorGUI.DrawTextureTransparent(r, previewTexture);
    }
}
