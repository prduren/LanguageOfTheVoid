using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsUI;

    void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused || optionsUI.activeSelf) {
                Resume();
            } else if (!GameIsPaused)  {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // 1 is full speed, .5 half speed, 0 completely paused
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void RestartLevel() {
        Resume();
        Initiate.Fade(NameFromIndex(SceneManager.GetActiveScene().buildIndex), Color.black, 0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Options() {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void Back() {
        pauseMenuUI.SetActive(true);
        optionsUI.SetActive(false);
    }

    private static string NameFromIndex(int BuildIndex) {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

}
