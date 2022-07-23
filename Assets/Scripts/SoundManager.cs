using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundManager_Instance;

    public AudioClip sfx_Death;
    public AudioClip sfx_Jump;
    public AudioClip sfx_Coin;
    public AudioClip sfx_shoot;
    private AudioSource SoundAudioSource;

    private void Awake()
    {
        SoundManager_Instance = this;
        SoundAudioSource = GetComponent<AudioSource>();
    }


    public void shoot_sfx()
    {
        SoundAudioSource.clip = sfx_shoot;
        SoundAudioSource.Play();
    }

    public void Coin_sfx()
    {
        SoundAudioSource.clip = sfx_Coin;
        SoundAudioSource.Play();
    }

    public void Jump_sfx()
    {
        SoundAudioSource.clip = sfx_Jump;
        SoundAudioSource.Play();
    }

    public void Death_sfx()
    {
        SoundAudioSource.clip = sfx_Death;
        SoundAudioSource.Play();
    }




}
