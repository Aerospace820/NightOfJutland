using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthMouse : UnityEvent<float, string> { } 
[System.Serializable]
public class ScoreStuff : UnityEvent<float> { }
public class EnemysTorpDemise : MonoBehaviour
{
    public ParticleSystem Explosion1, Explosion2, Explosion3, Explosion4;
    public UnityEvent NoReloadWompWomp;
    public UnityEvent MouseEnd;
    public UnityEvent CamShake;
    public UnityEvent End;
    public HealthMouse HealthEvent;
    public ScoreStuff scoreChange;
    public Transform FullShip;
    public string UIHealthState;
    public string TorpTag, BulletTag, ShipTag;
    public float TorpDam, BulletDam, RqXPos, EnemyScoreChangeShot, EnemyScoreChangeDeath;
    public float SpeedDown, YAxisNeeded;
    public float Health = 100f, MoreHealth, SecondsHealth, LesSecondsHealth, LesSecondsHealthLimit;
    public bool IsEnemy;
    private bool IsMouse = false, O = true, Tw = true, Th = true, F = true;
    private bool OnlyOncecanThyDie = true;
    private float timer = 0f;
    public float detectionRadius;
    void Start()
    {
        Explosion1.Stop();
        Explosion2.Stop();
        Explosion3.Stop();
        Explosion4.Stop();
    }

    public void HealthImprove()
    {
        if(SecondsHealth > LesSecondsHealthLimit)
        {
            SecondsHealth -= LesSecondsHealth;
        }
    }

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
            if(IsEnemy)
            {
                scoreChange.Invoke(EnemyScoreChangeShot);
            }
        }

        if (other.CompareTag(BulletTag))
        {
            Health -= BulletDam;
            Debug.Log(other);
            Destroy(other.gameObject);
            NoReloadWompWomp.Invoke();
            if(IsMouse)
            {
                HealthEvent.Invoke(Health, UIHealthState);
            }
            if(IsEnemy)
            {
                scoreChange.Invoke(EnemyScoreChangeShot);
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
            if(Health < 76f && O)
            {
                O = false;
                Explosion1.Play();
                Debug.Log("Somethinghappened1");
                CamShake.Invoke();
            }
            if(Health < 50f && Tw)
            {
                Tw = false;
                Explosion2.Play();
                Debug.Log("Somethinghappened2");
                CamShake.Invoke();
            }
            if(Health < 25f && Th)
            {
                Th = false;
                Explosion3.Play();
                Debug.Log("Somethinghappened3");
                CamShake.Invoke();
            }
            if(Health < 1f && F)
            {
                F = false;
                Explosion4.Play();
                Debug.Log("Somethinghappened4");
                CamShake.Invoke();
            }
            timer += Time.deltaTime;

            if (timer >= SecondsHealth && Health > Health - MoreHealth)
            {
                timer = 0f;

                Health += MoreHealth;
            }
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

        if(Health < 0f && OnlyOncecanThyDie)
        {
            OnlyOncecanThyDie = false;
            StartCoroutine(UnderWaves());
            if(IsEnemy)
            {
                scoreChange.Invoke(EnemyScoreChangeDeath);
            }
            if(!IsEnemy)
            {
                End.Invoke();
            }
        }
    }

    IEnumerator UnderWaves()
    {
        while (transform.position.y > YAxisNeeded)
        {
            FullShip.Translate(Vector3.down * SpeedDown * Time.deltaTime);
            yield return null;
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