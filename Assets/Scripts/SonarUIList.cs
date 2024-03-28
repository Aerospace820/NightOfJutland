using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    void Start()
    {
        foreach (var prob in objectProbabilities)
        {
            if (Random.value < prob.probability)
            {
                foreach (var obj in prob.objects)
                {
                    obj.SetActive(true);
                    revealedObjects.Add(obj);
                }
            }
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
            unrevealedObjects.AddRange(prob.objects.FindAll(obj => !revealedObjects.Contains(obj)));
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
