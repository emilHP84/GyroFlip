using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private BoxCollider m_BoxCollider => GetComponent<BoxCollider>();
    private Rigidbody m_Rigidbody => GetComponent<Rigidbody>();

    [SerializeField] private AudioSource SFXSource;
    public static Transform pos;

    private void OnEnable()
    {
 
    }
    private void Awake()
    {
        m_Rigidbody.useGravity = false;
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;

        m_BoxCollider.isTrigger = true;
        pos = transform;
    }
    private void Start()
    {

    }

    private void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Ennemi"))
        {
            GameManager.IsDead = true;
            GameManager.InPause = true;
            TargetSFX();
        }
    }
    public void TargetSFX()
    {
        SFXSource.Play();
    }
    private void OnDisable()
    {
        
    }
}