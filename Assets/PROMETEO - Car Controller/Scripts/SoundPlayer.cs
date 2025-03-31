using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Call this from other methods
    public void PlaySound(int index) {
        //if (!audioSource.isPlaying) {
            audioSource.clip = clip[index];
            audioSource.PlayOneShot(clip[index]);
        //}
    }
}
