using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiManager : MonoBehaviour
{
    private NavMeshAgent entity;

    private void Awake()
    {
        entity = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
    
    }
    private void Start()
    {
        if (GameManager.InGame && entity != null)
        {
            entity.destination = GameManager.gameManagerInstance.targetedtEntity.transform.localPosition;
        }
    }
    private void Update()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
