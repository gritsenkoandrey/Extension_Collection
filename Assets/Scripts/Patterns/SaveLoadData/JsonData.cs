using System.IO;
using UnityEngine;

namespace Patterns.SaveLoadData
{
    public class JsonData<T> : IData<T>
    {
        public T Load(string path = null)
        {
            string str = File.ReadAllText(path);
            
            return JsonUtility.FromJson<T>(str);
        }

        public void Save(T data, string path = null)
        {
            string str = JsonUtility.ToJson(data);
            
            File.WriteAllText(path, str);
        }
    }
}