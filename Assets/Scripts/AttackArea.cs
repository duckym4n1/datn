using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    private int damage = 0;
    private void Start()
    {
        damage = (int)Random.Range(25f, 38f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
