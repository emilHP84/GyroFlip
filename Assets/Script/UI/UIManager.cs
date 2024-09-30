using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject carre;
    

    public void Start()
    {
    
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Screenmove()
    {
        carre.transform.DOScaleX(20, 1f);
        carre.transform.DOScaleY(20, 1f);
        carre.transform.DORotate(new Vector3(55.3f,0f,290f), 0.5f, RotateMode.Fast);
    }
}
