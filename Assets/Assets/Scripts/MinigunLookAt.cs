using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunLookAt : MonoBehaviour
{

    public Transform Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player);
    }
    
}
