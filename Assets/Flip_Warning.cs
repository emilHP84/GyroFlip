using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip_Warning : MonoBehaviour
{
    public GameObject carre;

    void Start()
    {
        movimiento();
    }

    
    void Update()
    {
        
    }

    void movimiento()
    {
        carre.transform.DOScale(1f, 0.1f).SetLoops(2,LoopType.Yoyo)
        .SetDelay(.5f)
        .SetEase(Ease.OutElastic).OnComplete(()=>{
            
            movimiento();
        });
        
    }
    
    void balle()
    {
        carre.transform.DOScale(4, 0.1f).SetLoops(2,LoopType.Yoyo);
    }
}
