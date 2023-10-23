using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen instance;
    public GameObject winScrn;
    public Animator winFade;
    public float winTime = 1f;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        winScrn.SetActive(false);
    }

    public void Winner()
    {
        winScrn.SetActive(true);
        StartCoroutine(PlayerWin());
    }

    public void RestartGame()
    {
        StartCoroutine(LoadSceneAndReset());
        Time.timeScale = 1;
    }

    IEnumerator PlayerWin()
    {
        winFade.SetTrigger("Win");
        yield return new WaitForSeconds(winTime);
    }

    IEnumerator LoadSceneAndReset()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        while (!operation.isDone)
        {
            yield return null;
        }

        ResetGame();
    }

    void ResetGame()
    {
        Health.instance.health = 5;
        winFade.SetTrigger("Re");
        winScrn.SetActive(false);
        PlayerLife.instance.ResetPlayer();
    }
}
