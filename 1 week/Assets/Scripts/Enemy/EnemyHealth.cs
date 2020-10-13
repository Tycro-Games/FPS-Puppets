using System;
using UnityEngine;

[Serializable]
public class EnemyHealth
{
    [SerializeField]
    private int HP;

    public void ChangeHp (int dg)
    {
        HP += dg;
    }

    public bool HPCheck ()
    {
        if (HP > 0)
            return true;
        return false;
    }
}