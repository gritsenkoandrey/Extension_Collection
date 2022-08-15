using UnityEngine;

namespace CustomDebugLog.Example
{
    public sealed class ExampleCDL : MonoBehaviour
    {
        private void Start()
        {
            CustomDebug.Log(DebugColor.Green, "Start Game");
        }
    }
}