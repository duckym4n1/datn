using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private GameObject target;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        //anim.SetTrigger("death");
        Destroy(target);    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "trap")
        {
            EnemyHealth heal = GetComponent<EnemyHealth>();
            heal.DamageToEnemy(500);
        }
    }
}
