using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sounds : MonoBehaviour
{
    [SerializeField] private float AudioFootVolume = 1f;
    [SerializeField] private float SoundEffectPitchRandomness = 0.05f;
    private float CollisionSoundEffect = 1f;
    private AudioSource PlayerAudioSource;
    public AudioClip GenericFootSound;
    public AudioClip MetalFootSoundl;

    private void Awake()
    {
        PlayerAudioSource = GetComponent<AudioSource>();
    }

    void FootSound()
    {
        PlayerAudioSource.volume = CollisionSoundEffect * AudioFootVolume;
        PlayerAudioSource.pitch = Random.Range(1.0f - SoundEffectPitchRandomness, 1.0f + SoundEffectPitchRandomness);

        if (Random.Range(0, 2) > 0)
            PlayerAudioSource.clip = GenericFootSound;
        else
            PlayerAudioSource.clip = MetalFootSoundl;

        PlayerAudioSource.Play();
    }
}
