using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    //number of hit
    private bool hasHit;
    private int hitCount = 0;

    //move of bullet 
    private float speed = 25;

    //time between death
    private float time;
    private void OnEnable()
    {
        gameObject.transform.parent = null;
    }
    public void Update()
    {
        time += Time.deltaTime;
        move();
        if(hasHit)
        {
            hitCount += 1;
            hasHit = false;
        }

        if(hitCount >= 3 || time > 8) 
        {
            Death();
        }
    }

    private void move()
    {
        gameObject.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
    }

    
    private void Death()
    {
        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            hasHit = true;
        }
    }
}
