using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("transition")]
    public GameObject carre;

    [Header("restart screen")]
    public GameObject panelRestart;

    [Header("worldSpace UI")]
    public GameObject shootButtonOne;
    public GameObject shootButtonTwo;

    private void Awake()
    {
        shootButtonOne.SetActive(false);
        shootButtonTwo.SetActive(true);
        panelRestart.SetActive(false);
    }
    public void Start()
    {
        GameManager.gameManagerInstance.OnFlip += ShootButton;
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

    void ShootButton()
    {
        
        if (shootButtonTwo && shootButtonOne == null) return;
        
        if (shootButtonTwo.activeSelf == true)
        {
            shootButtonTwo.SetActive(false);
            shootButtonOne.SetActive(true);
            return;
        }

        if (shootButtonOne.activeSelf == true)
        {
            shootButtonTwo.SetActive(true);
            shootButtonOne.SetActive(false);
            return;
        }
    }

    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= ShootButton;
    }
}
