using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateAI : MonoBehaviour
{
    public Transform player;
    private bool CanGo, CanGoOnce;
    public float speed, distanceThreshold;
    void Awake()
    {
        CanGo = false;
        CanGoOnce = true;
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
            Debug.Log(CanGoOnce);
            if(CanGoOnce)
            {
                StartCoroutine(EndStuff());
                CanGoOnce = false;
            }
        }
    }

    IEnumerator EndStuff()
    {
        while(Vector3.Distance(transform.position, player.position) > distanceThreshold)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }
    } 
}

