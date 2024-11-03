using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float upForce = 200;
    private bool isDead = false;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private ParticleSystem deathParticles;
    public AudioSource dyingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        deathParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Flap();
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        if (!isDead)
        {
            isDead = true;

            sprite.enabled = false;

            deathParticles.Play();

            dyingSound.Play();

            GameController.instance.PlayerDied();
        }
    }

    private void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, upForce));
        anim.Play("Miku Flap");
    }
}
