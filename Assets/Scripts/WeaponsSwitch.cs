using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponsSwitch : MonoBehaviour
{
    public TMP_Text SearchText, TorpedoText, ShellText;
    public Transform TorpedoLauncher1, TorpedoLauncher2, GunEnd1, GunEnd2;
    public GameObject Torpedo, Bullet;
    public Light SearchLight1, SearchLight2;
    public float SearchReload, SearchAmountReload;
    public float SearchAmount, WaitTimeSearch;
    public float TorpAmount, TorpReloadTime;
    public float ShotAmount, ShotReloadTime;

    private bool NoMultipleLights, NoMultipleTorps, NoMultipleShots;
    void Start()
    {
        SearchLightInactive();
        StartCoroutine(ReloadSearchersAndTorps());
        NothingMultiple();
    }

    void NothingMultiple()
    {
        NoMultipleLights = true;
        NoMultipleTorps = true;
        NoMultipleShots = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && NoMultipleLights && SearchAmount > 0f)
        {
            TurnOnSearchers();
            NoMultipleLights = false;
        }

        if(Input.GetKeyDown(KeyCode.Y) && NoMultipleTorps && TorpAmount > 0f)
        {
            NoMultipleTorps = false;
            StartCoroutine(TorpReloads());
            Transform TorpedoLaunch = Random.Range(0,2) == 0 ? TorpedoLauncher1:TorpedoLauncher2;
            Instantiate(Torpedo, TorpedoLaunch.position, TorpedoLaunch.rotation);
        }

        if(Input.GetKeyDown(KeyCode.Z) && NoMultipleShots && ShotAmount > 0f)
        {
            NoMultipleShots = false;
            StartCoroutine(ShotReloads());
            Transform GunShoot = Random.Range(0,2) == 0 ? GunEnd1:GunEnd2;
            Instantiate(Bullet, GunShoot.position, GunShoot.rotation);
        }

        SearchText.text = "You have " + SearchAmount.ToString() + " Search Light(s) Left";
        TorpedoText.text = "You have " + TorpAmount.ToString() + " Torpedo(s) Left";
        ShellText.text = "You have " + ShotAmount.ToString() + " Shell(s) Left";

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
//TURRET STUFF
    IEnumerator ShotReloads()
    {
        ShotAmount--;
        yield return new WaitForSeconds(ShotReloadTime);
        NoMultipleShots = true;
    }



}
