using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthMouse : UnityEvent<float, string> { } 
public class EnemysTorpDemise : MonoBehaviour
{
    public UnityEvent NoReloadWompWomp;
    public UnityEvent MouseEnd;
    public HealthMouse HealthEvent;
    public string UIHealthState;
    public string TorpTag, BulletTag;
    public float TorpDam, BulletDam, RqXPos;
    public float Health = 100f;
    public bool IsEnemy;
    private bool IsMouse = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TorpTag))
        {
            Health -= TorpDam;
            Destroy(other.gameObject);
            NoReloadWompWomp.Invoke();
            if(IsMouse)
            {
                HealthEvent.Invoke(Health, UIHealthState);
            }
        }

        if (other.CompareTag(BulletTag))
        {
            Health -= BulletDam;
            Destroy(other.gameObject);
            NoReloadWompWomp.Invoke();
            if(IsMouse)
            {
                HealthEvent.Invoke(Health, UIHealthState);
            }
        }
    }

    void OnMouseEnter()
    {
        if(transform.position.x > RqXPos)
        {
            Debug.Log("MouseIsOver");
            if(IsEnemy)
            {
                Debug.Log("MouseIsOver2");
                HealthEvent.Invoke(Health, UIHealthState);
                IsMouse = true;
            }
        }
    }

    void OnMouseExit()
    {
        if(IsEnemy)
        {
            IsMouse = false;
            MouseEnd.Invoke();
        }
    }
}