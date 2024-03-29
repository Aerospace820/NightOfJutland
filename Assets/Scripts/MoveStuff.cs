using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveStuff : MonoBehaviour
{
    public RectTransform uiElement;
    public TextMeshProUGUI Text;
    public Vector2 targetPosition, orginalishIshPosition;
    public float moveSpeed = 1f;
    public float waitTime = 2f;
    public bool NotEnd;
    public bool HealthPanel;
    private bool CanMoveOnce = true, CanMoveSomething = false;

    void Update()
    {
        if(HealthPanel)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                OnMove();
            }
        }
        Debug.Log(CanMoveSomething);
    }

    public void MoveOnSomething()
    {
        if(CanMoveSomething)
        {
            originalPosition = orginalishIshPosition;
            StartCoroutine(MoveEnd());
        }
    } 

    private Vector2 originalPosition;

    public void OnMove()
    {
        if(CanMoveOnce)
        {
            Text.enabled  = true;
            CanMoveOnce = false;
            originalPosition = uiElement.anchoredPosition;
            StartCoroutine(MoveCoroutine());
        }
    }

    private IEnumerator MoveEnd()
    {
        float startTime = Time.time;
        float journeyLength = Vector2.Distance(targetPosition, originalPosition);
        while (Time.time - startTime < moveSpeed)
        {
            float fracJourney = (Time.time - startTime) / moveSpeed;
            uiElement.anchoredPosition = Vector2.Lerp(targetPosition, originalPosition, fracJourney);
            yield return null;
        }

        uiElement.anchoredPosition = originalPosition;

    }

    private IEnumerator MoveCoroutine()
    {
        float startTime = Time.time;
        float journeyLength = Vector2.Distance(originalPosition, targetPosition);
        while (Time.time - startTime < moveSpeed)
        {
            float fracJourney = (Time.time - startTime) / moveSpeed;
            uiElement.anchoredPosition = Vector2.Lerp(originalPosition, targetPosition, fracJourney);
            yield return null;
        }

        uiElement.anchoredPosition = targetPosition;

        yield return new WaitForSeconds(waitTime);
        CanMoveSomething = true;

        if(NotEnd)
        {
            startTime = Time.time;
            journeyLength = Vector2.Distance(targetPosition, originalPosition);
            while (Time.time - startTime < moveSpeed)
            {
                float fracJourney = (Time.time - startTime) / moveSpeed;
                uiElement.anchoredPosition = Vector2.Lerp(targetPosition, originalPosition, fracJourney);
                yield return null;
            }

            uiElement.anchoredPosition = originalPosition;
        }
        CanMoveOnce = true;
        
    }
}
