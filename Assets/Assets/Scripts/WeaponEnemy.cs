using UnityEngine;
using System.Collections;

public class WeaponEnemy : MonoBehaviour
{
    public float damage;
    public float range;
    public float firerate;
    public float recoil;
    public LayerMask mask;
    public float spread;
    private bool audioPlaying;

    public GameObject Impact;

    public int m_maxAmmo;
    public int m_currentAmmo;
    public float m_reloadTIme;

    public bool isReloading = false;

    public ParticleSystem MuzzleFlash;
    
    private Rigidbody RB;
    public GameObject Muzzle;
    public AudioSource Gunshot;

    public bool firable;

    public bool Firing;

    private float nextTimetoFire = 0f;

    // Update is called once per frame

    private void Awake()
    {
        m_currentAmmo = m_maxAmmo;
        
    }

    

    private void Update()
    {
        damage = GameManager.Wave;
        firable = TrackingMinigun.fireable;

        if (Firing == true)
        {
            if(firable == false)
            {
                Gunshot.Stop();
                audioPlaying = false;
                return;
            }
            if (isReloading == true)
            {
                Gunshot.Stop();
                audioPlaying = false;
                return;
            }
                
            if (m_currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                Gunshot.Stop();
                audioPlaying = false;
                return;
            }
            if (Time.time >= nextTimetoFire)
            {
                nextTimetoFire = Time.time + 1f / firerate;
                MuzzleFlash.Play();

                playAudio();
                
                Shoot();

                transform.Rotate(200 * Time.deltaTime*10, 0f, 0f);
                
            }
        }
        else
        {
            Gunshot.Stop();
            audioPlaying = false;
        }
            

    }

    public void RoundReset()
    {
        isReloading = false;
        m_currentAmmo = m_maxAmmo;
    }


    void Shoot()
    {
        
        m_currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(Muzzle.transform.position, (Muzzle.transform.forward + Random.insideUnitSphere*spread).normalized, out hit, range, mask))
        {
            Debug.Log(hit.transform.name);

            Health HP = hit.transform.GetComponent<Health>();
            if (HP != null)
            {
                HP.TakeDamage(damage);
            }
            GameObject Explosion = Instantiate (Impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Explosion, 1);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");

        yield return new WaitForSeconds(m_reloadTIme);
        m_currentAmmo = m_maxAmmo;
        isReloading = false;
    }
    public void playAudio()
    {
        if(Gunshot.isPlaying == true)
        {
            return;
        }
        else
            Gunshot.Play();


    }


}
