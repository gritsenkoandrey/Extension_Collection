using UnityEngine;

namespace Patterns.PoolObject
{
    [System.Serializable]
    public struct PoolItem
    {
        public GameObject Prefab;
        public int Count;
    }
}