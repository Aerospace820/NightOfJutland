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
    public UnityEvent CamShake;
    public HealthMouse HealthEvent;
    public string UIHealthState;
    public string TorpTag, BulletTag, ShipTag;
    public float TorpDam, BulletDam, RqXPos;
    public float Health = 100f;
    public bool IsEnemy;
    private bool IsMouse = false;
    public float detectionRadius;

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
            if(!IsEnemy)
            {
                float RandomShakeChance = Random.Range(0,6);
                Debug.Log(RandomShakeChance);
                if(RandomShakeChance == 5f)
                {
                    CamShake.Invoke();
                }
            }   
        }
    }

    void Update()
    {
        if(!IsEnemy)
        {
            HealthEvent.Invoke(Health, UIHealthState);
        }

        if(IsEnemy)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(ShipTag) && Vector3.Distance(hit.collider.transform.position, transform.position) <= detectionRadius)
                {
                    if(transform.position.x > RqXPos)
                    {
                        if(IsEnemy)
                        {
                            Debug.Log("MouseIsOver2");
                            HealthEvent.Invoke(Health, UIHealthState);
                            IsMouse = true;
                        }
                    }
                }
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