using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemysTorpDemise : MonoBehaviour
{
    public string TorpTag, BulletTag;
    public float TorpDam, BulletDam;
    public float Health;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TorpTag))
        {
            Health -= TorpDam;
            Destroy(other.gameObject);
        }

        if (other.CompareTag(BulletTag))
        {
            Health -= BulletDam;
            Destroy(other.gameObject);
        }
    }
}