using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    private BoxCollider2D box_collider;
    private Animator anim;
    private SpriteRenderer sprite;
    private enum MovementState { idle, running, jumping, falling }

    private int jumpsLeft = 1;
    private int maxJumps = 1;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpforce = 14;
    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private AudioSource jumpSoundEffect;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        box_collider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);
        /*
        SEM DOUBLE JUMP
        if(Input.GetKeyDown("space") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        */
        if (Input.GetKeyDown("space") && jumpsLeft > 0)
        {
            //Pega o componente Rigidbody e modifica o Vector3 Y
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpsLeft -= 1;
        }
        if (IsGrounded())
        {
            jumpsLeft = maxJumps;
        }
        UpdateAnimationState(dirX);
    }
    private void UpdateAnimationState(float dirX)
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
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
        return Physics2D.BoxCast(box_collider.bounds.center, box_collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
