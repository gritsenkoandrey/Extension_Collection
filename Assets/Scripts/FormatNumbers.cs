﻿namespace AndreyGritsenko.ExtensionCollection
{
    public static class FormatNumbers
    {
        private static readonly string[] _names = { "", "K", "M", "B", "T" };
        
        public static string Trim(int value)
        {
            if (value < 1000)
            {
                return value.ToString(); 
            }

            string text = value.ToString();
            
            int dot = text.IndexOf('.');

            if (dot < 0)
            {
                dot = text.Length;
            }
            
            int triples = dot / 3;
            
            int num = dot % 3;

            if (num == 0)
            {
                return $"{text.Substring(0, 3)}{_names[--triples]}";
            }

            return $"{text.Substring(0, num)},{text[num]}{_names[triples]}";
        }
    }
}