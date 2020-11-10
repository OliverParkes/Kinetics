using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;
    public int MaxHP;
    public static int score;
    public GameObject Player;
    public GameObject Fire;
    public int EnemiesList;
    public static bool isPlayerDead = false;

    public static int EnemiesRemaining;

    public Transform Target;

    private void Start()
    {
        EnemiesList = GameManager.EnemiesList;
        NewWave();
    }

    public void NewWave()
    {
        EnemiesRemaining = EnemiesList;
        HP = MaxHP;
    }
    private void Update()
    {
        

        if (HP >= MaxHP)
        {
            HP = MaxHP;
        } 

    }
    public void TakeDamage(float Amount)
    {
        HP -= Amount;
        if (HP <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        if (this.tag != "Player")
        {
            Player.GetComponent<Health>().HP = Player.GetComponent<Health>().HP + 20f;
            score++;
            GameObject DeathFlame = Instantiate(Fire, Target);
            DeathFlame.transform.localScale = new Vector3(500f, 500f, 500f);
            DeathFlame.transform.parent = null;
            EnemiesRemaining--;
            Destroy(DeathFlame, 10);
            HP = MaxHP;
            this.gameObject.SetActive(false);

        }

        if(this.tag == "Player")
        {
            GameObject DeathFlame = Instantiate(Fire, Target);
            DeathFlame.transform.localScale = new Vector3(50f, 50f, 50f);
            DeathFlame.transform.parent = null;
            Destroy(DeathFlame, 10);
            Camera.main.transform.parent = null;
            GameObject WeaponCam = GameObject.FindGameObjectWithTag("PlayerCamera");
            WeaponCam.SetActive(false);
            isPlayerDead = true;
            gameObject.SetActive(false);
        }

    }

     public void NewRound()
    {
        isPlayerDead = false;
    }
}
