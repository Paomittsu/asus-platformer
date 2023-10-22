using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scam_Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HERE");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
