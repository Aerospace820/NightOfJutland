using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public UnityEvent ShipGo;
    public Transform Player;
    public float MaxZ, MinZ;
    void Start()
    {
        float ZPosition = Random.Range(MinZ, MaxZ); 
        Vector3 newPosition = transform.position;
        newPosition.z = ZPosition;
        transform.position = newPosition;
    }
    void OnTriggerEnter()
    {
        ShipGo.Invoke();
        Debug.Log("Sup Trigger got Entered fr fr");
    }
}
