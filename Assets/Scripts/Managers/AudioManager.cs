using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    [Header("== SOUND CLIPS ==")]
    public AudioClip buttonClip;
    public AudioClip loseClip;
    public AudioClip ringClip;
    public AudioClip levelAmbience;

    private AudioSource _audioSource;

    public static AudioManager AM;

    private void Awake()
    {
        AM = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip , float volume)
    {
        _audioSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic(AudioClip clip, float volume = 0.2f, bool loop = true)
    {
        _audioSource.clip = clip;
        _audioSource.volume = volume;
        _audioSource.loop = loop;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

}
