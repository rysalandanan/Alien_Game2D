using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xAxis;

    [Header("Player's Speed Value:")]
    [SerializeField] private float movementSpeed;

    private bool isMoving = false;

    private Player_Attack player_Attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player_Attack = GetComponent<Player_Attack>();
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
        if (!player_Attack.IsFiring())
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
