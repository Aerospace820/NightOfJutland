using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyOneInfo : MonoBehaviour
{
    public static bool IsFree = true;
    private bool justwork = true;
    public void MakeNotFree()
    {
        justwork = false;
    }

    void Update()
    {
        IsFree = justwork;
    }
    
    public void MakeFree()
    {
        justwork = true;
    }
}
