using System;
using UnityEngine;
using System.Collections;

namespace Game.Mechanics
{
    public class VibrateUIAnimation : MonoBehaviour
    {
        private float _scale = 0;

        private void Update()

        {
            _scale = (Mathf.PingPong(Time.realtimeSinceStartup, 1) - 0.5f) / 200;
            transform.localScale += new Vector3(_scale, _scale, _scale);
        }
    }
}