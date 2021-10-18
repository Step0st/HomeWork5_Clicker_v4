using System;
using UnityEngine;

namespace Game.Mechanics
{
    public class AppearanceMechanic:MonoBehaviour
    
    
    {   
        private float _oppacity;
    
        void Start()
        {
            _oppacity = 0;
        }
    
        private void Update()
        {
            //better to use Coroutines, but for the first time I try that method
            for (float i = 0; i <10; i+= Time.deltaTime)
            {
                _oppacity += Time.deltaTime/3000;
                GetComponent<SpriteRenderer>().color= new Color(1f, 1f, 1f, _oppacity);
            }
        }
    }
}