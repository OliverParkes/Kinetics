using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponMenu : MonoBehaviour
{
    public static int WeaponNumber;
    

    // Update is called once per frame
    public void M82()
    {
        WeaponNumber = 1;
        SceneManager.LoadScene(3);
    }
    public void AK47()
    {
        WeaponNumber = 2;
        SceneManager.LoadScene(3);
    }
    public void P90()
    {
        int Rand = Random.Range(1, 50);
        if (Rand == 50)
        {
            WeaponNumber = 5;
        }
        else
        {
            WeaponNumber = 3;
        }
        
        SceneManager.LoadScene(3);
    }
    public void Shotgun()
    {
        WeaponNumber = 4;
        SceneManager.LoadScene(3);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Controls()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
