using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    public static bool Firing = false;

    public GameObject barrelL;
    public GameObject barrelR;

    public bool FireLocal;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            barrelL.GetComponent<WeaponEnemy>().Firing = true;
            barrelR.GetComponent<WeaponEnemy>().Firing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            barrelL.GetComponent<WeaponEnemy>().Firing = false;
            barrelR.GetComponent<WeaponEnemy>().Firing = false;
        }
    }

    private void Update()
    {
        FireLocal = Firing;
    }

    public void ResetRound()
    {
        Firing = false;
    }
}
