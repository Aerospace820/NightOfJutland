using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    public UnityEvent ShipGo;
    public Transform Player;
    private bool ShipGoOnce;
    public float DistanceNeededShip;
    // Start is called before the first frame update

    void Start()
    {
        ShipGoOnce = true;
    }
    void Update()
    {
        float PlayerPos = Vector3.Distance(Player.transform.position, transform.position);

        if(PlayerPos < DistanceNeededShip && ShipGoOnce)
        {
            ShipGoOnce = false;
            ShipGo.Invoke();
            Debug.Log("Sup Trigger got Entered fr fr");   
        }
    }
}
