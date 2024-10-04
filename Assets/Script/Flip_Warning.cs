using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip_Warning : MonoBehaviour
{
    public GameObject carre;
    public bool flip;

    public void OnEnable()
    {
        GameManager.gameManagerInstance.OnPreFlip += Mouvement;
    }
    void Start()
    {
        carre.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void Mouvement(bool _flip)
    {
        if (_flip == true )
        {
            _flip = false;
            FlipAnim();
            return;
        }
        else if (_flip == false )
        {
            carre.SetActive(true);
            carre.transform.DOScale(1f, 0.1f).SetLoops(2, LoopType.Yoyo);
            carre.transform.DOScale(4, 0.1f).SetLoops(2, LoopType.Yoyo).SetDelay(.5f).SetEase(Ease.OutElastic);//.OnComplete(()=>{ Mouvement(_flip); });
            return;
        }
    }

    public void FlipAnim()
    {
        carre.transform.DOScale(100, 0.2f);
        carre.transform.DOScale(4, 0.3f).OnComplete(() => { carre.SetActive(false); });
    }

    public void OnDisable()
    {
        GameManager.gameManagerInstance.OnPreFlip -= Mouvement;
    }
}
