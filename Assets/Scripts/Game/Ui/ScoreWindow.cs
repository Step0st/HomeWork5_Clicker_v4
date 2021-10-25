using System;
using UnityEngine;

public class ScoreWindow : MonoBehaviour
{
    public Action CreditsEvent;

    public Action BackEvent;


    public void OnCredits()
    {
        CreditsEvent?.Invoke();
    }

    public void OnBackToMenu()
    {
        BackEvent?.Invoke();
    }
}