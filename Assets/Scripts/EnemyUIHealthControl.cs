using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyUIHealthControl : MonoBehaviour
{
    public Slider EnemySlider;
    public Image EnemyHealthBar;
    public TextMeshProUGUI EnemyText;
    public string DefaultTextEnemy;
    public float decreaseBar;
    void Start()
    {
        EnemyText.text = DefaultTextEnemy;
        EnemyHealthBar.enabled = false;
    }
    public void SetHealth(float EnemyHealth, string EnemyShipString)
    {
        Debug.Log("We RecivedStuff");
        EnemySlider.value = EnemyHealth;
        EnemyHealthBar.enabled = true;
        EnemyText.text = EnemyShipString;
    }

    public void NoMoreHealth()
    {
        EnemySlider.value = 100f;
        EnemyHealthBar.enabled = false;
        EnemyText.text = DefaultTextEnemy;
    }

}
