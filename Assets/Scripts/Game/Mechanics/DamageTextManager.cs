using System;
using UnityEngine;


public class DamageTextManager: MonoBehaviour

    {
        private DamageText[] clickTextPool = new DamageText[16];
        [SerializeField] public GameObject ClickTextPrefab, clickField;
        private int _clickNum;
        public void Start()
        {
            for (int i = 0; i < clickTextPool.Length; i++)
            {
                clickTextPool[i] = Instantiate(ClickTextPrefab, clickField.transform).GetComponent<DamageText>();
            }
        }
        public void damageToText(int damage)
        {
            clickTextPool[_clickNum].StartMotion(damage);
            _clickNum = _clickNum == clickTextPool.Length - 1 ? 0 : _clickNum + 1;
        }
    }
