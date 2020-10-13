using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitFelt : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onHit;

    [SerializeField]
    private EnemyHealth enemyHealth;

    public void OnHit (int dg)
    {
        if (!enemyHealth.HPCheck ())
        {
            onHit?.Invoke ();
            Destroy (gameObject);
        }
        else
        {
            enemyHealth.ChangeHp (-dg);
        }
    }
}