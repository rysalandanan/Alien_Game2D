using UnityEngine;

public class Marine_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xAxis;
    [SerializeField] private float movementSpeed;

    private bool isMoving = false;
    private Marine_Shoot _marine_Shoot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _marine_Shoot = GetComponent<Marine_Shoot>();
    }
    private void Update()
    {
        if(rb.velocity.magnitude >= 1)
        {
            isMoving = true;
            CharacterFlip();
        }
        else
        {
            isMoving = false;
        }
    }
    private void FixedUpdate()
    {
        if (!_marine_Shoot.IsFiring())
        {
            xAxis = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xAxis * movementSpeed, rb.velocity.y);
        }
    }
    private void CharacterFlip()
    {
        Vector3 scale = transform.localScale;
        if (rb.velocity.x < 0)
        {
            scale.x = -1f;
        }
        else if (rb.velocity.x > 0)
        {
            scale.x = 1f;

        }
        transform.localScale = scale;
    }
    public bool IsMoving()
    {
        return isMoving;
    }
}
