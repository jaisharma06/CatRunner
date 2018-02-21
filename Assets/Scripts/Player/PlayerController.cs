using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float jumpVelocity = 5f;
    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    private void OnEnable()
    {
        EventManager.OnTouchBegin += Jump;
        EventManager.OnTouchEnd += OnTouchEnd;
    }

    private void Start()
    {
        Initialize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            Kill();
        }
    }

    private void OnDisable()
    {
        EventManager.OnTouchBegin -= Jump;
        EventManager.OnTouchEnd -= OnTouchEnd;
    }

    private void Initialize()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void Kill()
    {
        Destroy(gameObject, 0);
    }

    private void OnTouchEnd()
    {
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - (sr.bounds.size.y / 2), 0), Color.green, 0.5f);
        return Physics2D.Raycast(transform.position, Vector2.down, (sr.bounds.size.y / 2), groundLayer);
    }
}
