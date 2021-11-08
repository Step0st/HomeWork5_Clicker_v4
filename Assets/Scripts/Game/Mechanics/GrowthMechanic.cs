using System;
using UnityEngine;

namespace Game.Mechanics
{
    public class GrowthMechanic : MonoBehaviour
    {
        private int _maxSize = 2;
        [SerializeField] private float _speed = 0.05f;
        private Vector3 targetScale;
        public float blowing;
        void OnEnable()
        {
            targetScale = transform.localScale * _maxSize;
        }
        void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, _speed * Time.deltaTime);
            blowing += _speed * Time.timeScale;
        }
    }
}