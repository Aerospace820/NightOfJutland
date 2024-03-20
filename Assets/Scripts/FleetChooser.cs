using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FleetChooser : MonoBehaviour
{
    public GameObject[] Fleets;
    public UnityEvent[] FleetEvents;
    public void TriggerEnter()
    {
        if (Fleets != null && Fleets.Length > 0 && FleetEvents != null && FleetEvents.Length > 0)
        {
            ShuffleArray(Fleets, FleetEvents);

            int index = Random.Range(0, Fleets.Length);
            Fleets[index].SetActive(true);

            if (index < FleetEvents.Length)
            {
                FleetEvents[index].Invoke();
            }
        }
        else
        {
            Debug.LogWarning("No game objects assigned to the array!");
        }
    }

    void ShuffleArray(GameObject[] FleetsArray, UnityEvent[] FleetEventsArray)
    {
        for (int i = FleetsArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            GameObject tempGO = FleetsArray[i];
            FleetsArray[i] = FleetsArray[randomIndex];
            FleetsArray[randomIndex] = tempGO;

            UnityEvent tempEvent = FleetEventsArray[i];
            FleetEventsArray[i] = FleetEventsArray[randomIndex];
            FleetEventsArray[randomIndex] = tempEvent;
        }
    }
}
