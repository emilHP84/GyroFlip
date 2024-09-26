using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.gameManagerInstance.OnFlip += Flip;
    }
    public void Flip()
    {
        StartCoroutine(Fliping()); //??? sa fonctionne pas ???
    }
    public IEnumerator Fliping()    
    {
        // animation flip
        yield return null;
    }
    private void OnDisable()
    {
        GameManager.gameManagerInstance.OnFlip -= Flip;
    }
}
