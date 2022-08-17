using System.Collections.Generic;
using System;

namespace Patterns.ServiceLocators
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> ServiceContainer = new Dictionary<Type, object>();

        public static void SetService<T> (T value) where T : class
        {
            Type typeValue = typeof(T);
            
            if (!ServiceContainer.ContainsKey(typeValue))
            {
                ServiceContainer[typeValue] = value;
            }
        }

        public static T Resolve<T>()
        {
            Type type = typeof(T);

            if (ServiceContainer.ContainsKey(type))
            {
                return (T) ServiceContainer[type];
            }

            return default;
        }
    }
}