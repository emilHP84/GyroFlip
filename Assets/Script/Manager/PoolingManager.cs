using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] public Dictionary<string, Queue<GameObject>> poolDictionnary;

    private void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();
    }
}
