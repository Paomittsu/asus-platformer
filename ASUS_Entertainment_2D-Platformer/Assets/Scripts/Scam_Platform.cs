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
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            

        }
    }
}
