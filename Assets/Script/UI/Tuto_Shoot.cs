using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tuto_Shoot : MonoBehaviour
{
    public GameObject carre;

    void Start()
    {
        Grossi();
    }

    void Grossi()
    {
        transform.DOScale(1.2f, 1.5f);
        Invoke("Retreci",1);
    }

    void Retreci()
    {
        transform.DOScale(1, 1.5f);
        Invoke("Grossi",1);
    }
 
}
