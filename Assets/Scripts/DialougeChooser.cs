using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeChooser : MonoBehaviour
{
    public UnityEvent British, German;
    public AudioClip whistle;
    public AudioSource audioSource;

    public void DialougeStuff(bool IsBritsh)
    {
        if(IsBritsh)
        {
            British.Invoke();
        }
        else if(!IsBritsh)
        {
            German.Invoke();
        }
        else
        {
            Debug.Log("Womp Womp No Work");
        }
        audioSource.clip = whistle;
        audioSource.Play();
    }
}
