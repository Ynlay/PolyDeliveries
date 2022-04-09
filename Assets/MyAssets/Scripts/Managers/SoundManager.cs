using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}

    public AudioSource source;

    public AudioClip receive;
    public AudioClip remove;
    public AudioClip getHit;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }
   

    public void PlayAudioClip(AudioClip _clip) {
        source.Stop();
        source.clip = _clip;
        source.Play();
    }

    public void PlayHit() {
        PlayAudioClip(getHit);
    }
    public void PlayReceive() {
        PlayAudioClip(receive);
    }
    public void PlayRemove() {
        PlayAudioClip(remove);
    }
}
