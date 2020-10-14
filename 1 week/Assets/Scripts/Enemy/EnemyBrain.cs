using Bog.Assets.Scripts;
using UnityEngine;

public class EnemyBrain : MonoBehaviour, InitDependable<EnemyManager>, Deinit
{
    private EnemyManager enemyManager = null;
    private Transform player;

    private EnemyMovement enemyMovement;

    public void DeInit ()
    {
        enemyManager.enemyBrains.Remove (this);
    }

    public void Init (EnemyManager enemyManager)
    {
        this.enemyManager = enemyManager;

        player = enemyManager.Player;

        enemyManager.enemyBrains.Add (this);
    }

    private void Start ()
    {
        enemyMovement = GetComponent<EnemyMovement> ();
        enemyMovement.SetDestination (player);
    }

    private void OnDestroy ()
    {
        DeInit ();
    }
}