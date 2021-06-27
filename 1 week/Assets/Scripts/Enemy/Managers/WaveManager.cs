using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private SpawnerManager spawnerManager = new SpawnerManager();
    private EnemyManager enemyManager = new EnemyManager();

    [SerializeField]
    private Wave[] waves;

    private void Awake()
    {
        enemyManager.Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
        {
            spawner.Init(spawnerManager);
        }
        foreach (EnemyBrain enemy in FindObjectsOfType<EnemyBrain>())
        {
            enemy.Init(enemyManager);
        }
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        int index = 0;
        int countEnemies = 0;
        while (true)
        {
            int lastcount = countEnemies;
            index %= waves.Length;
            for (int i = waves[index].Count + lastcount; i > 0; i--)
            {
                spawnerManager.Spawn(spawnerManager.RandomSpawner(), waves[index].Enemy, enemyManager);
                yield return null;
            }
            countEnemies += waves[index].Count;
            yield return new WaitWhile(() => enemyManager.CheckEnemiesAlive());
            index++;
        }
    }
}