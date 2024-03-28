using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
[System.Serializable]
public class PlayerImprovements : UnityEvent<float> { }
public class Score : MonoBehaviour
{
    public PlayerImprovements PlayerStuff;
    public TextMeshProUGUI scoretext, endscoretext;
    public UnityEvent NoScoreWompWomp;
    public float GameScore = 0;
    public float WompWompDissaperaTime;
    public float DecreaserShell, DecreaserTorp, DecreaserSearch;
    
    public void IncreaseScore(float Increaser)
    {
        GameScore += Increaser;
    }

    public void DecreaseScore(float TorpSearchShell)
    {
        float Decreaser = DecreaserLoist(TorpSearchShell);
        if(GameScore > Decreaser)
        {
            PlayerStuff.Invoke(TorpSearchShell);
            GameScore -= Decreaser;
        }
        else
        {
            if(NoScoreWompWomp != null)
            {
                NoScoreWompWomp.Invoke();
                Debug.Log("Image needa Replaca");
            }
        }
    }

    float DecreaserLoist(float TorpSearchShell)
    {
        float Decreaser = 0f;
        if(TorpSearchShell == 1)
        {
            Decreaser = DecreaserTorp;
        }
        else if(TorpSearchShell == 2)
        {
            Decreaser = DecreaserSearch;
        }
        if(TorpSearchShell == 3)
        {
            Decreaser = DecreaserShell;
        }
        return Decreaser;
    }

    void Update()
    {
        scoretext.text = GameScore.ToString();
        endscoretext.text = GameScore.ToString();
    }


}
