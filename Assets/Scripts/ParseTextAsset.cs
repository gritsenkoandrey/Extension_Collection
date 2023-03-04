using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection
{
    public class ParseTextAsset
    {
        private readonly CultureInfo _cultureInfo = CultureInfo.GetCultureInfo("en-US");

        public void ParseGameDataAsset(TextAsset textAsset, IDictionary<int, int> data)
        {
            int index = default;
            
            string[] lineDelimiterString = {"\n", "\r\n"};
            string[] elementsDelimiterString = {"\t", " "};
            string[] lines = textAsset.text.Split(lineDelimiterString, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string line in lines)
            {
                string[] split = line.Split(elementsDelimiterString, StringSplitOptions.RemoveEmptyEntries);
                
                for (int i = 0; i < split.Length; i++)
                {
                    if (float.TryParse(split[i], NumberStyles.Float, _cultureInfo, out float result))
                    {
                        if (i == 0)
                        {
                            index = (int)result;
                            data.Add(index, default);
                        }
                        else if (i == 1)
                        {
                            data[index] = (int)result;
                        }
                    }
                }
            }
        }
    }
}