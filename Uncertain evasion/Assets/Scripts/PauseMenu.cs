using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    SceneLoader sceneLoader;
    bool paused;
    public GameObject actualMenu;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        actualMenu.SetActive(false);
    }

    void Update()
    {
        if (paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = false;
                Time.timeScale = 1f;
                actualMenu.SetActive(false);
                return;
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = true;
                Time.timeScale = 0f;
                actualMenu.SetActive(true);
                return;
            }
        }
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        actualMenu.SetActive(false);
    }

    public void RestartLevel()
    {
        paused = false;
        Time.timeScale = 1f;
        sceneLoader.ReloadScene();
    }

    public void GoToMainMenu()
    {
        paused = false;
        Time.timeScale = 1f;
        sceneLoader.LoadScene("Main Menu");
    }
}
