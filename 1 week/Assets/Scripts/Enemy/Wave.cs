using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new wave", menuName = "Create/new wave")]
public class Wave : ScriptableObject
{
    [SerializeField]
    private int count;

    [SerializeField]
    private GameObject enemy;

    public int Count { get => count; }
    public GameObject Enemy { get => enemy; }
}