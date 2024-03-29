using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlankingManuevur : MonoBehaviour
{
    public Transform player;
    public string targetTag;
    public float rotationSpeed;
    public float chanceOfRotation, distanceThreshold, speed; 
    private bool HasTurned = false;

    private HashSet<GameObject> detectedObjects = new HashSet<GameObject>();

    void Update()
    {
        float randomValue = Random.value;

        if (randomValue < chanceOfRotation)
        {
            GameObject[] newObjects = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (var obj in newObjects)
            {
                if (!detectedObjects.Contains(obj))
                {
                    Quaternion targetRotation = Quaternion.Euler(0f, 20f, 0f);

                    obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    
                    HasTurned = true;

                    detectedObjects.Add(obj);
                }
            }
        }

        if(HasTurned)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) < distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
}
