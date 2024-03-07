using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    public GameObject bullet;
    public GameObject torp;
    public Transform Gunend;
    public Transform player;
    public float AngleNeg, AnglePos;
    public float rotationSpeed;
    public float AttackStatic = 3f;
    public float AttackTime = 3f;
    void Update()
    {
        if (player != null)
        {
            Vector3 directionPlayer = player.position - transform.position;
            Quaternion playerRot = Quaternion.LookRotation(new Vector3(directionPlayer.x, 0, directionPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, Time.deltaTime * rotationSpeed);
            AttackTime -= Time.deltaTime;
            if(AttackTime < 0)
            {
                AttackTime = AttackStatic;
                Shot();
            }

        }



    }

    void Shot()
    {
        GameObject bulletstuff = Instantiate(bullet, Gunend.position, Gunend.rotation);
    }
}
