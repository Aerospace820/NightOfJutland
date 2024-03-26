using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpSpeeding : MonoBehaviour
{
    public float speed = 5f, SpeedImprovX;
    void OnBecameInvisible()
    {
        Object.Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SpeedImprovment()
    {
        speed += SpeedImprovX;
    }
}