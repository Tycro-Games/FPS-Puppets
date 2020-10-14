using Bog.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, InitDependable<SpawnerManager>
{
    public void Init (SpawnerManager spawnerManager)
    {
        spawnerManager.spawners.Add (this);
    }

    public GameObject Spawn (GameObject obj)
    {
        return Instantiate (obj, transform.position, Quaternion.identity, transform);
    }
}