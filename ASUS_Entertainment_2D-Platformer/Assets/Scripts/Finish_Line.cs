using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Line : MonoBehaviour
{

    private SpriteRenderer sr;
    private bool completed = false;


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
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Debug.Log("GAME COMPLETE");
            }
            else
            {
                Invoke("Complete", 2f);
            }
        }
        
    }

    private void Complete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
