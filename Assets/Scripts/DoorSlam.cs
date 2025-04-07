using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip slamSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(slamSound);
            doorAnimator.SetTrigger("Slam");
            GetComponent<Collider>().enabled = false;
        }
    }
}