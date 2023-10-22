using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scam_Platform : MonoBehaviour
{
<<<<<<< HEAD
    public Vector2 dir;
=======
    public GameObject scam;
>>>>>>> parent of 61354d4 (Scam tile)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            dir = collision.contacts[0].normal;
            Debug.Log("HERE");
            if (dir == new Vector2(0,-1))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            

        }
    }
}
