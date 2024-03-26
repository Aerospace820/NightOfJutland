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
    public Canvas WinCanvas;
    public TextMeshProUGUI scoretext;
    public Image NoScoreWompWomp;
    public float GameScore = 0;
    public float WompWompDissaperaTime;
    float DecreaserShell, DecreaserTorp, DecreaserSearch;
    
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
                NoScoreWompWomp.enabled = true;
                Debug.Log("Image needa Replaca");
                StartCoroutine(WompDissaperas());
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

    IEnumerator WompDissaperas()
    {
        yield return new WaitForSeconds(WompWompDissaperaTime);
        NoScoreWompWomp.enabled = false;
    }

    void Update()
    {
        scoretext.text = GameScore.ToString();
    }


}
