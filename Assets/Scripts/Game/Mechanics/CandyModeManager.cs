using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace Game.Mechanics
{
    public class CandyModeManager : MonoBehaviour
    {
        public Action EndGameEvent;
        public Text CandyMeter;
        [SerializeField] private Text _time;
        [SerializeField] private int CandiesToWin = 50;

        private void Start()
        {
            StartCoroutine(Timer());

            IEnumerator Timer()
            {
                int timer = -1;
                while ((timer += 1) > -1)
                {
                    _time.text = timer.ToString() + " seconds";
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        private void Update()
        {
            var NumOfSpawnedCandies = GetComponent<FillingManager>().NumOfSpawnedCandies;

            // condition for win in CandyMode
            if (NumOfSpawnedCandies >= CandiesToWin)
            {
                EndGameEvent?.Invoke();
            }

            CandyMeter.text = NumOfSpawnedCandies.ToString() + "/" + CandiesToWin.ToString();
        }
    }
}