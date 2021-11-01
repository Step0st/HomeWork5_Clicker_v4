using System;
using UnityEngine;

public class HintsWindow : MonoBehaviour
{
    public Action CloseEvent;
    
    public void OnClose()
    {
        CloseEvent?.Invoke();
    }
}