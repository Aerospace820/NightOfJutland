using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateAI : MonoBehaviour
{
    public Transform Player;
    private bool CanGo;
    public bool IsNonCrossingShip;
    public float speed;
    public float NeededDistanceShip;
    public float TurnTime;
    void Start()
    {
        CanGo = false;
    }

    public void LetsGo()
    {
        CanGo = true;
        Debug.Log("Sup, We 1 Moving here");
    }

    void Update()
    {
        if (CanGo)
        {
            float PlayerPos = Vector3.Distance(Player.position, transform.position);

            if (PlayerPos < NeededDistanceShip)
            {
                Debug.Log("Distance is Enough");

                Quaternion currentRotation = transform.rotation;
                Quaternion targetRotation = Quaternion.Euler(Vector3.zero);

                if (IsNonCrossingShip)
                {
                    Debug.Log("Rotationswork");
                    transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * TurnTime);
                }
        
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
    }
}
