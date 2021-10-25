using System;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public Action PauseEvent;
    public void OnPause()
    {
        PauseEvent?.Invoke();
    }
}