using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class TimeControl {

	public static bool isPlaying { get; private set; }
    private static float currentTime { get; set; }
    private static double lasFrameEditorTime { get; set; }

    static TimeControl()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        if (isPlaying)
        {
            double timeSinceStartUp = EditorApplication.timeSinceStartup;
            double deltaTime = timeSinceStartUp - lasFrameEditorTime;
            lasFrameEditorTime = timeSinceStartUp;
            currentTime += (float)deltaTime;
        }
    }

    public static float GetCurrentTime(float stopTime)
    {
        return Mathf.Repeat(currentTime, stopTime);
    }

    public static void Play()
    {
        isPlaying = true;
        lasFrameEditorTime = EditorApplication.timeSinceStartup;
    }

    public static void Pause()
    {
        isPlaying = false;
    }
}
