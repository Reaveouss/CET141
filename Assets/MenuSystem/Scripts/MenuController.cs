using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] string playScene = "GameScene";
    [SerializeField] string mainMenuScene = "StartScene";

    [Tooltip("Drag in an options menu panel, if one exists")]
    [SerializeField] GameObject optionsMenuPanel;

    [Tooltip("Drag in a pause menu panel, if one exists")]
    [SerializeField] GameObject pauseMenuPanel;

    [SerializeField] bool IsPauseMenuAvailable = false;
    [HideInInspector] public static bool IsGamePaused = false;

    private void Update()
    {
        PauseMenu();
    }

    public void PauseMenu()
    {
        if (IsPauseMenuAvailable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void OptionsMenuClose()
    {
        optionsMenuPanel.SetActive(false);
    }

    public void OptionsMenuOpen()
    {
        optionsMenuPanel.SetActive(true);
    }

    public void Pause()
    {
        Cursor.visible = false;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = false;
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(playScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Cursor.visible = true;
    }
}