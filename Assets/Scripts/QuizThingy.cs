using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizThingy : MonoBehaviour
{
    public float timeLimit;
    public float correctAnswer;

    private bool gameActive = false;

    public void ActivateGame()
    {
        gameActive = true;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(timeLimit);
        gameActive = false;
    }

    void Update()
    {
        if (gameActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                float pressedButton = -1f;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    pressedButton = 1f;
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                    pressedButton = 2f;
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                    pressedButton = 3f;

                if (pressedButton == correctAnswer)
                {
                    Debug.Log("Correct button pressed!");
                    Debug.Log("Something Sonar Happens");
                }
                else
                {
                    Debug.Log("Wrong button pressed!");
                }

                gameActive = false;
            }
        }
    }
}
