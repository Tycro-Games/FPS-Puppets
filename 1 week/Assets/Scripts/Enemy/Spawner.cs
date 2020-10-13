using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn (GameObject obj)
    {
        GameObject gameOBJ = Instantiate (obj, transform.position, Quaternion.identity, transform);
    }
}