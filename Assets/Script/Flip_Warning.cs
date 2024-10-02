using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip_Warning : MonoBehaviour
{
    public GameObject carre;
    public bool flip;

    void Start()
    {
        Mouvement();
    }

    
    void Update()
    {
        
    }

    void Mouvement()
    {
        if (flip == true )
        {
            FlipAnim();
            carre.transform.DOScale( 0, 0.3f );
            return;
        }
        carre.transform.DOScale(1f, 0.1f).SetLoops(2,LoopType.Yoyo);
        carre.transform.DOScale(4, 0.1f).SetLoops(2,LoopType.Yoyo)
        .SetDelay(.5f)
        .SetEase(Ease.OutElastic).OnComplete(()=>{
            
            Mouvement();
        });
        
    }

    void FlipAnim()
    {
        carre.transform.DOScale(1000, 0.2f);
        flip = false;
    }
}
