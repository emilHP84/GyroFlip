using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipManager : MonoBehaviour
{
    [Header("objet à  flip")]
    [SerializeField] private Transform gameObj;

    [Header("position A à B")]
    [SerializeField] private Vector3 flip_origin_Position;
    [SerializeField] private Vector3 flip_Position;
    [SerializeField] private float flipTime;

    private bool hasflipped;

    private void OnEnable()
    {
        GameManager.gameManagerInstance.OnFlip += Flip;
    }
    public void Flip()
    {
        StartCoroutine(Fliping()); 
    }
    public IEnumerator Fliping()    
    {
        if (!hasflipped) 
        {
            gameObj.transform.DOMove(flip_Position,flipTime);
            gameObj.DORotate(flip_Position,flipTime);
            hasflipped = true;
            GameManager.InPause = false;
        }
        else
        {
            gameObj.transform.DOMove(flip_origin_Position, flipTime);
            gameObj.DORotate(flip_origin_Position, flipTime);
            hasflipped = false;
            GameManager.InPause = false;
        }
        yield return null;
    }
    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= Flip;
    }
}
