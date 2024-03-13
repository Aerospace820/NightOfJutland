using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponsSwitch : MonoBehaviour
{
    public TMP_Text SearchText, TorpedoText;
    public Transform TorpedoLauncher1, TorpedoLauncher2;
    public GameObject Torpedo;
    public Light SearchLight1, SearchLight2;
    public float SearchReload, SearchAmountReload;
    public float SearchAmount, WaitTimeSearch;
    public float TorpAmount, TorpReloadTime;
    private bool NoMultipleLights, NoMultipleTorps;
    void Start()
    {
        SearchLightInactive();
        SearchAmount = 5f;
        StartCoroutine(ReloadSearchersAndTorps());
        NoMultipleLights = true;
        NoMultipleTorps = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && SearchAmount > 0f & NoMultipleLights)
        {
            TurnOnSearchers();
            NoMultipleLights = false;
        }

        if(Input.GetKeyDown(KeyCode.Y) && NoMultipleTorps && TorpAmount > 0f)
        {
            NoMultipleTorps = false;
            StartCoroutine(TorpReloads());
            Instantiate(Torpedo, TorpedoLauncher1.position, TorpedoLauncher1.rotation);
        }

        SearchText.text = "You have " + SearchAmount.ToString() + "Search Light(s) Left";
        TorpedoText.text = "You have " + TorpAmount.ToString() + "Torpedo(s) Left";
    }
//BUNCH OF SEARCHLIGHT STUFF
    public void TurnOnSearchers()
    {
        SearchLightActive();
        StartCoroutine(TimeLimitGameLights());
    }

    IEnumerator TimeLimitGameLights()
    {
        SearchAmount--;
        yield return new WaitForSeconds(SearchReload);
        SearchLightInactive();
        yield return new WaitForSeconds(WaitTimeSearch);
        NoMultipleLights = true;
    }

    IEnumerator ReloadSearchersAndTorps()
    {
        yield return new WaitForSeconds(SearchAmountReload);
        SearchAmount++;
        TorpAmount++;
        StartCoroutine(ReloadSearchersAndTorps());
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
//TORPEDO STUFF
    IEnumerator TorpReloads()
    {
        TorpAmount--;
        yield return new WaitForSeconds(TorpReloadTime);
        NoMultipleTorps = true;
    }

}
