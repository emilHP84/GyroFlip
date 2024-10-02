using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnnemiManager : MonoBehaviour
{
    [SerializeField] private StatEnnemi stat;
    private BoxCollider box => GetComponent<BoxCollider>();
    [SerializeField] private AudioSource SFXSource => GetComponent<AudioSource>();

    [SerializeField] private GameObject deathOne;
    [SerializeField] private GameObject deathTwo;

   private bool isDead;
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
        if(!isDead)Move();
    }

    private void Move()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,Target.pos.position, 4f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) Death();
    }


    private void Death()
    {
        box.isTrigger = true;
        isDead = true;
        StartCoroutine(Dead());
    }

    public void DeathSFX()
    {
        SFXSource.Play();
        DeathSFX();
    }

    IEnumerator Dead()
    {
        deathOne.SetActive(true);
        gameObject.transform.DOShakeScale(1, 1, 10, 90, true, ShakeRandomnessMode.Full);
        yield return new WaitForSeconds(2f);
        deathTwo.SetActive(true);
        gameObject.transform.DOScale(0, 0.5f);
        Destroy(gameObject,0.5f);
        yield return null;
    }
}
 