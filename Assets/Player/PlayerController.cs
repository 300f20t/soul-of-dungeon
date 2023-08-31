using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float timeToStop = 0.1f;
    public float slowdownFactor = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float timeSinceLastMove = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        timeSinceLastMove += Time.deltaTime;
        if (moveDirection.magnitude > 0)
        {
            timeSinceLastMove = 0;
        }
    }

    void FixedUpdate()
    {
        if (timeSinceLastMove > timeToStop)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = moveDirection * moveSpeed;
        }

        if (moveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public Quaternion GetPlayerRotation()
    {
        return transform.rotation;
    }
}
