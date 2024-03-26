using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Canvas WinCanvas;
    public TextMeshProUGUI scoretext;
    public float GameScore = 0;
    
    public void IncreaseScore(float Increaser)
    {
        GameScore += Increaser;
    }

    public void DecreaseScore(float Decreaser)
    {
        GameScore -= Decreaser;
    }


}
