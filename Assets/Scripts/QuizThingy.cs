using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioMore : UnityEvent<float> { }
public class QuizThingy : MonoBehaviour
{
    public RadioMore RadioQuiz;
    public float timeLimit;
    public float correctAnswer;
    public float NumberForQuiz = 2f;

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
                    RadioQuiz.Invoke(NumberForQuiz);
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
