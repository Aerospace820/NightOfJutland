using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateAI : MonoBehaviour
{
    public Transform Player;
    private bool CanGo, CanGoOnce, GoTillEnd, LastOne;
    public bool IsNonCrossingShip;
    public float speed;
    public float NeededDistanceShip;
    public float TurnTime;
    public float Endtime;
    public float rotationTolerance;
    void Start()
    {
        CanGo = false;
        CanGoOnce = true;
        GoTillEnd = true;
        LastOne = true;
    }

    public void LetsGo()
    {
        CanGo = true;
        Debug.Log("Sup, We 1 Moving here");
    }

    void Update()
    {
        if (CanGo)
        {
            if(CanGoOnce)
            {
                StartCoroutine(EndStuff());
                CanGoOnce = false;
            }


            if (transform.position.x > -42.5f)
            {

                Quaternion currentRotation = transform.rotation;
                Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);

                if (IsNonCrossingShip && GoTillEnd)
                {
                    transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * TurnTime);
                }
        
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
    }

    IEnumerator EndStuff()
    {
        yield return new WaitForSeconds(Endtime);
        if(IsNonCrossingShip)
        {
            Debug.Log("End For Now");
            GoTillEnd = false;
            Quaternion endtargetRotation = Quaternion.Euler(0f, 200f, 0f);
            while(LastOne)
            {
                Quaternion endcurrentRotation = transform.rotation;
                transform.rotation = Quaternion.Slerp(endcurrentRotation,endtargetRotation, Time.deltaTime * TurnTime);
                if (Quaternion.Angle(endcurrentRotation, endtargetRotation) < rotationTolerance)
                {
                    LastOne = false;
                }
            }
        }

        else if(!IsNonCrossingShip)
        {
            float EndtimeNew = Endtime/4f;
            yield return new WaitForSeconds(EndtimeNew);
        }
    }
}
