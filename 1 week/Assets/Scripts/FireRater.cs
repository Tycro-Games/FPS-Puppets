using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireRater : MonoBehaviour
{
    [SerializeField] private float fireRate = 1.0f;

    private float rate = 0;

    public bool IsPressing ()
    {
        if (Mouse.current.leftButton.isPressed)
            return true;
        return false;
    }

    public bool FireRate ()
    {
        if (IsPressing ())
        {
            if (rate < Time.time)
            {
                rate = Time.time + 1 / fireRate;
                return true;
            }
        }

        return false;
    }
}