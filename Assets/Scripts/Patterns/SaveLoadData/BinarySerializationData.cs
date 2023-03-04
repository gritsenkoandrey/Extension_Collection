using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AndreyGritsenko.ExtensionCollection.Patterns.SaveLoadData
{
    public class BinarySerializationData<T> : IData<T>
    {
        private static BinaryFormatter _formatter;

        public BinarySerializationData()
        {
            _formatter = new BinaryFormatter();
        }

        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path))
            {
                return;
            }

            if (!typeof(T).IsSerializable)
            {
                return;
            }

            using FileStream fs = new FileStream(path, FileMode.Create);
            
            _formatter.Serialize(fs, data);
        }

        public T Load(string path)
        {
            if (!File.Exists(path))
            {
                return default;
            }

            using FileStream fs = new FileStream(path, FileMode.Open);
            
            T result = (T)_formatter.Deserialize(fs);

            return result;
        }
    }
}