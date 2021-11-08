using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Sounds
{
    public class SoundObject : MonoBehaviour
    {
        public bool Dynamic = true;
        private AudioSource _source;
        [SerializeField] private AudioClip _sound1;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }
        
        public void Play(AudioClip clip, Vector3 position, float volume = 1f, bool loop = false)
        {
            transform.position = position;
            Play(clip,volume,loop);
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