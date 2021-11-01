using System;
using UnityEngine;
using System.Collections;

namespace Game.Mechanics
{
    public class AppearanceMechanic : MonoBehaviour
    {
        private float _oppacity;

        void OnEnable()
        {
            _oppacity = 0;
        }

        private void Update()
        {
            StartCoroutine(Timer());

            IEnumerator Timer()
            {
                while (_oppacity <= 1)
                {
                    _oppacity += Time.deltaTime / 500;
                    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, _oppacity);
                    yield return null;
                }
            }
        }
    }
}