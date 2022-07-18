using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneTime(scene));
    }

    IEnumerator LoadSceneTime(string scene)
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

        public void ReloadScene()
    {
        StartCoroutine(ReloadSceneTime());
    }

    IEnumerator ReloadSceneTime()
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
