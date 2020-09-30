using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private FireRater fireRater;

    private AudioShooting audioShooting;

    private Spawner spawn = null;

    private Reload reload;

    [Header ("Audio")]
    [SerializeField]
    private AudioClip muzzleClip;

    [SerializeField]
    private AudioClip reloadClip;

    [Header ("Effects")]
    [SerializeField]
    private GameObject impact = null;

    [SerializeField]
    private ParticleSystem muzzle;

    [Header ("Shooting")]
    [SerializeField]
    private float range = 200.0f;

    [Header ("Reloading")]
    [SerializeField]
    private int bullets = 30;

    [SerializeField]
    private float reloadTime = 3.0f;

    [SerializeField]
    private LayerMask WhatToShoot = 0;

    public void Shoot ()
    {
        muzzle.Play ();
        audioShooting.Play (muzzleClip);

        Vector3 random = new Vector3 (Random.Range (0f, .1f), Random.Range (0f, .1f), Random.Range (0f, .1f));

        Vector3 dir = transform.forward + random;

        if (Physics.Raycast (transform.position, dir, out RaycastHit hit, range, WhatToShoot))
        {
            Debug.DrawLine (transform.position, hit.point);
            Instantiate (impact, hit.point, Quaternion.LookRotation (hit.normal));
        }
    }

    private void Start ()
    {
        reload = GetComponent<Reload> ();
        audioShooting = GetComponent<AudioShooting> ();
        spawn = GetComponent<Spawner> ();
        fireRater = GetComponent<FireRater> ();
    }

    private void Update ()
    {
        if (fireRater.FireRate ())
        {
            Shoot ();
        }
    }
}