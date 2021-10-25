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
        [SerializeField] private GameScreen _gameScreen;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private Text _time;

        private void Start()
        {
            Time.timeScale = 0;

            _startWindow.gameObject.SetActive(true);
            _gameModesWindow.gameObject.SetActive(false);
            _scoreWindow.gameObject.SetActive(false);
            _gameScreen.gameObject.SetActive(false);
            _pauseWindow.gameObject.SetActive(false);

            _startWindow.QuitEvent += () => { ExitHelper.Exit(); };

            _startWindow.NewGameEvent += () =>
            {
                _startWindow.gameObject.SetActive(false);
                _gameModesWindow.gameObject.SetActive(true);
            };

            _startWindow.CreditsEvent += () =>
            {
                SceneManager.LoadScene("Credits");
                Time.timeScale = 1;
            };

            _gameModesWindow.EndlessGameEvent += () =>
            {
                Time.timeScale = 1;
                _gameModesWindow.gameObject.SetActive(false);
                _gameScreen.gameObject.SetActive(true);
                StartCoroutine(Timer());

                IEnumerator Timer()
                {
                    int timer = 0;
                    while ((timer += 1) > 0)
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
                StartCoroutine(CountdownTimer(21));

                IEnumerator CountdownTimer(int seconds)
                {
                    int timer = seconds;
                    while ((timer -= 1) >= 0)
                    {
                        _time.text = timer.ToString();
                        yield return new WaitForSeconds(1f);
                    }

                    _scoreWindow.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
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

            _pauseWindow.BackEvent += () => { SceneManager.LoadScene("SampleScene"); };

            _scoreWindow.CreditsEvent += () => { SceneManager.LoadScene("Credits"); };

            _scoreWindow.BackEvent += () => { SceneManager.LoadScene("SampleScene"); };

            _gameModesWindow.BackEvent += () =>
            {
                _gameModesWindow.gameObject.SetActive(false);
                _startWindow.gameObject.SetActive(true);
            };
        }
    }
}