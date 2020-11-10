using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    
    public Health Health;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Health.Die();
        }
    }
}
