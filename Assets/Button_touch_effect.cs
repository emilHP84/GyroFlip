using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.InteropServices.WindowsRuntime;

public class Button_touch_effect : MonoBehaviour
{
    public GameObject bouton;
    public Material material;
    public int countdown;

    public void full()
    {
        material.DOColor(new Vector4(255,255,255,255), 0);
        if (countdown == 5) return;
        countdown+=1;
        Invoke("empty",0.1f);
    }

    void empty()
    {
        material.DOColor(new Vector4(0,0,0,0), 0);
        Invoke("full",0.1f);
    }
}
