using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemysTorpDemise : MonoBehaviour
{
    public UnityEvent NoReloadWompWomp;
    public string TorpTag, BulletTag;
    public float TorpDam, BulletDam;
    public float Health;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TorpTag))
        {
            Health -= TorpDam;
            Destroy(other.gameObject);
            NoReloadWompWomp.Invoke();
        }

        if (other.CompareTag(BulletTag))
        {
            Health -= BulletDam;
            Destroy(other.gameObject);
            NoReloadWompWomp.Invoke();
        }
    }
}