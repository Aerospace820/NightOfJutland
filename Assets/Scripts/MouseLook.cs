using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float slerpSpeed = 5f;
    public bool IsTorp;
    public Collider mouseCollider;
    void Update()
    {
        if(IsTorp)
        {
            if (Input.mousePosition.x < Screen.width / 2)
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
            RaycastHit hitInfo;
            bool isMouseHittingCollider = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.collider == mouseCollider;
            if (isMouseHittingCollider)
            {
                RotateTorpedo();
            }
        }
    } 

    void RotateTorpedo()
    {
        Debug.Log("Say Hi");
    }  
}
