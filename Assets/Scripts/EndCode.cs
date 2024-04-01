using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EndCode : MonoBehaviour
{
    public List<GameObject> objectsToDisable;
    public TextMeshProUGUI text1, text2;
    public Canvas EndCanvas;
    public Image acheviment1, Acheivment2;
    public Image GoodImage, BadImage;
    public float EndWaitTimeGood, EndWaitTimeBad;
    public float ShipsSunk, ShipsNeeded;
    public string Questions, Actual1, Actual2;
    private float EndWaitTime;
    void Start()
    {
        EndCanvas.enabled = false;
        acheviment1.enabled = false;
        Acheivment2.enabled = false;
        text1.text =  Questions;
        text2.text = Questions;
        BadImage.enabled = false;
        GoodImage.enabled = false;
    }

    public void IncreaseShips()
    {
        ShipsSunk++;
    }

    void Update()
    {
        if(ShipsSunk > ShipsNeeded)
        {
            text2.text = Actual2;
            Acheivment2.enabled = true;
        }
    }

    public void GoodShip()
    {
        text1.text = Actual1;
        acheviment1.enabled = true;
    }

    
    public void EndCountDown(bool EndGreat)
    {
        if(EndGreat)
        {
            EndWaitTime = EndWaitTimeGood;
            GoodImage.enabled = true;
        }

        else if (!EndGreat)
        {
            EndWaitTime = EndWaitTimeBad;
            BadImage.enabled = true;
        }
        StartCoroutine(TheEnd());
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(EndWaitTime);
        EndCanvas.enabled = true;
        DisableObjects();    
        }

    void DisableObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

}
