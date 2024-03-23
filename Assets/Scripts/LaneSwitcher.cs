using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneSwitcher : MonoBehaviour
{
    public Text SameLane;
    public float TurnAngle;
    public float TurnPoints;
    private bool CanTurn, IsRight;
    public float UpdateTimeStatic;
    public float UpdateTime = 3f;
    private float CurrentLane = 3f;
    public float DesiredLane, LaneWait, DesiredLaneLX, Tolerance;

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
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1) && CanTurn)
        {
            DesiredLane = 1f;
            DesiredLaneLX = -30f;
            TurnRotate(DesiredLane, DesiredLaneLX);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2) && CanTurn)
        {
            DesiredLane = 2f;
            DesiredLaneLX = -10f;
            TurnRotate(DesiredLane, DesiredLaneLX);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) && CanTurn)
        {
            DesiredLane = 3f;
            DesiredLaneLX = 0f;
            TurnRotate(DesiredLane, DesiredLaneLX);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha3) && CanTurn)
        {
            DesiredLane = 4f;
            DesiredLaneLX = 10f;
            TurnRotate(DesiredLane, DesiredLaneLX);
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha4) && CanTurn)
        {
            DesiredLane = 5f;
            DesiredLaneLX = 30f;
            TurnRotate(DesiredLane, DesiredLaneLX);
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
            //StartCoroutine(Turn(NeededX, IsRight));
            CurrentLane = DesiredLane;
        }

        else if(CurrentLane < DesiredLane)
        {
            DecreaseTurn();
            CurrentLane = DesiredLane;
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

    //IEnumerator Turn(float NeededX, bool IsRight)
    //{
    //    while((Mathf.Abs(transform.position.x - NeededX) > Tolerance))
    //    {
    //        Debug.Log("Sup");
    //    }
    //}

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
