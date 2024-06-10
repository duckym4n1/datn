using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int dame = 50;
    [SerializeField] 
    private float speed = 1.5f;
    [SerializeField]                                        
    private EnemyData data;
    private bool check = false;                       
    private GameObject player;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!check)
        {
            EnemyMove();
        }
        else
        {
            AttackPlayerMove();
        }
    }

    private void EnemyMove()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    private void AttackPlayerMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(collider.GetComponent<Health>() != null)
            {
                Health health =FindObjectOfType<Health>().GetComponent<Health>();
                health.Damage(dame);
                player = collider.gameObject;
                check = true;
            }
        }
    }
}
