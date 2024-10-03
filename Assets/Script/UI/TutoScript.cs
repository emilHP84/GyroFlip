using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TutoScript : MonoBehaviour
{
    
   public GameObject carre;

    void Start()
    {
        Switch();
    }

    void Switch()
    {
        carre.transform.DORotate(new Vector3(0, 0, 180),0.0001f, RotateMode.Fast);
        Invoke("SwitchRetour", 2);
    }

    void SwitchRetour()
    {
        carre.transform.DORotate(new Vector3(0, 0, 0),0.0001f, RotateMode.Fast);
        Invoke("Switch",2);
    }
}
