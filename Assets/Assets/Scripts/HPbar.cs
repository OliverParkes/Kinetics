using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider Slider;
    public GameObject Player;
    public float HP;

    void Update()
    {
        HP = Player.GetComponent<Health>().HP;

        Slider.value = HP;
    }
}
