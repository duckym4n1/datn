    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite; 
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    private float dirx = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;

    private enum MovementState { idle, running, jumping, falling }
    private MovementState state= MovementState.idle;
    // Start is called before the first frame update
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        sprite= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        coll= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx*moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
       
    }
    private void UpdateAnimationState()
    {
        if (dirx > 0f)
        {
            state= MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX= true;
        }
        else
        {
            state= MovementState.idle;
        }
        if(rb.velocity.y> .1f) 
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return   Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f,Vector2.down, .1f, jumpableGround );
    }
}
