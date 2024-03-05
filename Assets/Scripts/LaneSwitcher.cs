using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneSwitcher : MonoBehaviour
{
    public float TurnAngle;
    public float TurnPoints;
    public bool CanTurn;
    public float UpdateTimeStatic;
    public float UpdateTime = 3f;

    void Start()
    {
        //PLACEHOLDER
        CanTurn = true;
        TurnPoints = 1f;
    }

    void Update()
    {
        TurnList();
        UpdateTime -= Time.deltaTime;
        if(UpdateTime < 0)
        {
            UpdateTime = UpdateTimeStatic;
            IncreaseTurn();
        }

        MoveList();
    }

    void MoveList()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1) && CanTurn)
        {
            transform.position = new Vector3(-30f, transform.position.y, transform.position.z);
            DecreaseTurn();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2) && CanTurn)
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
            DecreaseTurn();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) && CanTurn)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            DecreaseTurn();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha3) && CanTurn)
        {
            transform.position = new Vector3(10f, transform.position.y, transform.position.z);
            DecreaseTurn();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha4) && CanTurn)
        {
            transform.position = new Vector3(30f, transform.position.y, transform.position.z);
            DecreaseTurn();
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

    public void IncreaseTurn()
    {
        TurnPoints++;
    }

    public void DecreaseTurn()
    {
        TurnPoints--;
    }
}
