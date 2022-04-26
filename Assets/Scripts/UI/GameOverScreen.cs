using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{    
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }    

    private void OnDied()
    {
        _gameOverGroup.alpha = 1;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        Time.timeScale = 0; // останавливаем время в игре
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(0); // запускаем сцену 0
    }

    private void OnExitButtonClick()
    {
        Application.Quit(); // выходим из приложения
    }
}
