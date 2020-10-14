using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public List<EnemyBrain> enemyBrains = new List<EnemyBrain> ();
    private Transform player;

    public Transform Player { get => player; set => player = value; }

    public bool CheckEnemiesAlive ()
    {
        if (enemyBrains.Count == 0)
            return false;
        return true;
    }
}