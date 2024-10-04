using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnnemiManager : MonoBehaviour
{
    [SerializeField] private StatEnnemi stat;
    private BoxCollider box => GetComponent<BoxCollider>();
    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private GameObject deathOne;
    [SerializeField] private GameObject deathTwo;

   private bool isDead;
    private void OnEnable()
    {
        deathOne.SetActive(false);
        deathTwo.SetActive(false);
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
        if(!isDead)Move();
    }

    private void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,Target.pos.position, stat.speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Death();
    }


    private void Death()
    {
        box.isTrigger = true;
        isDead = true;
        DeathSFX();
        StartCoroutine(Dead());
    }

    public void DeathSFX()
    {
        SFXSource.Play();
    }

    IEnumerator Dead()
    {
        deathOne.SetActive(true);
        deathTwo.SetActive(true);
        gameObject.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject,0.5f);
        PoolingManager.instance.SendBackFromPool("EnnemiPool", gameObject);
        yield return null;
        
    }
}
 