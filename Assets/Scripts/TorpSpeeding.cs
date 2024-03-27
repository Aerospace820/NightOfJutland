using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpSpeeding : MonoBehaviour
{
    public float speed = 5f, SpeedImprovX, DeleteTime;
    void Awake()
    {
        StartCoroutine(DestoyBullet());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SpeedImprovment()
    {
        speed += SpeedImprovX;
    }

    IEnumerator DestoyBullet()
    {
        yield return new WaitForSeconds(DeleteTime);
        Object.Destroy(gameObject);
    }
}