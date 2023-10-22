using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StartCoroutine(PlayerLose());
    }

    public void RestartGame()
    {
        Health.instance.health = Health.instance.numOfHearts;
        deathFade.SetTrigger("Re");
        deathscrn.SetActive(false);
        PlayerLife.instance.ResetPlayer();
    }

    IEnumerator PlayerLose()
    {
        deathscrn.SetActive(true);
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
    }
}
