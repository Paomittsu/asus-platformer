using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public GameObject deathscrn;
    public Animator deathFade;
    public float deathTime = 1f;
    // Start is called before the first frame update
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
        deathscrn.SetActive(false);
    }

    public void GameOver()
    {
        deathscrn.SetActive(true);
        StartCoroutine(PlayerLose());
    }

    public void RestartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartCoroutine(LoadSceneAndReset());
        }
        else
        {
            ResetGame();
        }
    }

    IEnumerator PlayerLose()
    {
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
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
        deathFade.SetTrigger("Re");
        deathscrn.SetActive(false);
        PlayerLife.instance.ResetPlayer();
    }
}


