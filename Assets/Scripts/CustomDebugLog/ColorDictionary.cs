using System.Collections.Generic;

namespace AndreyGritsenko.ExtensionCollection.CustomDebugLog
{
    public static class ColorDictionary
    {
        private const string Black = "000000";
        private const string Gray = "adadad";
        private const string Green = "19e619";
        private const string Yellow = "f0f409";
        private const string Orange = "ff9900";
        private const string Blue = "00bfff";
        private const string Red = "e34234";
        private const string Magenta = "ce29ff";

        public static readonly Dictionary<DebugColor, string> Colors = new()
        {
            { DebugColor.Black, Black },
            { DebugColor.Gray, Gray },
            { DebugColor.Green, Green },
            { DebugColor.Yellow, Yellow },
            { DebugColor.Orange, Orange },
            { DebugColor.Blue, Blue },
            { DebugColor.Red, Red },
            { DebugColor.Magenta, Magenta },
        };
    }
}