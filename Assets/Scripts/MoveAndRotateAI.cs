using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveAndRotateAI : MonoBehaviour
{
    public UnityEvent Dialouge;
    public Transform player;
    public float speed, distanceThreshold, waitTime, stopTime;

    private bool canGo = false;
    private bool canGoAlly = false;
    private bool isGoingBack = false, DidDialogueOnce = true;

    private void Awake()
    {
        canGo = false;
        canGoAlly = false;
    }

    public void LetsGo()
    {
        canGo = true;
        Debug.Log("Moving towards player");
    }

    public void LetsGoMoreShip()
    {
        canGoAlly = true;
        Debug.Log("Moving further away from player");
    }

    private void Update()
    {
        if (canGo)
        {
            if (Mathf.Abs(transform.position.x - player.position.x) < distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (!isGoingBack)
            {
                if(DidDialogueOnce)
                {   
                    DidDialogueOnce = false;
                    Dialouge.Invoke();
                }
                StartCoroutine(GoBack());
            }
        }
        else if (isGoingBack)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        if (canGoAlly)
        {
            if (Mathf.Abs(transform.position.x - player.position.x) > distanceThreshold)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    private IEnumerator GoBack()
    {
        yield return new WaitForSeconds(waitTime);
        isGoingBack = true;
        canGo = false;
        Debug.Log("Returning back");
    }
}
