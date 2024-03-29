using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateAI : MonoBehaviour
{
    public Transform player;
    private bool CanGo, CanGoAlly;
    public float speed, distanceThreshold;
    void Awake()
    {
        CanGo = false;
        CanGoAlly = false;
    }

    public void LetsGo()
    {
        CanGo = true;
        Debug.Log("Sup, We 1 Moving here");
    }

    public void LetsGoMoreShip()
    {
        CanGoAlly = true;
        Debug.Log("ReceivedStuff");
    }

    void Update()
    {
        if (CanGo)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) < distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        if (CanGoAlly)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) > distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }



}

