using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [HideInInspector]
    public bool Isreload = false;

    public IEnumerator Reloading (float waitTime)
    {
        Isreload = true;

        yield return new WaitForSeconds (waitTime);
        Isreload = false;
    }
}