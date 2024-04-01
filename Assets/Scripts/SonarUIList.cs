using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class GameObjectProbability
{
    public List<GameObject> objects = new List<GameObject>();
    [Range(0f, 1f)]
    public float probability;
}
  
public class SonarUIList : MonoBehaviour
{
    public List<GameObjectProbability> objectProbabilities = new List<GameObjectProbability>();
    private List<GameObject> revealedObjects = new List<GameObject>();
    public UnityEvent onFirstRKeyPress;
    public UnityEvent onSecondRKeyPress;

    private bool isFirstRKeyPressed = true;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isFirstRKeyPressed)
            {
                onFirstRKeyPress.Invoke();
            }
            else
            {
                onSecondRKeyPress.Invoke();
            }
            isFirstRKeyPressed = !isFirstRKeyPressed;
        }
    }

    public void RevealRandomObject()
    {
        if (objectProbabilities.Count == 0)
        {
            Debug.LogWarning("No object probabilities set.");
            return;
        }

        List<GameObject> unrevealedObjects = new List<GameObject>();
        foreach (var prob in objectProbabilities)
        {
            foreach (var obj in prob.objects)
            {
                if (!revealedObjects.Contains(obj))
                {
                    unrevealedObjects.Add(obj);
                }
            }
        }

        if (unrevealedObjects.Count == 0)
        {
            Debug.LogWarning("All objects have been revealed.");
            return;
        }

        int randomIndex = Random.Range(0, unrevealedObjects.Count);
        GameObject randomObject = unrevealedObjects[randomIndex];
        randomObject.SetActive(true);
        revealedObjects.Add(randomObject);
    }
}
