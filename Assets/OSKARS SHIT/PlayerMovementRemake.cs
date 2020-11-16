using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRemake : MonoBehaviour
{
    public Rigidbody Aoba;

    private float sensitivity = 50f;
    private float sensMultiplier = 1f;

    public float rotationSpeed = 1f;

    void Start()
    {
        Aoba = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        Aoba.rotation = Quaternion.Euler(Aoba.rotation.eulerAngles + new Vector3(rotationSpeed * Input.GetAxis("Mouse Y") * -1, rotationSpeed * Input.GetAxis("Mouse X"), 0f));
    }
}
