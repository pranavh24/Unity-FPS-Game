using UnityEngine;
using UnityScript;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

	public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public GameObject target;
    public float targetHealth = 200f;
    
    public float distance = 0.1f;
    public float pushStrength = 1f;

    public AudioClip gunshotClip;
    public AudioSource gunshotSource;

    public Slider healthBar;

    public TextMeshProUGUI winText;
    public GameObject playButton;

    private bool gameOver = false;

    void Start()
    {
        gunshotSource.clip = gunshotClip;
    }

    void Update () {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
		}
	}

	void Shoot() {
        gunshotSource.Play();
        muzzleFlash.Play();

		RaycastHit hit;
	    
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            //Debug.Log(hit.transform.name);
            if (hit.transform.name == "eyeball")
            {
                targetHealth--;

                float currentHealthPct = (float)targetHealth / (float)200;
                healthBar.value = 1 - currentHealthPct;

            }
                Debug.Log(targetHealth);
            if (targetHealth <= 0)
            {
                gameOver = true;
                winText.gameObject.SetActive(true);
                playButton.gameObject.SetActive(true);
            }

            // Target crap
            // Target crap

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
		}	
	}
}

public class ScriptB
{
}