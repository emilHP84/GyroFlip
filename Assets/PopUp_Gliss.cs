using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PopUp_Gliss : MonoBehaviour
{
   
    void Start()
    {
        transform.DOMove(new Vector3(0, 0, 4),5);
        
    }

  
}
