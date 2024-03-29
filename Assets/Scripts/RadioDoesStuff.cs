using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioDoesStuff : MonoBehaviour
{
    public UnityEvent EventShip1, EventShip2;
    public GameObject Player;
    public Transform AudioThing;
    public float Ship1, Ship2;
    public float RadioScore, PlusImage, PlusQuiz, Division;
    private float followRange;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void PlusImageScore(float RadioPointDecider)
    {
        if(RadioPointDecider == 1f)
        {
            RadioScore += PlusImage;
        }

        else if (RadioPointDecider == 2f)
        {
            RadioScore += PlusQuiz;
        }
    }

    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        float distance = Vector3.Distance(mousePosition, Player.transform.position);

        if (distance <= followRange)
        {
            AudioThing.position = mousePosition;
        }

        ShipList();
        RadioList();
    }

    void ShipList()
    {
        if(RadioScore > Ship1)
        {
            EventShip1.Invoke();
        }

        if(RadioScore > Ship2)
        {
            EventShip2.Invoke();
        }
    }

    void RadioList()
    {
        followRange = RadioScore/Division;
    }



}
