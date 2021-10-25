using System;
using System.Collections.Generic;
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
        [SerializeField] private SpawnMechanics _spawnMechanics;

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
                _spawnMechanics.destroyObject();
                Initialization();
            }

            //Hit destruction
            if (Time.timeScale > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
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
            _spawnMechanics.spawnObjects();
            clone = _spawnMechanics._spawnedObject;
            health = clone.GetComponent<HpManager>().Health;
        }

        private void Damage()
        {
            health += -1;
        }

        private void DoubleDamage()
        {
            health += -2;
        }

        private void IfDestroyed()
        {
            if (health <= 0)
            {
                _spawnMechanics.destroyObject();
                Initialization();
                PinatasDestroyed += 1;
            }
        }
    }
}