using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration
{

#if UNITY_ANDROID && !UNITY_EDITOR
        private static readonly AndroidJavaObject Vibrator =
    new AndroidJavaClass("com.unity3d.player.UnityPlayer")// Get the Unity Player.
    .GetStatic<AndroidJavaObject>("currentActivity")// Get the Current Activity from the Unity Player.
    .Call<AndroidJavaObject>("getSystemService", "vibrator");// Then get the Vibration Service from the Current Activity.
#endif

    static void VibrationPermissionCreator() // Trick Unity into giving the App vibration permission when it builds. (Don't call this function, it's useless)
    {     
#if UNITY_ANDROID && !UNITY_EDITOR
        if (Application.isEditor) // This check will always be false, but the compiler doesn't know that.
        {
            Handheld.Vibrate();
        } 
#endif
    }

    public static void Vibrate(long milliseconds)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        Vibrator.Call("vibrate", milliseconds);

#else
        Handheld.Vibrate();
#endif
    }

    public static void Vibrate(long[] pattern, int repeat)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        Vibrator.Call("vibrate", pattern, repeat);
#else
        Handheld.Vibrate();
#endif
    }
}
