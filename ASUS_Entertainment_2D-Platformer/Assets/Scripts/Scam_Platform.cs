using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scam_Platform : MonoBehaviour
{
    public Vector2 dir;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            dir = collision.contacts[0].normal;
            Debug.Log("HERE");
            if (dir == new Vector2(0,-1))
            {
                Invoke("delay", 0.5f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
        Invoke("activate", 1.5f);
    }
    private void delay()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void activate()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
