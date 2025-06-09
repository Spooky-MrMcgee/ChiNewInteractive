using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public void SetClip(AudioClip clip)
    {
        audioSource.clip = clip;
    }

    public void PlayClip()
    {
        audioSource.Play();
    }

    public void StopClip()
    {
        audioSource.Stop();
    }
}
