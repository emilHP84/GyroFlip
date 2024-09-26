using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;

    private void OnEnable()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        if (bullet != null)
        {
            Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation,transform.parent = null);
        }
    }

    private void OnDisable()
    {
        
    }
}
