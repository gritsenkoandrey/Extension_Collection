using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.CustomDebugLog
{
    public static class CustomDebug
    {
        public static void Log(string text, DebugColor color = DebugColor.Gray)
        {
            Debug.Log($"<color=#{ColorDictionary.Colors[color]}>{text}</color>");
        }
    }
}