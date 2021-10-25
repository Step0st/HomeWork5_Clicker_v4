using System;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    
    public Action PauseEvent;
    
    
    public void OnPause()
    {
        PauseEvent?.Invoke();
    }
    
}
