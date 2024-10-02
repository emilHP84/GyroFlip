using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiManager : MonoBehaviour
{
    [SerializeField] private StatEnnemi stat;
    private void OnEnable()
    {

    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (GameManager.InPause == true) return;
        Move();
    }

    private void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(stat.target.transform.position.x,0,stat.target.transform.position.z), 2 * Time.deltaTime);
    }
    private void OnDisable()
    {
        
    }
}
 