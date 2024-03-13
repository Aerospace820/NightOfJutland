using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public Transform TorpedoLauncher1, TorpedoLauncher2;
    public GameObject Torpedo;
    public Light SearchLight1, SearchLight2;
    public float SearchReload, SearchAmountReload;
    public float SearchAmount, WaitTimeSearch;
    private bool NoMultipleLights;
    void Start()
    {
        SearchLightInactive();
        SearchAmount = 5f;
        StartCoroutine(ReloadSearchers());
        NoMultipleLights = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && SearchAmount > 0f & NoMultipleLights)
        {
            TurnOnSearchers();
            NoMultipleLights = false;
        }
    }
//BUNCH OF SEARCHLIGHT STUFF
    public void TurnOnSearchers()
    {
        SearchLightActive();
        StartCoroutine(TimeLimitGameLights());
    }

    IEnumerator TimeLimitGameLights()
    {
        yield return new WaitForSeconds(SearchReload);
        SearchAmount--;
        SearchLightInactive();
        yield return new WaitForSeconds(WaitTimeSearch);
        NoMultipleLights = true;
    }

    IEnumerator ReloadSearchers()
    {
        yield return new WaitForSeconds(SearchAmountReload);
        SearchAmount++;
        StartCoroutine(ReloadSearchers());
    }
//SEARCHLIGHT ACTIVES;
    void SearchLightInactive()
    {
        SearchLight1.enabled = false;
        SearchLight2.enabled = false;
    }


    void SearchLightActive()
    {
        SearchLight1.enabled = true;
        SearchLight2.enabled = true;
    }

}
