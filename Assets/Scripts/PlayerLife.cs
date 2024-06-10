using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    public Animation animationData;
    public Vector2 knockBack;
    private void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Health health = this.GetComponent<Health>();
            health.Damage(50);
            anim.SetTrigger("hit");
            //Vector2 knock_Back = transform.position - collision.transform.position;
            rb.AddForce(knockBack,ForceMode2D.Impulse);
            if(health.health > 0)
            {
                anim.SetTrigger("notDeath");
            }
            else
            {
                anim.SetTrigger("death");
                Die();
            }
        }
        if(transform.position.y < -10f)
        {
            Health health = this.GetComponent<Health>();
            health.Damage(100);
        }    
    }

    public void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;   
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
