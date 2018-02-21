using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField]
    private float linearSpeed = 1f;
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private float leftLimit = 9.5f;

    public bool active { get; set; }

    private Transform m_transform;
    private Collider2D col;
    private SpriteRenderer sr;

    private Vector3 position { get { return m_transform.position;  } set { m_transform.position = value; } }

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        m_transform = transform;
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if (!active)
        {
            return;
        }
        if (position.x < (int)direction * leftLimit)
        {
            SetActive(false);
        }
        m_transform.Translate(Vector3.right * (int)direction * Time.deltaTime * linearSpeed);
    }

    public void SetActive(bool flag)
    {
        active = flag;
        sr.enabled = flag;
        var newPosition = position;
        newPosition.x = (flag) ? leftLimit : (int)(direction) * leftLimit;
        position = newPosition;
    }

    private void Destroy()
    {
        Destroy(gameObject, 0);
    }
}
