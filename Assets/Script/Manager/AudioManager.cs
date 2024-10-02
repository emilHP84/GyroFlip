using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource;

    public AudioClip[] musicClips;
    public AudioClip[] AlarmeBoucleClip, AlarmeSimpleClip, AlarmeSwitchClip;


    private void OnEnable()
    {
       
    }

    void Start()
    {
        PlayMusic();
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if(GameManager.InGame == false)
        {
            musicSource.clip = musicClips[0];
            musicSource.Play();
        }

        if(GameManager.InGame == true)
        {
            musicSource.clip = musicClips[1];
            musicSource.Play();
        }

        if(GameManager.InGame == true && GameManager.IsDead == true)
        {
            musicSource.clip = musicClips[2];
            musicSource.Play();
        }
    }

    public void AlarmLoop() 
    {
        //
    }

    public void AlarmSimple()
    {
        // à oublier pour le moment
    }

    public void ExplosionEnnemi()
    {
        //
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    private void OnDisable()
    {
        
    }
}

