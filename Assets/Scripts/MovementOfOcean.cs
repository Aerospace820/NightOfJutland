using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfOcean : MonoBehaviour
{
    public float MovementSpeed, MovmementSpeedLow, MovementSpeedHigh;
    private bool ShouldRun;

    void Start()
    {
        //PlaceHolder; Delete.
        ShouldRun = true;

    }

    public void SlowDown()
    {
        MovementSpeed = MovmementSpeedLow;
    }

    public void SpeedUp()
    {
        MovementSpeed = MovementSpeedHigh;
    }

    public void AfterCut()
    {
        ShouldRun = true;
    }

    public void ToEnd()
    {
        ShouldRun = false;
    }       

    void Update()
    {
        if(ShouldRun == true)
        {
            transform.Translate(new Vector3(0, 0, MovementSpeed));
        }
    }
}
