using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fireGraphics : MonoBehaviour
{



    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);

            }
            if (Input.GetMouseButtonUp(0))
            {
                transform.localEulerAngles = new Vector3(-10, 130, 0);
            }
    }
}
