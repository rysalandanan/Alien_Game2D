using UnityEngine;

public class Marine_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float xAxis;
    [SerializeField] private float movementSpeed;

    private bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(rb.velocity.magnitude >= 1)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        SpriteFlip();
    }
    private void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xAxis * movementSpeed, rb.velocity.y);
    }
    private void SpriteFlip()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.01f)
        {
            if (rb.velocity.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
    public bool IsMoving()
    {
        return isMoving;
    }
}
