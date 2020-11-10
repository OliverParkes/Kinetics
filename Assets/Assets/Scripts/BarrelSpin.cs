using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpin : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(2000 * Time.deltaTime, 0f, 0f);
    }
}
