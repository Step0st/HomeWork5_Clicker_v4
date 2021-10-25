using System;
using UnityEngine;

public class PauseUIWindow : MonoBehaviour
{
    
    public Action ContinueEvent;
    
    public Action BackEvent;
    
    
    public void OnContinue()
    {
        ContinueEvent?.Invoke();
    }
        
    public void OnBackToMenu()
    {
        BackEvent?.Invoke();
    }
}
