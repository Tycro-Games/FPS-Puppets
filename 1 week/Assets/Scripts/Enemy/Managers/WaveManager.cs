using System;
using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private SpawnerManager spawnerManager = new SpawnerManager ();
    private EnemyManager enemyManager = new EnemyManager ();

    [SerializeField]
    private Wave[] waves;

    private void Awake ()
    {
        enemyManager.Player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    private void Start ()
    {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner> ())
        {
            spawner.Init (spawnerManager);
        }
        foreach (EnemyBrain enemy in FindObjectsOfType<EnemyBrain> ())
        {
            enemy.Init (enemyManager);
        }
        StartCoroutine (StartWaves ());
    }

    private IEnumerator StartWaves ()
    {
        int index = 0;
        while (true)
        {
            foreach (EnemySpawner spawner in spawnerManager.spawners)
            {
                for (int i = waves[index % waves.Length].Count; i > 0; i--)
                {
                    spawnerManager.Spawn (spawner, waves[index % waves.Length].Enemy, enemyManager);
                    yield return null;
                }
            }
            yield return new WaitWhile (() => enemyManager.CheckEnemiesAlive ());
            index++;
            index %= waves.Length;
        }
    }
}