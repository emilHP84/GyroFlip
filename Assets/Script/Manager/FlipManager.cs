using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipManager : MonoBehaviour
{
    public Transform camera;
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
            camera.transform.DOMove(new Vector3(0, -32.3f, -28.7f), 1);
            camera.DORotate(new Vector3(-55.3f, 0, 0), 1);
            hasflipped = true;
            GameManager.InPause = false;
        }
        else
        {
            camera.transform.DOMove(new Vector3(0, 32.3f, -28.7f), 1);
            camera.DORotate(new Vector3(55.3f, 0, 0), 1);
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
