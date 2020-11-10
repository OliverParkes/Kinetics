using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTarget : MonoBehaviour
{
    public float m_DampTime = 0.2f;
    public Transform m_target;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    private void Awake()
    {
        transform.position = m_target.transform.position;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position,
        m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
}

