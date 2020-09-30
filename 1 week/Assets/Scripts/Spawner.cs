using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn (GameObject obj, Transform tr)
    {
        GameObject muzzle = Instantiate (obj, tr.position, tr.rotation, tr);
        Destroy (muzzle, 3.0f);
    }
}