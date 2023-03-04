using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Patterns.PoolObject
{
    [System.Serializable]
    public struct PoolItem
    {
        public GameObject Prefab;
        public int Count;
    }
}