using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public static bool InGame = true;
    public static bool IsDead = false;

    public GameObject targetedtEntity;

    private float timer;

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

    public void Update()
    {

    }
    public void OnDisable()
    {
        
    }
}
