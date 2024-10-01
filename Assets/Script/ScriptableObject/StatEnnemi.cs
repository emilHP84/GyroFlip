using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ennemi")]
public class StatEnnemi : ScriptableObject
{
    public GameObject target;
    public float speed;
}
