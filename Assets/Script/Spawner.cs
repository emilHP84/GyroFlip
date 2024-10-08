using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public StatSpawner stat;
    private GameObject entity => stat.entity;
    private float time;


    void Update()
    {
        if (GameManager.InPause == true) return;
        time += Time.deltaTime;
        if(CheckSpawn() == true )
        {
            Spawn();
        }
    }

    public bool CheckSpawn()
    {
        if(time > stat.timeSpeed)
        {
            time = 0;
            return true;
        }
        else return false;
    }

    public void Spawn()
    {
        for(int i = 0; i < stat.SpawnNumber; i++)
        {
            Instantiate(entity, gameObject.transform.position, gameObject.transform.rotation,transform.parent);
            
        }
        
    }
}
