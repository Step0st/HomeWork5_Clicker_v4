using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Sounds
{
    public class SoundPlayer : MonoBehaviour
    {
        private AudioSource _source;
        [SerializeField] private AudioClip _damageSound;
        [SerializeField] private AudioClip _doubleDamageSound;
        [SerializeField] private AudioClip _fleeSound;
        [SerializeField] private AudioClip _destroySound;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
            }
        public void DamageSound()
        {
            Play(_damageSound);
        }
        public void DoubleDamageSound()
        {
            Play(_doubleDamageSound);
        }
        public void FleeSound()
        {
            Play(_fleeSound);
        }
        public void DestroySound()
        {
            Play(_destroySound);
        }
        public void Play(AudioClip clip, float volume = 1f, bool loop = false)
        {
            _source.clip = clip;
            _source.volume = volume;
            _source.loop = loop;
            _source.Play();
        }
    }
}