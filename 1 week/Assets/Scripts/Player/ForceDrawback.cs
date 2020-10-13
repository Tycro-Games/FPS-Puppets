using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDrawback : MonoBehaviour
{
    [SerializeField]
    private float force = 5.0f;

    [SerializeField]
    private ForceMode mode;

    private void OnParticleCollision (GameObject other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody> ();

        if (rb)
        {
            rb.AddForce (-transform.forward * force, mode);
        }
    }
}