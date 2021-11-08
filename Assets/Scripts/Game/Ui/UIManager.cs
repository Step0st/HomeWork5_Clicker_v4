using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Game.Mechanics
{
    public class UIManager : MonoBehaviour

    {
        [SerializeField] private StartWindow _startWindow;
        [SerializeField] private GameModesWindow _gameModesWindow;
        [SerializeField] private ScoreWindow _scoreWindow;
        [SerializeField] private GameObject _timeModeScoreWindow;
        [SerializeField] private GameObject _candyModeScoreWindow;
        [SerializeField] private GameScreen _gameScreen;
        [SerializeField] private GameObject _candyCounter;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private ParticleSystem _winConfetti;
        [SerializeField] private HintsWindow _hintsWindow;
        [SerializeField] private Text _time;
        
        private void Start()
        {
            Time.timeScale = 0;
            _startWindow.gameObject.SetActive(true);
            _gameModesWindow.gameObject.SetActive(false);
            _scoreWindow.gameObject.SetActive(false);
            _gameScreen.gameObject.SetActive(false);
            _hintsWindow.gameObject.SetActive(false);
            _pauseWindow.gameObject.SetActive(false);
            _winConfetti.gameObject.SetActive(false);
            
            _startWindow.QuitEvent += () => { ExitHelper.Exit(); };

            _startWindow.NewGameEvent += () =>
            {
                _startWindow.gameObject.SetActive(false);
                _gameModesWindow.gameObject.SetActive(true);
            };

            _startWindow.CreditsEvent += () =>
            {
                LoadCredits();
                Time.timeScale = 1;
            };

            _gameModesWindow.HintsEvent += () =>
            {
                _hintsWindow.gameObject.SetActive(true);
            };
            
            _gameModesWindow.CandyGameEvent += () =>
            {
                Time.timeScale = 1;
                _gameModesWindow.gameObject.SetActive(false);
                _gameScreen.gameObject.SetActive(true);
                StartCoroutine(Timer());
                
                GetComponent<CandyModeManager>().EndGameEvent += () =>
                {
                    _scoreWindow.gameObject.SetActive(true);
                    _timeModeScoreWindow.gameObject.SetActive(false);
                    _winConfetti.gameObject.SetActive(true);
                    Time.timeScale = 0;
                };
                
                IEnumerator Timer()
                {
                    int timer = -1;
                    while ((timer += 1) > -1)
                    {
                        _time.text = timer.ToString();
                        yield return new WaitForSeconds(1f);
                    }
                }
            };

            _gameModesWindow.TimeGameEvent += () =>
            {
                Time.timeScale = 1;
                _gameModesWindow.gameObject.SetActive(false);
                _gameScreen.gameObject.SetActive(true);
                _candyCounter.gameObject.SetActive(false);
                int TimeForAGame = GetComponent<TimeModeManager>().TimeForAGame + 1;
                StartCoroutine(CountdownTimer(TimeForAGame));

                IEnumerator CountdownTimer(int seconds)
                {
                    int countdownTimer = seconds;
                    while ((countdownTimer -= 1) >= 0)
                    {
                        _time.text = countdownTimer.ToString();
                        yield return new WaitForSeconds(1f);
                    }
                    _scoreWindow.gameObject.SetActive(true);
                    _candyModeScoreWindow.gameObject.SetActive(false);
                    _winConfetti.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
            };
            
            _gameModesWindow.BackEvent += () =>
            {
                _gameModesWindow.gameObject.SetActive(false);
                _startWindow.gameObject.SetActive(true);
            };

            _hintsWindow.CloseEvent += () =>
            {
                _hintsWindow.gameObject.SetActive(false);
            };

            _gameScreen.PauseEvent += () =>
            {
                Time.timeScale = 0;
                _pauseWindow.gameObject.SetActive(true);
            };

            _pauseWindow.ContinueEvent += () =>
            {
                Time.timeScale = 1;
                _pauseWindow.gameObject.SetActive(false);
            };
            
            _pauseWindow.BackEvent += () => { LoadSampleScene(); };

            _scoreWindow.CreditsEvent += () => { LoadCredits(); };
            
            _scoreWindow.BackEvent += () => { LoadSampleScene(); };
        }
        private void LoadSampleScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        private void LoadCredits()
        {
            SceneManager.LoadScene("Credits");
        }
    }
}