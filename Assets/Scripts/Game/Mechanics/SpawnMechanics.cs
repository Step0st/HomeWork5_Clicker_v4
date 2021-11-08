using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Mechanics
{
    public class SpawnMechanics : MonoBehaviour
    {
        public List<GameObject> SpawnPool;
        public GameObject UnderBorder;
        [HideInInspector] public GameObject _spawnedObject;
        public void spawnObjects()
        {
            int randomItem = 0;
            GameObject toSpawn;
            MeshCollider c = UnderBorder.GetComponent<MeshCollider>();
            float screenX, screenY;
            Vector2 pos;
            //int numberToSpawn = Random.Range(1, 3);
            //for (int i=0; i < numberToSpawn;i++){} - optional mechanic to add more than one pinata
            randomItem = Random.Range(0, SpawnPool.Count);
            toSpawn = SpawnPool[randomItem];
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            _spawnedObject = Instantiate(toSpawn, pos, Quaternion.Euler(0, 0, Random.Range(-15, 15)));
            _spawnedObject.GetComponent<Animation>().Play("Appearance");
        }
        public void destroyObject()
        {
            Destroy(_spawnedObject.gameObject);
        }
    }
}