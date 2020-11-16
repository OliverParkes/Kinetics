using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunLookAt : MonoBehaviour
{
    public Transform Player;
    public float Speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Position = Player.transform.position - transform.position;
        Quaternion Rotate = Quaternion.LookRotation(Position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Rotate, Speed*Time.deltaTime);
    }
    
}
