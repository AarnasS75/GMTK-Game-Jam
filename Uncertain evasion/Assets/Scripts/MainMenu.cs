using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    SceneLoader sceneLoader;
    public GameObject ChooseArena;

    void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        ChooseArena.SetActive(false);
    }

    public void PlayGame()
    {
        ChooseArena.SetActive(true);
    }

    public void PlayArenaMain()
    {
        sceneLoader.LoadScene("MainArena");
    }

    public void PlayArenaSmall()
    {
        sceneLoader.LoadScene("SmallArena");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
