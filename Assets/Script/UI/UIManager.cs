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

    [SerializeField] private AudioSource SFXSource;

    private void Awake()
    {
        if (shootButtonOne == null || shootButtonTwo == null || panelRestart == null)return;
        shootButtonOne.SetActive(false);
        shootButtonTwo.SetActive(true);
        panelRestart.SetActive(false);
    }
    public void Start()
    {
        GameManager.gameManagerInstance.OnFlip += ShootButton;
        if (shootButtonOne == null || shootButtonTwo == null || panelRestart == null) return;
        panelRestart.transform.DOScale(new Vector3(0, 0, 0), 0f);
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
        if ( shootButtonOne == null || shootButtonTwo == null || panelRestart == null) return;
        panelRestart.transform.DOScale(new Vector3(0, 0, 0), 1f);
        StartCoroutine(ChangeScene());
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void ActivePanel()
    {
        if (panelRestart == null) return;
        panelRestart.SetActive(true);
        
        panelRestart.transform.DOScale(new Vector3(1, 1, 1), 1f);
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
        if (shootButtonOne == null || shootButtonTwo == null || panelRestart == null) return;
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

    public void ButtonSFX()
    {
        SFXSource.Play();
    }

    IEnumerator ChangeScene()
    {
        ScreenMove();
        yield return new WaitForSeconds(1);
        GameManager.InPause = false;
        GameManager.IsDead = false;
        SceneManager.LoadScene(1);
        yield return null;
    }

    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= ShootButton;
    }
}
