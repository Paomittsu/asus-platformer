using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private TilemapRenderer tr;
    private Vector2 startingPosition;
    public GameObject Scam;

    private bool isInvulnerable = false;
    private float invulnerabilityTime = 2f;
    // private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
        tr = Scam.GetComponent<TilemapRenderer>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame

    private void Update()
    {
        if (transform.position.y < -15)
        {
            Die();
        }

        // if(dead == true)
        // {
        //     Die();
        // }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Scam"))
        {
            Debug.Log("JOE MAMA");
            tr.enabled = false;
        }
    }
    private void Die()
    {
        if (isInvulnerable)
        {
            return;
        }
        Scam.GetComponent<SpriteRenderer>().enabled = true;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerMovement>().enabled = false;
        sr.enabled = false;
        Debug.Log("Died!");
        Health.instance.health -= 1;

        if (Health.instance.health <= 0) 
        {
            // rb.bodyType = RigidbodyType2D.Static;
            // GetComponent<PlayerMovement>().enabled = false;
            // sr.enabled = false;
            Debug.Log("DEATHSCREEN HERE!");
            DeathScreen.instance.GameOver();
            return;
        }

        

        isInvulnerable = true;
        Invoke("ResetVulnerability", invulnerabilityTime);
        Invoke("ResetPlayer", 1f);
        // dead = false;

    }

    public void ResetPlayer()
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
