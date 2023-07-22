using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSoundEffect;
    //[SerializeField] private float moveSpeed = 2f;
    //[SerializeField] private float jumpForce = 7f;
    private float moveSpeed = 8f;
    private float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x,  jumpForce);
        }
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            //anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
           //anim.SetBool("running", false);
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
