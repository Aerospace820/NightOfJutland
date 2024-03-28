using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class LaneSwitcher : MonoBehaviour
{
    public UnityEvent Slow, Speed;
    public TextMeshProUGUI SameLane;
    public float TurnPoints;
    private bool CanTurn, IsRight;
    public float UpdateTimeStatic;
    public float UpdateTime = 3f;
    private float CurrentLane = 3f;
    public float DesiredLane, LaneWait, DesiredLaneLX;
    public float Tolerance, YAngle, speedTurned, xStuff, rotationDuration;

    void Start()
    {
        //PLACEHOLDER
        CanTurn = true;
        TurnPoints = 1f;
        SameLane.enabled = false;
        
    }

    void Update()
    {
        TurnList();
        if(TurnPoints < 1)
        {
            UpdateTime -= Time.deltaTime;
            if(UpdateTime < 0)
            {
                UpdateTime = UpdateTimeStatic;
                IncreaseTurn();
            }
        }

        MoveList();
    }

//-30, -10, 0, 10, 30
    void MoveList()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && CanTurn)
            {
                DesiredLane = 1f;
                DesiredLaneLX = -30f;
                TurnRotate(DesiredLane, DesiredLaneLX);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && CanTurn)
            {
                DesiredLane = 2f;
                DesiredLaneLX = -10f;
                TurnRotate(DesiredLane, DesiredLaneLX);
            }

            if (Input.GetKeyDown(KeyCode.W) && CanTurn)
            {
                DesiredLane = 3f;
                DesiredLaneLX = 0f;
                TurnRotate(DesiredLane, DesiredLaneLX);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && CanTurn)
            {
                DesiredLane = 4f;
                DesiredLaneLX = 10f;
                TurnRotate(DesiredLane, DesiredLaneLX);
                Debug.Log("DoesDetect");
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && CanTurn)
            {
                DesiredLane = 5f;
                DesiredLaneLX = 30f;
                TurnRotate(DesiredLane, DesiredLaneLX);
                Debug.Log("DoesDetect");
            }
        }
    }

    void TurnList()
    {
        if(TurnPoints > 0)
        {
            CanTurn = true;
        }

        else if (TurnPoints < 1)
        {
            CanTurn = false;
        }
    }

    void TurnRotate(float DesiredLane, float NeededX)
    {
        if(CurrentLane > DesiredLane)
        {
            DecreaseTurn();
            IsRight = false;
            StartCoroutine(Turn(NeededX, IsRight));
        }

        else if(CurrentLane < DesiredLane)
        {
            DecreaseTurn();
            IsRight = true;
            StartCoroutine(Turn(NeededX, IsRight));
            Debug.Log("Yes Detect");
        }

        else if(CurrentLane == DesiredLane)
        {
            StartCoroutine(SameLaneOhNo());
        }

        else
        {
            Debug.LogError("What Have You Done For This To Go So Wrong");
        }
    }

    IEnumerator Turn(float NeededX, bool IsRight)
    {
        Slow.Invoke();
        Debug.Log(IsRight);
        Quaternion targetRotation;
        if (IsRight)
        {
            targetRotation = Quaternion.Euler(0f, -YAngle, 0f);
            while (transform.position.x < NeededX)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                transform.position += new Vector3(xStuff * Time.deltaTime, 0f, 0f);
                yield return null;
            }
            Quaternion AftertargetRotation = Quaternion.identity;
            TurnBack(AftertargetRotation);
        }
        else
        {
            targetRotation = Quaternion.Euler(0f, YAngle, 0f);
            while (transform.position.x > NeededX)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                transform.position -= new Vector3(xStuff * Time.deltaTime, 0f, 0f);
                yield return null;
            }
            Quaternion AftertargetRotation = Quaternion.identity;
            TurnBack(AftertargetRotation);
        }

        Speed.Invoke();
        CurrentLane = DesiredLane;
    }

    void TurnBack(Quaternion afterTargetRotation)
    {
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = afterTargetRotation;

        float elapsedTime = 0f;
        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            
            elapsedTime += Time.deltaTime;
        }
        transform.rotation = targetRotation;
    }

    IEnumerator SameLaneOhNo()
    {
        SameLane.enabled = true;
        yield return new WaitForSeconds(LaneWait);
        SameLane.enabled = false;
    }

    public void IncreaseTurn()
    {
        TurnPoints++;
    }

    public void DecreaseTurn()
    {
        TurnPoints--;
    }
}
