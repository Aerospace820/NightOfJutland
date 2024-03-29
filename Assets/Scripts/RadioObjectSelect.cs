using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RadioObjectSelect : MonoBehaviour
{
    [System.Serializable]
    public class GameObjectButtonPair
    {
        public Button button;
        public GameObject gameObject;
        public UnityEvent onActivation;
    }

    public List<GameObjectButtonPair> buttonObjectPairs = new List<GameObjectButtonPair>();

    private void Start()
    {
        foreach (var pair in buttonObjectPairs)
        {
            if (pair.button != null)
            {
                pair.button.onClick.AddListener(() => ActivateGameObject(pair));
            }
        }
    }

    private void ActivateGameObject(GameObjectButtonPair pair)
    {
        pair.gameObject.SetActive(true);
        pair.onActivation.Invoke();
    }
}
