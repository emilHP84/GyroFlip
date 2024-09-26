using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiManager : MonoBehaviour
{
    

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
    
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,GameManager.gameManagerInstance.targetedtEntity.transform.position,10*Time.deltaTime);
    }
    private void OnDisable()
    {
        
    }
}
