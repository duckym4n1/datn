using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]public int health = 100;
    [SerializeField] public int maxHealth = 100;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void DamageToEnemy(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;
        /*Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(5f, 5f, 0));*/
        if (health <= 0)
        {
            EnemyLife life = this.GetComponent<EnemyLife>();
            life.Die();
        }
    }
    
}
