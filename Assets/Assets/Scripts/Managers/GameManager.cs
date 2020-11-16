using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public static int EnemiesList;
    public GameObject EnemyPrefab;

    public GameObject DeathScreen;
    public Text Score;
    public Text Waves;
    public int EnemiesRemaining;
    private bool Reprise;

    public static bool Reset;

    

    public Health Health;
    public TriggerDetection TriggerDetection;
    public WeaponEnemy weaponEnemy;


    public GameObject[] Enemies;
    public Transform[] Spawns;

    public static int Wave = 1;

    private void Awake()
    {
        EnemiesList = Enemies.Length;
    }
    

    IEnumerator NewWave()
    {
        Health.NewWave();
        Reprise = true;

        TriggerDetection.ResetRound();

        yield return new WaitForSeconds(15);

        for(int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(true);
            EnemiesList++;
        }
        Wave++;
        
        Reprise = false;
        weaponEnemy.RoundReset();

    }

    // Update is called once per frame
    void Update()
    {
        Waves.text = "Wave:" + Wave;
        if(Health.isPlayerDead == true)
        {
            RunDeathEvent();
        }
        score = Health.score;

        EnemiesRemaining = Health.EnemiesRemaining;

        if (EnemiesRemaining == 0)
        {
            if(Reprise == true)
            {
                return;
            }
            else
            {
                StartCoroutine(NewWave());
            }
                
            
        }

    }

    void RunDeathEvent()
    {
        DeathScreen.SetActive(true);

        Score.text = "Your Score was " + Wave;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(3);

            Health.NewRound();
            Cursor.lockState = CursorLockMode.None;

            Wave = 1;
            TriggerDetection.ResetRound();
            weaponEnemy.RoundReset();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);

            Cursor.lockState = CursorLockMode.None;

            Health.NewRound();

            Wave = 1;

            TriggerDetection.ResetRound();
            weaponEnemy.RoundReset();
        }

    }
   
}
