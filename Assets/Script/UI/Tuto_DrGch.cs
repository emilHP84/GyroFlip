using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tuto_DrGch : MonoBehaviour
{

    public GameObject carre;

    void Start()
    {
        DriftD();
    }

    void DriftD()
    {
        carre.transform.DORotate(new Vector3(0, 0, -45),1, RotateMode.Fast);
        Invoke("DriftG", 2);
    }

    void DriftG()
    {
        carre.transform.DORotate(new Vector3(0, 0, 45),1, RotateMode.Fast);
        Invoke("DriftD",2);
    }
}
