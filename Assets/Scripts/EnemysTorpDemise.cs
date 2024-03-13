using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemysTorpDemise : MonoBehaviour
{
    public string targetTag = "TorpedoAlly";

    public float detectionDistance = 5f;
    public float Health;

    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= detectionDistance)
            {
                Health--;
            }
        }
    }
}