using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject carre;
    public GameObject panelRestart;

    private void Awake()
    {
        panelRestart.SetActive(false);
    }
    public void Start()
    {
        
    }

    private void Update()
    {
        if(GameManager.IsDead == true)
        {
            ActivePanel();
        }
    }
    public void Play()
    {
        GameManager.InPause = false;
        GameManager.IsDead = false;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void ActivePanel()
    {
        if (panelRestart == null) return;
        panelRestart.SetActive(true);
        GameManager.InPause = true;
    }
    void ScreenMove()
    {
        if (carre == null) return;
        carre.transform.DOScaleX(20, 1f);
        carre.transform.DOScaleY(20, 1f);
        carre.transform.DORotate(new Vector3(55.3f,0f,290f), 0.5f, RotateMode.Fast);
    }
}
