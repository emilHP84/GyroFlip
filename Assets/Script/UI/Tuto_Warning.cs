using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tuto_Warning : MonoBehaviour
{
    public GameObject carre;

    void Start()
    {
        Grand();
    }

    void Grand()
    {
        transform.DOScale(1.5f, 1.5f);
        Invoke("Petit",1);
    }

    void Petit()
    {
        transform.DOScale(1, 1.5f);
        Invoke("Grand",1);
    }


}
