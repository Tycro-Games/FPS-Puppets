using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireRater : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField] private float fireRate = 1.0f;

    private float rate = 0;

    public bool FireRate ()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            anim.SetBool ("Shoot", true);

            if (rate < Time.time)
            {
                rate = Time.time + 1 / fireRate;
                return true;
            }
            return false;
        }
        anim.SetBool ("Shoot", false);
        return false;
    }
}