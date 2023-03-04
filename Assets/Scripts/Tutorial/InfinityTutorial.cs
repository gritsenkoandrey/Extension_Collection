using UnityEngine;

namespace AndreyGritsenko.ExtensionCollection.Tutorial
{
    public sealed class InfinityTutorial : MonoBehaviour
    {
        [SerializeField] private RectTransform _fingerTransform;
        [SerializeField] private float _lemniscateRadius = 165f;
        [SerializeField] private float _height = 1f;
        [SerializeField] private float _speed = 3f;

        private void Update()
        {
            float t = Time.time * _speed;

            float x = _lemniscateRadius * Mathf.Sqrt(2) * Mathf.Cos(t);
            float y = _lemniscateRadius * Mathf.Sqrt(2) * Mathf.Cos(t) * Mathf.Sin(t);

            x /= Mathf.Pow(Mathf.Sin(t), 2) + 1;
            y /= Mathf.Pow(Mathf.Sin(t), 2) + 1;
            
            y *= _height;

            _fingerTransform.localPosition = new Vector3(x, y, 0);
        }
    }
}