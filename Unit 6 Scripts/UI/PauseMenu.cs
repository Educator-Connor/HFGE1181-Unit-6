using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    private PlayerInputActions input;
    public bool isPaused = false;
    public string mainMenuScene;

    private void Awake()
    {
        input = new PlayerInputActions();
    }

    private void Start()
    {
        input.UI.PauseMenu.performed += HandlePauseMenu;
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private void HandlePauseMenu(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            Pause();
        }
        else if (isPaused)
        {
            Resume();
        }
    }

    public void Pause()
    {
        isPaused = true;
        UIManager.Instance.pauseMenuUI.SetActive(true);
        UIManager.Instance.hudUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
      
        isPaused = false;
        UIManager.Instance.pauseMenuUI.SetActive(false);
        UIManager.Instance.hudUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
