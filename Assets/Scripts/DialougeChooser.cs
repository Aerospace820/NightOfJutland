using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeChooser : MonoBehaviour
{
    public UnityEvent British, German;
    public AudioClip whistle, mosre;
    public AudioSource audioSource;

    public void DialougeStuff(bool IsBritsh)
    {
        if(IsBritsh)
        {
            British.Invoke();
            audioSource.clip = whistle;
            audioSource.Play();
        }
        else if(!IsBritsh)
        {
            German.Invoke();
            audioSource.clip = mosre;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Womp Womp No Work");
        }
    }
}
