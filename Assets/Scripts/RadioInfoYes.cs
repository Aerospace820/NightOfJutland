using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class RadioMore2 : UnityEvent<float> { }

public class RadioInfoYes : MonoBehaviour
{
    public bool triggerBoolean = false;
    public float RadioPointDecider = 1f;
    public RadioMore2 onTrigger;

    private float lastInvokeTime = 0f;
    public float invokeInterval;

    public void YesImage()
    {
        triggerBoolean = true;
    }

    public void NoImage()
    {
        triggerBoolean = false;
    }


    void Update()
    {
        if (triggerBoolean && Time.time - lastInvokeTime > invokeInterval)
        {
            lastInvokeTime = Time.time;
            onTrigger.Invoke(RadioPointDecider);
        }
    }
}
