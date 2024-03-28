using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStuff : MonoBehaviour
{
    public RectTransform uiElement;
    public Vector2 targetPosition;
    public float moveSpeed = 1f;
    public float waitTime = 2f;
    public bool NotEnd;

    private Vector2 originalPosition;
    private bool movingToTarget = false;
    private bool movingBack = false;
    private float startTime;

    public void OnMove()
    {
        originalPosition = uiElement.anchoredPosition;
        movingToTarget = true;
        movingBack = NotEnd;
        startTime = Time.time;
    }

    void Update()
    {
        if (movingToTarget)
        {
            float journeyLength = Vector2.Distance(originalPosition, targetPosition);
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            uiElement.anchoredPosition = Vector2.Lerp(originalPosition, targetPosition, fracJourney);

            if (fracJourney >= 1f)
            {
                startTime = Time.time;
                movingToTarget = false;
            }
        }

        if (!movingToTarget && !movingBack)
        {
            if (Time.time - startTime >= waitTime)
            {
                movingBack = true;
                startTime = Time.time;
            }
        }

        if (movingBack)
        {
            float journeyLength = Vector2.Distance(targetPosition, originalPosition);
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            uiElement.anchoredPosition = Vector2.Lerp(targetPosition, originalPosition, fracJourney);

            if (fracJourney >= 1f)
            {
                movingBack = false;
            }
        }
    }
}
