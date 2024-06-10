using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] GameObject ob;
    private bool check = false;
    private SpriteRenderer sprite;
    private GameObject playerHolder;
    private Animator anim;
    public bool flip = false; 
    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (check)
        {
            ob.transform.position = Vector2.MoveTowards(ob.transform.position, playerHolder.transform.position, speed * 2);
        }
        else
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, ob.transform.position) < .1f)
            {
                if(flip)
                {
                    flip= false;
                }
                else
                {
                    flip= true;
                }
                sprite.flipX = flip;
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }

            }
            ob.transform.position = Vector2.MoveTowards(ob.transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
        state = MovementState.running;
        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            check = true;
            playerHolder= other.gameObject;
            Debug.Log(check);
        }
    }
}
