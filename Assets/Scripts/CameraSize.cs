using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public Camera orthoCamera;
    public Transform Player;
    public float targetSize1, targetSize2;
    public float changeSpeed, zoomSpeed;
    public float minZoom, maxZoom;
    private bool DecreaseYes;
    public float shakeDuration;
    public float shakeIntensity;
    private Vector3 originalPosition;

    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Player.position.x;
        transform.position = newPosition;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float newZoom = Camera.main.orthographicSize - scroll * zoomSpeed * Time.deltaTime;
            newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
            Camera.main.orthographicSize = newZoom;
        }
    }

    public void DecreaseSize()
    {
        DecreaseYes = true;
        StartCoroutine(SizeStuff(DecreaseYes));
    }

    public void IncreaseSize()
    {
        DecreaseYes = false;
        StartCoroutine(SizeStuff(DecreaseYes));
    }

    private IEnumerator SizeStuff(bool DecreaseYes)
    {
        float targetSize;
        if(DecreaseYes)
        {
            targetSize = targetSize1;
        }

        else
        {
            targetSize = targetSize2;
        }
        float currentSize = orthoCamera.orthographicSize;
        while (Mathf.Abs(currentSize - targetSize) > 0.01f)
        {
            currentSize = Mathf.MoveTowards(currentSize, targetSize, changeSpeed * Time.deltaTime);
            orthoCamera.orthographicSize = currentSize;
            yield return null;
        }
    }

    public void Shake()
    {
        originalPosition = transform.localPosition;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    private void DoShake()
    {
        float shakeAmountX = Random.Range(-1f, 1f) * shakeIntensity;
        float shakeAmountY = Random.Range(-1f, 1f) * shakeIntensity;

        Vector3 newPos = originalPosition + new Vector3(shakeAmountX, shakeAmountY, 0);
        transform.localPosition = newPos;
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        transform.localPosition = originalPosition;
    }
}
