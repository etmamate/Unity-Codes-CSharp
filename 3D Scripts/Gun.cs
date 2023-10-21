using System;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;

    [SerializeField] private float fireRate = 15f;
    [SerializeField] private float impactForce = 30f;

    [SerializeField] private float nextTimeToFire = 0f;
    public Transform shootPoint;
    private LineRenderer _lineRenderer;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    void Update()
    {
        /* Tiro semi automatico
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        */
        _lineRenderer = shootPoint.GetComponent<LineRenderer>();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Takedamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGo = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 1.3f);
        }

    }
}
