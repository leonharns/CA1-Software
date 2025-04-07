using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip[] thunder;
    public float minDelay = 2f;
    public float maxDelay = 10f;

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if not already attached
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayRandomSound();
    }

    void PlayRandomSound()
    {
        if (thunder.Length == 0) return; // If no sounds are assigned, exit

        // Choose a random sound from the array
        int randomIndex = Random.Range(0, thunder.Length);
        audioSource.clip = thunder[randomIndex];
        audioSource.Play();

        // Schedule the next sound
        float nextDelay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(PlayRandomSound), nextDelay);
    }
}
