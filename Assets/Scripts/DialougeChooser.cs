using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeChooser : MonoBehaviour
{
    public UnityEvent Attack;
    public AudioClip whistle;
    public AudioSource audioSource;

    public void WhenHappened()
    {
        Attack.Invoke();
        audioSource.clip = whistle;
        audioSource.Play();
    }
}
