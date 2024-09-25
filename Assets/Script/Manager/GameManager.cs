using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public static bool InGame = true;
    public static bool IsDead = false;

    public GameObject targetedtEntity;

    private float timer = 0;
    private float dTime = 8;

    public void OnEnable()
    {

    }

    public void Awake()
    {
        gameManagerInstance = this;
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

    public void Update()
    {
        TimerDecrement();
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
            }
            else
            {
                timer = 0;
                Flip();
            }
        }
    }
    public void OnDisable()
    {

    }
}
