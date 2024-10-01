using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flip_Warning : MonoBehaviour
{
    public GameObject Up_right;
    public GameObject Up_left;
    public GameObject Down_right;
    public GameObject Down_left;

    void Start()
    {
        
    }

    
    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        Down_left.transform.DOScaleY(1.3f, 0.1f).SetLoops(2,LoopType.Yoyo);
        Down_left.transform.DOScaleY(-1.3f, -0.1f).SetLoops(2,LoopType.Yoyo);
        
    }
}
