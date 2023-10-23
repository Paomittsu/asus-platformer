using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish_Line : MonoBehaviour
{

    private SpriteRenderer sr;
    private bool completed = false;
    // public TextMeshProUGUI winText;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !completed)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("GAME COMPLETE");
                WinScreen.instance.Winner();
                Time.timeScale = 0;
                // Disable Movement
            }
            else
            {
                LevelLoader.instance.LoadNextLevel();
                gameObject.SetActive(false);
            }
        }
        
    }

}
