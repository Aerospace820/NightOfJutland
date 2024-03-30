using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class MoveStuff : MonoBehaviour
{
    public UnityEvent OnlyOne;
    private OnlyOneInfo OnlyOneInfo;
    public RectTransform uiElement;
    public TextMeshProUGUI Text;
    public Vector2 targetPosition, orginalishIshPosition;
    public float moveSpeed = 1f, MovespeedInfo;
    public float waitTime = 2f;
    public bool NotEnd;
    public bool HealthPanel, InfoPanel;
    private bool CanMoveOnce = true, CanMoveSomething = false, OtherChecker;

    void Update()
    {
        OtherChecker = OnlyOneInfo.IsFree;
        if(HealthPanel)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                OnMove();
            }
        }
        if(InfoPanel)
        {
            Debug.Log("InfoFreeInMove" + OnlyOneInfo.IsFree);
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
        if(CanMoveOnce && !InfoPanel)
        {
            Text.enabled  = true;
            CanMoveOnce = false;
            originalPosition = uiElement.anchoredPosition;
            StartCoroutine(MoveCoroutine());
        }

        if(CanMoveOnce && InfoPanel && OtherChecker)
        {
            OnlyOne.Invoke();
            Debug.Log("OtherCheck is:" + OtherChecker);
            Text.enabled = true;
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
            StartCoroutine(MoveEnd());
        }
        CanMoveOnce = true;
        
    }
}
