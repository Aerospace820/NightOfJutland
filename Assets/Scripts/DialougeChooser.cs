using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeChooser : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public List<UnityEvent> events = new List<UnityEvent>();
    public List<AudioClip> sounds = new List<AudioClip>();
    public AudioSource audioSource;
    public float chosenIndex = 0f;

    public void OnTriggerEnter(Collider other)
    {
        // Calculate the index based on the chosenIndex float
        int index = Mathf.Clamp(Mathf.FloorToInt(chosenIndex), 0, gameObjects.Count - 1);

        // Check if the calculated index is within bounds
        if (index >= 0 && index < gameObjects.Count)
        {
            // Check if the collider belongs to the selected GameObject
            if (other.gameObject == gameObjects[index])
            {
                // Invoke the corresponding UnityEvent
                events[index].Invoke();

                // Play the corresponding sound
                if (index < sounds.Count && sounds[index] != null && audioSource != null)
                {
                    audioSource.clip = sounds[index];
                    audioSource.Play();
                }
            }
        }
    }
}
