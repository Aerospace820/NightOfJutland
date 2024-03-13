using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpSpeeding : MonoBehaviour
{
    public float speed = 5f;
    public bool IsNotMain;

    void Update()
    {
        if(IsNotMain)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}