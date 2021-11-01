using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Game.Mechanics
{
    public class FillingManager: MonoBehaviour
    {
        [SerializeField] private List<GameObject> FillingPool;
        [SerializeField] private List<GameObject> ConfettiPool;
        public void spawnFilling(Vector3 pos)
        {
            int randomItem = 0;
            GameObject toSpawn;
            
            // CandySpawn
            var NumberOfCandies = Random.Range(2, 4);
            for (int i = 0; i < NumberOfCandies; i++)
            {
                randomItem = Random.Range(0, FillingPool.Count);
                toSpawn = FillingPool[randomItem];
                var spawnpos = new Vector3(pos.x+Random.Range(-0.5f,0.5f), pos.y+Random.Range(-0.5f,0.5f), 0);
                Instantiate(toSpawn, spawnpos, Quaternion.Euler(0, 0, Random.Range(-90, 90)));
            }
            
            // ConfettiSpawn
            var NumberOfConfetti = Random.Range(3, 5);
            for (int i = 0; i < NumberOfConfetti; i++)
            {
                randomItem = Random.Range(0, ConfettiPool.Count);
                toSpawn = ConfettiPool[randomItem];
                toSpawn.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
                var spawnpos = new Vector3(pos.x+Random.Range(-0.5f,0.5f), pos.y+Random.Range(-0.5f,0.5f), 0);
                Instantiate(toSpawn, spawnpos, Quaternion.Euler(0, 0, Random.Range(-90, 90)));
            }
        }
    }
}