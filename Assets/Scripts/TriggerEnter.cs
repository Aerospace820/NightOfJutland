using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class EndEvent : UnityEvent<bool> { }
public class TriggerEnter : MonoBehaviour
{
    public EndEvent TheEnd;
    public UnityEvent ShipGo;
    public Transform Player;
    public float MaxZ, MinZ;
    public bool IsLast;
    void Start()
    {
        float ZPosition = Random.Range(MinZ, MaxZ); 
        Vector3 newPosition = transform.position;
        newPosition.z = ZPosition;
        transform.position = newPosition;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ShipGo.Invoke();
            Debug.Log("Sup Trigger got Entered fr fr");
        }

        if(IsLast)
        {
            TheEnd.Invoke(IsLast);
        }
    }
}
