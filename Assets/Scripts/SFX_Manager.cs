using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Manager : MonoBehaviour
{

    public static AudioSource theAudioSource;

    void Start()
    {
        theAudioSource = GetComponent<AudioSource>();
        theAudioSource.volume = 1;
        theAudioSource.loop = true;
    }


    public static void PlaySFX(AudioClip clip)
    {
        theAudioSource.clip = clip;
        theAudioSource.Play();
    }

    public static void StopSFX()
    {
        Debug.Log("STOPPED");
        theAudioSource.Stop();
    }
}
