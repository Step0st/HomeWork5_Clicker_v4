using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public SoundObject SoundObjectPrefab;

        public SoundObject CreateSoundObject()
        {
            var go = Instantiate(SoundObjectPrefab);
            Object.DontDestroyOnLoad(go);
            return go.GetComponent<SoundObject>();
        }
    }
}