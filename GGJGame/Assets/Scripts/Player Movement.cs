using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public SpearBehavior spear;
    public Transform spearPosition;
    public Animator anim;

    [Header("Movement")]
    public float mSpeed;
    public float jumpForce;
    private float horizontal;
    private bool isFacingRight = true;

    [Header("Spear")]
    public bool hasthrown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

        void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * mSpeed, rb.linearVelocity.y);
    }

    // Update is called once per frame every second
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            anim.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown("space"))
        {
             if (!hasthrown)
            {
                ThrowSpear();
            }
            else
            {
                spear.TeleportPlayer();
            }
        }

        Flip();
    }

    void ThrowSpear()
    {
        hasthrown = true;

        spear.transform.SetParent(null, true);

        float direction = isFacingRight ? 1f : -1f;

        spear.rb.linearVelocity = new Vector2(direction * spear.speed, 0f);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
}
