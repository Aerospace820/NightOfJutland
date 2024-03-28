using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndCode : MonoBehaviour
{
    public UnityEvent MoveCanvasDown;
    public ParticleSystem Trail;
    public float EndWaitTime;
    public void EndCountDown()
    {
        Trail.Stop();
        StartCoroutine(TheEnd());
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(EndWaitTime);
        MoveCanvasDown.Invoke();
    }
}
