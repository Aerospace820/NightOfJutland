using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTorpControl : MonoBehaviour
{
    public Transform[] TorpLaunchers;
    public Transform MainShip;
    public GameObject Torpedo;
    public float XPos;
    public bool IsDestroyer;
    private bool OnlyTorpOnce = true;

    void Update()
    {
        if(IsDestroyer && OnlyTorpOnce && MainShip.position.x > XPos)
        {
            OnlyTorpOnce = false;
            foreach (Transform TorpLaunch in TorpLaunchers)
            {
                Instantiate(Torpedo, TorpLaunch.position, TorpLaunch.rotation);
            }
        }
    }
    
}
