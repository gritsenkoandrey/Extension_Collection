using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.CustomDebugLog.Example
{
    public sealed class ExampleCDL : MonoBehaviour
    {
        private void Start()
        {
            CustomDebug.Log($"{FormatNumbers.Trim(5500)}", DebugColor.Green);
        }
    }
}