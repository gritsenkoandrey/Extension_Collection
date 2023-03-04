using System.Collections.Generic;
using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Patterns.ServiceLocators
{
    public static class ServiceLocatorMonoBehaviour
    {
        private static readonly Dictionary<object, object> ServiceContainer;

        static ServiceLocatorMonoBehaviour()
        {
            ServiceContainer = new Dictionary<object, object>();
        }
        
        public static T GetService<T>(bool createObjectIfNotFound = true) where T : Object
        {
            if (!ServiceContainer.ContainsKey(typeof(T)))
            {
                return FindService<T>(createObjectIfNotFound);
            }

            T service = (T)ServiceContainer[typeof(T)];
            
            if (service != null)
            {
                return service;
            }

            ServiceContainer.Remove(typeof(T));
            
            return FindService<T>(createObjectIfNotFound);
        }

        private static T FindService<T>(bool createObjectIfNotFound = true) where T : Object
        {
            T type = Object.FindObjectOfType<T>();
            
            if (type != null)
            {
                ServiceContainer.Add(typeof(T), type);
            }
            else if (createObjectIfNotFound)
            {
                GameObject go = new GameObject(typeof(T).Name, typeof(T));
                
                ServiceContainer.Add(typeof(T), go.GetComponent<T>());
            }
            
            return (T)ServiceContainer[typeof(T)];
        }
    }
}