using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { left = -1, right = 1 }

public class Parallax : MonoBehaviour
{

    [SerializeField]
    private float linearSpeed = 1f;
    [SerializeField]
    private Direction direction;
    [SerializeField]
    private Transform partner;

    private float boundX;
    private Transform m_transform;

    private Vector3 position { get { return m_transform.position; } set { m_transform.position = value; } }

    private void Start()
    {
        boundX = GetComponent<SpriteRenderer>().bounds.size.x;
        m_transform = transform;
    }

    private void FixedUpdate()
    {
            MoveBackground();
    }

    private void MoveBackground()
    {
        if (position.x <= ((int)direction * boundX))
        {
            position = new Vector3(partner.position.x + boundX, position.y, 0);
        }

        m_transform.Translate(m_transform.right * (int)direction * Time.fixedDeltaTime * linearSpeed);
    }

}
