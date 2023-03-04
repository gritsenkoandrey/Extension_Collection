using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Generate
{
    public sealed class GenerateBox : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        
        [SerializeField] private float _rowX;
        [SerializeField] private float _rowZ;
        [SerializeField] private float _offset;

        [SerializeField] private int _count;

        private void Start()
        {
            Vector3 pos = transform.position;
            
            for (int i = 0; i < _count; i++)
            {
                Instantiate(_prefab, new Vector3(pos.x + GetX(i), pos.y + GetY(i), pos.z + GetZ(i)), Quaternion.identity, transform);
            }
        }

        private float GetX(int count) => count % _rowX * _offset;
        private float GetY(int count) => Mathf.Floor(count / (_rowX * _rowZ)) * _offset;
        private float GetZ(int count) => Mathf.Floor(count % (_rowX * _rowZ) / _rowZ) * _offset;
    }
}