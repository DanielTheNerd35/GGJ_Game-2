using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public SpearBehavior spear;
    public Transform spearPosition;

    [Header("Movement")]
    public float mSpeed;
    public float jumpForce;
    float xInput;
    float yInput;

    public bool hasthrown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Movement();

        if (Input.GetKeyDown("space"))
        {
            hasthrown = true;
            spear.rb.linearVelocity = transform.right * spear.speed;
        }
    }
    
    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            rb.velocity = new Vector2(xInput * mSpeed, rb.velocity.y);
        }

        if (Mathf.Abs(yInput) > 0 && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, yInput * jumpForce);

        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
