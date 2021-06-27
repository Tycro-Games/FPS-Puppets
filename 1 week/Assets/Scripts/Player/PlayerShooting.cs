using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private int maxBullets;
    private FireRater fireRater;

    private AudioShooting audioShooting;

    private AudioShooting reloadShooting;
    private Reload reload;

    private EnemySpawner spawn = null;

    [Header("Audio")]
    [SerializeField]
    private AudioClip muzzleClip;

    [SerializeField]
    private AudioClip[] reloadClip;

    private int currentIndex = 0;

    [Header("Animation")]
    [SerializeField]
    private Animator anim;

    [Header("Effects")]
    [SerializeField]
    private GameObject impact = null;

    [SerializeField]
    private GameObject muzzle;

    private CinemachineImpulseSource cinemachineImpulseSource;

    [SerializeField]
    private float muzzleFreq = .5f;

    [Header("Shooting")]
    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private float range = 200.0f;

    [SerializeField]
    private LayerMask WhatToShoot = 0;

    [Header("Reloading")]
    [SerializeField]
    private int bullets = 30;

    private float reloadTime = 0.9f;
    private Transform camTr = null;

    public void Shoot()
    {
        bullets--;

        if (Random.Range(0f, 1f) <= muzzleFreq)
        {
            muzzle.SetActive(true);
            cinemachineImpulseSource.GenerateImpulse();
        }
        audioShooting.Play(muzzleClip);

        // Vector3 random = new Vector3 (Random.Range (0f, .1f), Random.Range (0f, .1f),
        // Random.Range (0f, .1f));

        Vector3 dir = camTr.forward;

        if (Physics.Raycast(camTr.position, dir, out RaycastHit hit, range, WhatToShoot))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<HitFelt>().OnHit(damage);
            }

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
        if (bullets <= 0)
        {
            Reloading();
        }
    }

    public void Reloading()
    {
        if (maxBullets != bullets && !reload.Isreload)
        {
            currentIndex = (currentIndex + 1) % reloadClip.Length;
            audioShooting.Play(reloadClip[currentIndex]);
            anim.Play("Reload");
            StartCoroutine(reload.Reloading(reloadTime));
            bullets = maxBullets;
        }
    }

    private void Start()
    {
        cinemachineImpulseSource = muzzle.GetComponent<CinemachineImpulseSource>();
        camTr = Camera.main.transform;

        audioShooting = GetComponent<AudioShooting>();
        reload = GetComponent<Reload>();
        spawn = GetComponent<EnemySpawner>();
        fireRater = GetComponent<FireRater>();
        reloadShooting = transform.GetChild(0).GetComponent<AudioShooting>();
        anim = GetComponentInChildren<Animator>();
        maxBullets = bullets;
    }

    private void Update()
    {
        if (fireRater.FireRate() && !reload.Isreload && bullets > 0)
        {
            Shoot();
        }

        SyncAnim();
    }

    private void SyncAnim()
    {
        anim.SetBool("Reload", reload.Isreload);
        anim.SetBool("Shoot", fireRater.IsPressing() && !reload.Isreload);
    }
}