using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponSemi : MonoBehaviour
{
    public float damage;
    public float range;
    public float firerate;
    public float recoil;
    public float Mass;

    public int m_maxAmmo;
    public static int m_currentAmmo;
    public float m_reloadTIme;

    private bool isReloading = false;

    public Camera FPScam;

    public ParticleSystem MuzzleFlash;
    private Rigidbody RB;
    public AudioSource Gunshot;

    public LayerMask Mask;
    public GameObject Impact;

    private Vector3 Recoilforce;

    private float nextTimetoFire;

    public GameObject AmmoCount;
    public Image progress;
    

    // Update is called once per frame

    private void Awake()
    {
        m_currentAmmo = m_maxAmmo;
        RB = GetComponentInParent<Rigidbody>();
    }
    private void Start()
    {
        RB.mass = RB.mass + Mass;

        Recoilforce = recoil * this.transform.forward * -1;
    }
    void Update()
    {
        if (isReloading == true)
        {
            progress.fillAmount -= Time.deltaTime/m_reloadTIme;
        }
        AmmoCount.GetComponent<Text>().text = "Ammo: " + m_currentAmmo + "/" + m_maxAmmo; ;
        if (isReloading == true)
            return;
        if (m_currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            m_currentAmmo = 0;
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimetoFire)
        {
            
            nextTimetoFire = Time.time + 1f / firerate;

            MuzzleFlash.Play();
            Shoot();
            RB.AddForceAtPosition(Recoilforce, this.transform.position);

        }
    }

    void Shoot()
    {
        Gunshot.Play();
        m_currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, range, Mask))
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

    
