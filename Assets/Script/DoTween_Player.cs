using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOLocalMoveY(endValue: 1.0f, duration: 3.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        gameObject.transform.DOLocalMoveX(endValue: 0.5f, duration: 1.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
