using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private TilemapRenderer tr;
    private Vector2 startingPosition;
    public Tilemap Scam;

    private bool isInvulnerable = false;
    private float invulnerabilityTime = 4.0f;
    private float timer = 3.0f;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        tr = Scam.GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (transform.position.y < -15)
        {
            Die();
        }

        if(dead == true)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            dead = true;
        }
        if (collision.gameObject.CompareTag("Scam"))
        {
            Debug.Log("JOE MAMA");
            tr.enabled = false;
        }
    }
    private void Die()
    {
        Debug.Log("Died!");
        timer -= Time.deltaTime;
        rb.bodyType = RigidbodyType2D.Static;
        // if (timer < 0)
        // {
        //     timer = 3.0f;
        //     Debug.Log("RESPAWN");
        //     ResetPlayer();
        //     dead = false;
        // }

       
        if (isInvulnerable)
        {
            return;
        }
        
        if (Health.instance.health != 0)
        {
            Health.instance.health -= 1;
        }

        GetComponent<PlayerMovement>().enabled = false;
        sr.enabled = false;

        isInvulnerable = true;
        Invoke("ResetVulnerability", invulnerabilityTime);
        Invoke("ResetPlayer", 1f);
        dead = false;

    }

    private void ResetPlayer()
    {
        transform.position = startingPosition;
        sr.enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void ResetVulnerability()
    {
        isInvulnerable = false;
    }
}
