using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private BoxCollider m_BoxCollider => GetComponent<BoxCollider>();
    private Rigidbody m_Rigidbody => GetComponent<Rigidbody>();

    private void OnEnable()
    {
 
    }
    private void Awake()
    {
        m_Rigidbody.useGravity = false;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        m_BoxCollider.isTrigger = true;
    }
    private void Start()
    {

    }
    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            GameManager.IsDead = true;
            GameManager.InPause = true;
        }
    }
    private void OnDisable()
    {
        
    }
}