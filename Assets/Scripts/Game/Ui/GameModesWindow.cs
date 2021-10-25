using System;
using UnityEngine;

public class GameModesWindow : MonoBehaviour
{
    public Action EndlessGameEvent;

    public Action TimeGameEvent;

    public Action BackEvent;

    public void OnEndlessGame()
    {
        EndlessGameEvent?.Invoke();
    }
    public void OnTimeGame()
    {
        TimeGameEvent?.Invoke();
    }
    public void OnBackToMenu()
    {
        BackEvent?.Invoke();
    }
}