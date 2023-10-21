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
    public GameObject winCanvas;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        winCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !completed)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Debug.Log("GAME COMPLETE");
                winCanvas.SetActive(true);
                Time.timeScale = 0;
                // Disable Movement
            }
            else
            {
                Invoke("nextStage", 2f);
            }
        }
        
    }

    private void nextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
