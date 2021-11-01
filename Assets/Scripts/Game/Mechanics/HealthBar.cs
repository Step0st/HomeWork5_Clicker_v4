using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Mechanics
{
    public class HealthBar : MonoBehaviour
    {
        public Slider Slider;
        //private GameObject _hpBar;
        //public GameObject healthBar, hpBarField;
        public void SetHealthBar(int health)
        {
            //var pos = GetComponent<SpawnMechanics>().pos;
            //Instantiate(healthBar);
            //-- localPosition - Position discrepancy --
            //hpBarField.transform.position = new Vector3(pos.x, pos.y, 0);
            //Slider = _hpBar.GetComponent<Slider>();
            Slider.maxValue = health;
            Slider.value = health;
        }
        public void SetHealth(int health)
        {
            Slider.value = health;
        }
        
    }
}
