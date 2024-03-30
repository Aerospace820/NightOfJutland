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
        ShipList();
        SonarList();
    }

    void SonarList()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource reference is not set.");
            return;
        }

        float additionalSonar = (float)(RadioScore / 10) * moreSonar;
        float audioSourceRange = audioSource.maxDistance;
        float sonarRange = audioSourceRange + additionalSonar;

        Debug.Log("Sonar range: " + sonarRange);
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
