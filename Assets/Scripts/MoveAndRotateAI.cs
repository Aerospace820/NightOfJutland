using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateAI : MonoBehaviour
{
    public Transform player;
    private bool CanGo;
    public float speed, distanceThreshold, playerDistance1, playerDistance2;
    void Awake()
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
            if(Mathf.Abs(transform.position.x - player.position.x) < distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }


    }



}

