using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Platform : MonoBehaviour
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
                Invoke("delayedTile", 0.5f);
            }

        }
    }

    private void delayedTile()
    {
        gameObject.SetActive(false);
        Invoke("activateTile", 1.5f);
    }

    private void activateTile()
    {
        gameObject.SetActive(true);
    }
}
