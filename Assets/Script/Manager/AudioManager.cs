using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance;

  public AudioSource musicSource;

  public AudioClip[] musicClips;
  public AudioClip[] AlarmeBoucleClip, AlarmeSimpleClip, AlarmeSwitchClip, ClicClip, ExplosionEnnemiClip, ExplosionJoueurClip, FlipClip;

  private Dictionary<string, AudioClip> musicDict;


    void Start()
    {
        AudioManager.instance.PlayMusic("Menu"); 
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string clipName)
    {
        if (musicDict.ContainsKey(clipName))
        {
            musicSource.clip = musicDict[clipName];
            musicSource.Play();
        }
    }


public void StopMusic()
{
    musicSource.Stop();
}
   
  
}
