using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
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
            hasflipped = true;
        }
        else
        {
            hasflipped = false;
        }
        yield return null;
    }
    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= Flip;
    }
}
