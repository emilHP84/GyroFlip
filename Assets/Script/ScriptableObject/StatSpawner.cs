using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Spawn")]
public class StatSpawner : ScriptableObject
{
    public GameObject entity;
    [Range(0,5)]public int SpawnNumber;
    public float timeSpeed;
}
