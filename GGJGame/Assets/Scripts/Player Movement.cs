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
    private Vector2 movement;
    private bool isGrounded;

    public bool hasthrown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x = input * mSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetButtonDown("Jump") && GetIsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown("space"))
        {
            hasthrown = true;
            spear.rb.linearVelocity = transform.right * spear.speed;
            spear.transform.SetParent(null, true);
        }
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
}
