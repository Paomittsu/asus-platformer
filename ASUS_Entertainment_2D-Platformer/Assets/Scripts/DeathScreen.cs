using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;
    public GameObject deathscrn;
    public GameObject player;
    public Animator deathFade;
    public Animator trans;
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
            StartCoroutine(Beginning());
        }
        Health.instance.health = 5;
        deathFade.SetTrigger("Re");
        deathscrn.SetActive(false);
        PlayerLife.instance.ResetPlayer();
    }

    IEnumerator PlayerLose()
    {
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
    }

    IEnumerator Beginning()
    {
        trans.SetTrigger("End");
        //Wait
        yield return new WaitForSeconds(deathTime);
        //Load scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        // Wait until the scene is fully loaded
        while (!operation.isDone)
        {
            player.transform.position = new Vector2(-7, 1);
            yield return null;
        }
        trans.SetTrigger("Start");
    }
}
