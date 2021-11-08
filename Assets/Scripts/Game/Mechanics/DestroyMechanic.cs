using System;
using System.Collections.Generic;
using Game.Sounds;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Mechanics
{
    public class DestroyMechanic : MonoBehaviour
    {
        [SerializeField] public Camera _camera;
        private int health;
        private GameObject clone;
        private int PinatasDestroyed;
        public Text PinatasCounter;
        public Text ScoreCounter;
        [SerializeField] private GameObject _gameSounds;
        private Vector3 pos;
        
        public void Start()
        {
            PinatasDestroyed = 0;
            Initialization();
        }
        public void Update()
        {
            //Blow destruction
            if (clone.GetComponent<GrowthMechanic>().blowing >= 90)
            {
                GetComponent<SpawnMechanics>().destroyObject();
                _gameSounds.GetComponent<SoundPlayer>().FleeSound();
                Initialization();
            }

            //Hit destruction
            if (Time.timeScale > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                    Collider2D[] col = Physics2D.OverlapPointAll(pos);

                    if (col.Length == 1)
                    {
                        foreach (Collider2D c in col)
                        {
                            Damage();
                            IfDestroyed();
                        }
                    }
                    else
                    {
                        foreach (Collider2D c in col)
                        {
                            DoubleDamage();
                            IfDestroyed();
                            break;
                        }
                    }
                }
            }
            
            //Destroyed pinatas counter to text
            PinatasCounter.text = PinatasDestroyed.ToString();
            ScoreCounter.text = PinatasDestroyed.ToString() + " Pinatas";
        }

        private void Initialization()
        {
            GetComponent<SpawnMechanics>().spawnObjects();
            clone = GetComponent<SpawnMechanics>()._spawnedObject;
            health = clone.GetComponent<HpManager>().Health;
        }

        private void Damage()
        {
            health += -1;
            GetComponent<DamageTextManager>().damageToText(1);
            GetComponent<SpawnMechanics>()._spawnedObject.GetComponent<Animation>().Play("ClickShake");
            _gameSounds.GetComponent<SoundPlayer>().DamageSound();
        }

        private void DoubleDamage()
        {
            health += -2;
            GetComponent<DamageTextManager>().damageToText(2);
            GetComponent<SpawnMechanics>()._spawnedObject.GetComponent<Animation>().Play("ClickShake");
            _gameSounds.GetComponent<SoundPlayer>().DoubleDamageSound();
        }

        private void IfDestroyed()
        {
            if (health <= 0)
            {
                GetComponent<SpawnMechanics>().destroyObject();
                pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                GetComponent<FillingManager>().spawnFilling(pos);
                GetComponent<ParticlesManager>().ParticlesExplotion(pos);
                _gameSounds.GetComponent<SoundPlayer>().DestroySound();
                Initialization();
                PinatasDestroyed += 1;
            }
        }
    }
}