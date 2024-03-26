using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public float slerpSpeed = 5f;
    public bool IsTorp, IsSearch;
    void Update()
    {
        if(IsTorp)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 direction = mainCamera.ScreenToWorldPoint(mousePos) - player.transform.position;
            if (direction.y > 0)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = Camera.main.nearClipPlane;
                Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 directionToMouse = targetPosition - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToMouse, Vector3.up);
                float slerpSpeed = 5f;
                Quaternion yRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, yRotation, Time.deltaTime * slerpSpeed);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(0, -90, 0);
                float slerpSpeed = 5f;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * slerpSpeed);
            }
        }

        else if (!IsTorp)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 directionToMouse = targetPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse, Vector3.up);
            float slerpSpeed = 5f;
            Quaternion yRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, yRotation, Time.deltaTime * slerpSpeed); 
        }

        if(IsSearch)
        {
            Debug.Log("Womp Womp");
        }
    } 
}
