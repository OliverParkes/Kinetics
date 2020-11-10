using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float range;
    public float firerate;
    public float recoil;
    public float spread;

    public int m_maxAmmo;
    public static int m_currentAmmo;
    public float m_reloadTIme;

    public LayerMask Mask;

    private bool isReloading = false;

    public Camera FPScam;

    public ParticleSystem MuzzleFlash;
    public AudioSource Gunshot;

    public GameObject Impact;
    private Rigidbody RB;

    public GameObject AmmoCount;
    public Image progress;
    

    private float nextTimetoFire = 0f;

    // Update is called once per frame

    private void Awake()
    {
        m_currentAmmo = m_maxAmmo;
    }
    private void Start()
    {

        RB = GetComponentInParent<Rigidbody>();
    }
    void Update()
    {
        if(isReloading == true)
        {
            progress.fillAmount -= Time.deltaTime/m_reloadTIme;
        }
        AmmoCount.GetComponent<Text>().text = "Ammo: " + m_currentAmmo + "/" + m_maxAmmo;
        if (isReloading == true)
        {
            Gunshot.Stop();
            return;
        }
            
        if (m_currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            m_currentAmmo = 0;
            StartCoroutine(Reload());
            Gunshot.Stop();
            return;
        }
        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= nextTimetoFire)
            {
                nextTimetoFire = Time.time + 1f / firerate;
                MuzzleFlash.Play();
                Shoot();
                PlayAudio();
            }
        }
        else
        {
            Gunshot.Stop();
        }
            
    }

    void Shoot()
    {
        m_currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, (FPScam.transform.forward + Random.insideUnitSphere*spread).normalized, out hit, range, Mask))
        {
            Debug.Log(hit.transform.name);

            Health HP = hit.transform.GetComponent<Health>();
            if (HP != null)
            {
                HP.TakeDamage(damage);
            }
            GameObject Explosion = Instantiate(Impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Explosion, 1);
        }
    }
    void PlayAudio()
    {
        if(Gunshot.isPlaying == true)
        {
            return;
        }
        else
        {
            Gunshot.Play();
        }
       
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        progress.fillAmount = 1;

        yield return new WaitForSeconds(m_reloadTIme);
        m_currentAmmo = m_maxAmmo;
        isReloading = false;
    }
}
