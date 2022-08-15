using UnityEngine;

namespace Generate
{
    public sealed class GenerateCircle : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        
        [SerializeField] private float _radius;
        [SerializeField] private int _count;

        private void Start()
        {
            Vector3 pos = transform.position;
            
            for (int i = 0; i < _count; i++)
            {
                Instantiate(_prefab, pos + CalculatePosition(i), Quaternion.identity, transform);
            }
        }

        private Vector3 CalculatePosition(int id)
        {
            float radians = id * Mathf.PI * 2f / _count;
            
            Vector2 angToDir = new Vector2(Mathf.Cos(radians) * _radius, Mathf.Sin(radians) * _radius);
            
            return new Vector3(angToDir.y, 0, angToDir.x);
        }
    }
}