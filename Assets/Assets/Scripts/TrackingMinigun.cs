using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMinigun : MonoBehaviour
{
    public Transform Player;
    public GameObject turret;
    private Behaviour lookAt;
    public LayerMask mask;
    public Behaviour BRRRT;
    

    public static bool fireable;
    private void Start()
    {
        lookAt = turret.GetComponent<MinigunLookAt>();
        
        
    }
    void Update()
    {
        transform.LookAt(Player);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 99999999, mask))
        {

            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Player")
            {
                lookAt.enabled = true;
                fireable = true;
                

            }
            else
            {
                lookAt.enabled = false;
                fireable = false;
            }
                
        }
        
        
    }
}
