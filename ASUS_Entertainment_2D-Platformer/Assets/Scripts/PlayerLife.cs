using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private Vector2 startingPosition;

    private bool isInvulnerable = false;
    private float invulnerabilityTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
    }

    // Update is called once per frame

    private void Update()
    {
        if (transform.position.y < -15)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
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

        ResetPlayer();
    }

    private void ResetPlayer()
    {
        transform.position = startingPosition;
        sr.enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void ResetVulnerability()
    {
        isInvulnerable = false;
    }
}
