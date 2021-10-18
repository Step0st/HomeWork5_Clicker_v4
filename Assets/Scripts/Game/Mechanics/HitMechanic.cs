using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Mechanics
{
    public class HitMechanic:MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private int HpPoint = 5;
        private int PinatasDestroyed = 0;
        public Text PinatasCounter;
        private void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                var pos = _camera.ScreenToWorldPoint(Input.mousePosition);
                Collider2D[] col = Physics2D.OverlapPointAll(pos);
                
                if (col.Length == 1)
                {
                    foreach (Collider2D c in col)
                    {
                        HpPoint += -1;
                        if (HpPoint <= 0)
                        {
                            Destroy(c.GetComponent<Collider2D>().gameObject);
                            HpPoint = 5;
                            PinatasDestroyed += 1;
                        }
                    }
                }
                else
                {
                    foreach (Collider2D c in col)
                    {
                        HpPoint += -1;
                        if (HpPoint <= 0)
                        {
                            Destroy(c.GetComponent<Collider2D>().gameObject);
                            HpPoint = 5;
                            PinatasDestroyed += 1;
                            break;
                        }
                    }

                    
                }
            }
            if (GameObject.FindGameObjectsWithTag("Pinata").Length == 0)
            {
                HpPoint=5;
            }
            
            PinatasCounter.text = PinatasDestroyed.ToString();
        }
    }
}