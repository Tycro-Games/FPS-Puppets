using Bog.Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager
{
    public List<EnemySpawner> spawners = new List<EnemySpawner> ();

    public EnemySpawner RandomSpawner ()
    {
        return spawners[Random.Range (0, spawners.Count)];
    }

    public void Spawn (EnemySpawner spawner, GameObject obj, EnemyManager enemyManager)
    {
        GameObject SpawnedObj = spawner.Spawn (obj);

        EnemyBrain dependable = SpawnedObj.GetComponent<EnemyBrain> ();
        dependable.Init (enemyManager);
    }
}