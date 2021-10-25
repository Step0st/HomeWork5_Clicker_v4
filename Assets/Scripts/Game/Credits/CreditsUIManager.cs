using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


    public class CreditsUIManager :  MonoBehaviour

    {
        
        [SerializeField] private CreditsScreen _creditsScreen;
        [SerializeField] private PauseUIWindow _pauseUIWindow;
        
        private void Start()
        {
            Time.timeScale = 1;
            
            _pauseUIWindow.gameObject.SetActive(false);
            
            _creditsScreen.PauseEvent += () =>
            {
                Time.timeScale = 0;
                _pauseUIWindow.gameObject.SetActive(true);
               };
            
            _pauseUIWindow.ContinueEvent += () =>
            {
                Time.timeScale = 1;
                _pauseUIWindow.gameObject.SetActive(false);
            };
            
            _pauseUIWindow.BackEvent += () =>
            {
                _pauseUIWindow.gameObject.SetActive(false);
                SceneManager.LoadScene("SampleScene");
            };
            
           
        }
        
        
        
    }
