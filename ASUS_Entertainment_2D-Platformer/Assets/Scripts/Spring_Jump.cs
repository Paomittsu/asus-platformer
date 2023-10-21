using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_Jump : MonoBehaviour
{
    private float bounce = 20f;
    public Vector2 dir;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dir = collision.contacts[0].normal;

            if (dir == new Vector2(0,-1))
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }






            
            
        }
    }
}
