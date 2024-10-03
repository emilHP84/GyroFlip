using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonManager : MonoBehaviour
{
    [SerializeField]private GameObject bullet;
    [SerializeField]private GameObject muzzle;
    [SerializeField] private GameObject Gyro;
    [SerializeField] private AudioSource SFXSource;

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
            PoolingManager.instance.SpawnFromPool("BulletPool", muzzle.transform.position, muzzle.transform.rotation, GameManager.gameManagerInstance.gyro.transform) ;
            time = 0;
            ShootSFX();

        }
    }

    public void ShootSFX()
    {
        SFXSource.Play();
    }

    private void OnDisable()
    {
        
    }
}
