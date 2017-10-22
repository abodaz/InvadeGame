using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour {

    AudioSource theAudioSource;

    public AudioClip[] mainMusic;
    int current = 0;

    void Start ()
    {
        theAudioSource = GetComponent<AudioSource>();
        theAudioSource.clip = mainMusic[current];
        theAudioSource.Play();
	}
    private void Update()
    {
        Invoke("Change", mainMusic[current].length);
    }

    private void Change()
    {
        theAudioSource.clip = mainMusic[(current++)%mainMusic.Length];
        theAudioSource.Play();
    }
}
