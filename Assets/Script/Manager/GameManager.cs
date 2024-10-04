using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public static bool InGame = true;
    public static bool InPause = false;
    public static bool IsDead = false;

    private float timer = 0;
    private float dTime = 8;
    private bool PreFlipIsActive = false;

    [SerializeField] public GameObject gyro;
    [SerializeField] private AudioSource SFXSource;

    public void OnEnable()
    {

    }

    public void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else if (gameManagerInstance != this)
        {
            Destroy(gameObject); 
        }
    }
    public void Start()
    {

    }
    

    public delegate void OnFlipDelegate();
    public event OnFlipDelegate OnFlip;
    private void Flip() 
    {
        OnFlip?.Invoke();
    }

    public delegate void OnPreFlipDelegate(bool flip);
    public event OnPreFlipDelegate OnPreFlip;
    private void PreFlip(bool flip)
    {
        OnPreFlip?.Invoke(flip);
    }

    public void Update()
    {
        if (InPause || IsDead) return;
        TimerDecrement();

        if (timer > dTime -2)
        {
            if(PreFlipIsActive == false)
            {
                PreFlipSFX();
                PreFlip(false);
                PreFlipIsActive = true;
            }
                
        }
    }   

    private void TimerDecrement()
    {
        timer += Time.deltaTime;
        if (timer > dTime)
        {
            if (dTime > 2.5f)
            {
                timer = 0;
                dTime -= 0.2f;
                Flip();
                PreFlip(true);
                PreFlipIsActive = false;
            }
            else
            {
                timer = 0;
                Flip();
                PreFlip(true);
                PreFlipIsActive = false;
            }
        }
    }

    public void PreFlipSFX()
    {
       SFXSource.Play();
    }

    public void OnDisable()
    {

    }
}
