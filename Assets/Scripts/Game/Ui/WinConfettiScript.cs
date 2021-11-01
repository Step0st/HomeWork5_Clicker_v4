using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConfettiScript : MonoBehaviour
{
    void Update()
    {
        GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
    }
}
