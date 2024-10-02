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
    [SerializeField] private Vector3 flip_origine_Rotation;
    [SerializeField] private Vector3 flip_Position;
    [SerializeField] private Vector3 flip_Rotation;
    [SerializeField] private float flipTime;

    [SerializeField] private AudioSource SFXSource;

    private bool hasflipped;

    private void OnEnable()
    {
        GameManager.gameManagerInstance.OnFlip += Flip;
    }
    public void Flip()
    {
        StartCoroutine(Fliping());
        GetComponent<FullScreenFlipEffect>().StartFlip();
    }
    public IEnumerator Fliping()    
    {
        if (!hasflipped) 
        {
            gameObj.transform.DOMove(flip_Position,flipTime);
            gameObj.DORotate(flip_Rotation,flipTime);
            hasflipped = true;
            GameManager.InPause = false;
        }
        else
        {
            gameObj.transform.DOMove(flip_origin_Position, flipTime);
            gameObj.DORotate(flip_origine_Rotation, flipTime);
            hasflipped = false;
            GameManager.InPause = false;
        }
        FlipSFX();
        yield return null;
    }

    public void FlipSFX()
    {
        SFXSource.Play();
    }

    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= Flip;
    }
}
