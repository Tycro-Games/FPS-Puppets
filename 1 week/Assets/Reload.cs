using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]
    private int maxBullets;

    private IEnumerator Reloading ()
    {
        audioShooting.Play (muzzleClip);
        yield return new WaitForSeconds (reloadTime);
    }
}