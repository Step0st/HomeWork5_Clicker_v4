using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastFlight : MonoBehaviour
{
    

    
    void Update()
    {
        transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
    }
}
