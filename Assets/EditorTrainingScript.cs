using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTrainingScript : MonoBehaviour {

    [Range(1, 15)]
    public int numer = 5;

    [TextArea(1, 5)]
    public string areaTexter;

    [ContextMenuItem("Debug Line Texter", "PrintOutLine")]
    [Multiline(3)]
    [Tooltip("HI?")]
    public string lineTexter;

    void PrintOutLine()
    {
        Debug.Log(lineTexter);
    }

    [ContextMenu("Print log for the script")]
    void LineTexture()
    {
        Debug.Log("Custom Line Texture");
    }


    [Space(15)]
    [Header("Test Header")]
    //[ColorUsage(true, true)]
    [Tooltip("asdasdsad")]
    public Color clor;
}
