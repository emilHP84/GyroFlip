using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    [SerializeField]private GameObject muzzle;

    float time;

    private void OnEnable()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.InPause == true) return;
        time += Time.deltaTime;
    }

    public void Shoot()
    {
        if (bullet != null && time > 0.5)
        {
            Instantiate(bullet,muzzle.transform.position,muzzle.transform.rotation,transform.parent = null);
            time = 0;
        }
    }

    private void OnDisable()
    {
        
    }
}
