using UnityEngine;

namespace CustomDebugLog
{
    public sealed class CustomDebug
    {
        public static void Log(DebugColor color, string text)
        {
#if !RELEASE_BUILD
            Debug.Log($"<color=#{ColorDictionary.Colors[color]}>{text}</color>");
#endif
        }
    }
}