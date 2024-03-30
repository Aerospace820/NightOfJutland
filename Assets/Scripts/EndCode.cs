using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EndCode : MonoBehaviour
{
    public LayerMask targetLayer;
    public TextMeshProUGUI text1, text2;
    public Canvas EndCanvas;
    public Image acheviment1, Acheivment2;
    public Image GoodImage, BadImage;
    public float EndWaitTime;
    public float ShipsSunk, ShipsNeeded;
    public string Questions, Actual1, Actual2;
    void Start()
    {
        EndCanvas.enabled = false;
        acheviment1.enabled = false;
        Acheivment2.enabled = false;
        text1.text =  Questions;
        text2.text = Questions;
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
            GoodImage.enabled = true;
        }

        else if (!EndGreat)
        {
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
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (!IsOnLayer(obj))
            {
                obj.SetActive(false);
            }
        }
    }

    bool IsOnLayer(GameObject obj)
    {
        int objLayer = obj.layer;
        return ((targetLayer.value & (1 << objLayer)) > 0);
    }
}
