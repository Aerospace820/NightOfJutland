using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    public GameObject bullet;
    public GameObject torp;
    public Transform Gunend;
    public Transform player1, player2, player3;
    public float rotationSpeed, DistanceNeeded;
    public float AttackStatic = 3f;
    public float AttackTime = 3f;
    public bool IsTurret;
    private Transform player;
    void Awake()
    {
        player = player2;
    }
    
    void Update()
    {
        if (player != null)
        {
            Vector3 directionPlayer = player.position - transform.position;
            float distancetoPlayer = Vector3.Distance(transform.position, player.position);
            Quaternion playerRot = Quaternion.LookRotation(new Vector3(directionPlayer.x, 0, directionPlayer.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, Time.deltaTime * rotationSpeed);
            if(IsTurret)
            {
                AttackTime -= Time.deltaTime;
                if(AttackTime < 0)
                {
                    AttackTime = AttackStatic;
                    if(distancetoPlayer < DistanceNeeded)
                    {
                        Shot();
                    }
                }
            }

        }



    }

    void Shot()
    {
        GameObject bulletstuff = Instantiate(bullet, Gunend.position, Gunend.rotation);
        Debug.Log("ItHappened");
        NewPlayer();
    }

    void NewPlayer()
    {
        float PlayerChoose = Random.Range(1,4);
        if(PlayerChoose == 1f)
        {
            player = player1;
        }
        if(PlayerChoose == 2f)
        {
            player = player2;
        }
        if(PlayerChoose == 3f)
        {
            player = player3;
        }
    }
}
