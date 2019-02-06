using UnityEngine;

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

    void Update () {
		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
		}
	}

	void Shoot() {
        muzzleFlash.Play();

		RaycastHit hit;
		
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            //Debug.Log(hit.transform.name);
            if (hit.transform.name == "eyeball") targetHealth--;
            //Debug.Log(targetHealth);
            if (targetHealth <= 0) Destroy(target);

            // Target crap
            // Target crap

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
		}	
	}
}
