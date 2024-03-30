using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankingManuevur : MonoBehaviour
{
    public Transform player;
    public string targetTag;
    public float rotationSpeed;
    public float chanceOfRotation, distanceThreshold, speed; 
    private HashSet<GameObject> detectedObjects = new HashSet<GameObject>();

    void Update()
    {
        GameObject[] newObjects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (var obj in newObjects)
        {
            if (!detectedObjects.Contains(obj))
            {
                detectedObjects.Add(obj);
                float randomValue = Random.Range(0.0f, 1.0f);
                Debug.Log(randomValue);
                if(randomValue < chanceOfRotation)
                {
                    PerformFlankingManeuver(obj);
                }
            }
        }

    }

    void PerformFlankingManeuver(GameObject obj)
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 20f, 0f);
        obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
