using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioDoesStuff : MonoBehaviour
{
    public AudioSource audioSource;
    public float moreSonar = 2f;
    public UnityEvent EventShip1, EventShip2;
    public float Ship1, Ship2;
    public float RadioScore, PlusImage, PlusQuiz;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void PlusImageScore(float RadioPointDecider)
    {
        RadioScore += RadioPointDecider;
    }

    void Update()
    {
        ShipList();
        
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

}
