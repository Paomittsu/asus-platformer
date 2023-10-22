using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Platform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HERE");
            Invoke("delayedTile", 0.5f);

        }
    }

    private void delayedTile()
    {
        gameObject.SetActive(false);
    }
}
