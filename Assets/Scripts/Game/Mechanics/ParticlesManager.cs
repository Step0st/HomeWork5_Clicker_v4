using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{

    [SerializeField] private GameObject _part;
    

    public void ParticlesExplotion(Vector3 pos)
    {
        var spawnedParticle = Instantiate(_part, pos, Quaternion.Euler(0, 0, 0));
        Destroy(spawnedParticle, 5f);
    }
    
}
