using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRotate : MonoBehaviour
{
    public float RotateSpeed, WaitTime;
    public bool DoRotateUpdate = true;
    public float startAngle = 0f;
    public float targetAngle = 180f;
    void Update()
    {
        if(DoRotateUpdate == true)
        {
            StartCoroutine(RotateSearch());
            DoRotateUpdate = false;
        }
    }

    IEnumerator RotateSearch()
    {
        Quaternion startRotation = Quaternion.Euler(0f, startAngle, 0f);
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        transform.rotation = Quaternion.Slerp(startRotation, targetRotation, RotateSpeed);
        yield return new WaitForSeconds(WaitTime);
        transform.rotation = Quaternion.Slerp(startRotation, targetRotation, RotateSpeed);
        yield return new WaitForSeconds(WaitTime);
        DoRotateUpdate = true;
    }
}
