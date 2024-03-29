using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class WeaponsSwitch : MonoBehaviour
{
    public UnityEvent ShotSpeed, TorpSpeed;
    public TMP_Text SearchText, TorpedoText, ShellText;
    public Transform TorpedoLauncher1, TorpedoLauncher2, GunEnd1, GunEnd2;
    public GameObject Torpedo, Bullet;
    public AudioClip AttackClip;
    public AudioSource musicSource;
    public Light SearchLight1, SearchLight2;
    public Light Ship1, Ship2, Ship3;
    public float SearchReload, SearchAmountReload;
    public float SearchAmount, WaitTimeSearch, SearchReloadTorp;
    public float TorpAmount, TorpReloadTime;
    public float ShotAmount, ShotReloadTime;
    public float ShotReloadShot, ReloadVariance, BattleReload;
    public float MaxSearch = 1f, MaxShots = 50f, MaxTorp = 10f;
//Torpedo
    public float MaxTorpImprov, SearchAmountReloadImprov, TorpReloadTimeImprov;
    public float SearchAmountReloadLimit, TorpReloadTimeLimit;
//Shot
    public float MaxShotsImprov, ShotReloadShotImprov, ShotReloadTimeImprov;
    public float ShotReloadShotLimit, ShotReloadTimeLimit;
//SearchLights
    public float MaxSearchImprov, SearchReloadTorpImprov, SearchReloadImprov, WaitTimeSearchImprov;
    public float SearchReloadTorpLimit, WaitTimeSearchLimit;
    private float Search4 = 0f, MouseNumber = 1f;
    private bool NoMultipleLights, NoMultipleTorps, NoMultipleShots;
    private bool InBattle, BattleReloadOnce;
    private static int lastSelectedTorpedoLauncherIndex = -1;
    private static int lastSelectedTurretIndex = -1;
    void Start()
    {
        SearchLightInactive();
        StartCoroutine(ReloadSearchersAndTorps());
        StartCoroutine(MoreShots());
        musicSource.clip = AttackClip;
        NothingMultiple();
    }

    void NothingMultiple()
    {
        NoMultipleLights = true;
        NoMultipleTorps = true;
        NoMultipleShots = true;
        InBattle = false;
        BattleReloadOnce = true;
    }

    void OnMouseDown()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) | Input.GetKeyDown(KeyCode.RightShift))
        {
            if(MouseNumber == 1f)
            {
                if(NoMultipleShots && ShotAmount > 0f)
                {
                    NoMultipleShots = false;
                    StartCoroutine(ShotReloads());

                    int nextTurretIndex = (lastSelectedTurretIndex + 1) % 2;

                    Transform GunShoot = nextTurretIndex == 0 ? GunEnd1 : GunEnd2;
                    Instantiate(Bullet, GunShoot.position, GunShoot.rotation);

                    lastSelectedTurretIndex = nextTurretIndex;
                }
            }

            if(MouseNumber == 2f)
            {
                if(NoMultipleTorps && TorpAmount > 0f)
                {
                    NoMultipleTorps = false;
                    StartCoroutine(TorpReloads());

                    int nextTorpedoLauncherIndex = (lastSelectedTorpedoLauncherIndex + 1) % 2;

                    Transform TorpedoLaunch = nextTorpedoLauncherIndex == 0 ? TorpedoLauncher1 : TorpedoLauncher2;
                    Instantiate(Torpedo, TorpedoLaunch.position, TorpedoLaunch.rotation);

                    lastSelectedTorpedoLauncherIndex = nextTorpedoLauncherIndex;
                }
            }

            if(MouseNumber == 3f)
            {
                if(NoMultipleLights && SearchAmount > 0f)
                {
                    TurnOnSearchers();
                    NoMultipleLights = false;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Fix Torpedo Rn");
        if(Input.GetKeyDown(KeyCode.C) && NoMultipleLights && SearchAmount > 0f)
        {
            MouseNumber = 3f;
            TurnOnSearchers();
            NoMultipleLights = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && NoMultipleTorps && TorpAmount > 0f)
        {
            MouseNumber = 2f;
            NoMultipleTorps = false;
            StartCoroutine(TorpReloads());

            int nextTorpedoLauncherIndex = (lastSelectedTorpedoLauncherIndex + 1) % 2;

            Transform TorpedoLaunch = nextTorpedoLauncherIndex == 0 ? TorpedoLauncher1 : TorpedoLauncher2;
            Instantiate(Torpedo, TorpedoLaunch.position, TorpedoLaunch.rotation);

            lastSelectedTorpedoLauncherIndex = nextTorpedoLauncherIndex;
        }

        if (Input.GetKeyDown(KeyCode.Z) && NoMultipleShots && ShotAmount > 0f)
        {
            MouseNumber = 1f;
            NoMultipleShots = false;
            StartCoroutine(ShotReloads());

            int nextTurretIndex = (lastSelectedTurretIndex + 1) % 2;

            Transform GunShoot = nextTurretIndex == 0 ? GunEnd1 : GunEnd2;
            Instantiate(Bullet, GunShoot.position, GunShoot.rotation);

            lastSelectedTurretIndex = nextTurretIndex;
        }

        SearchText.text = "You have " + SearchAmount.ToString() + " Search Light(s) Left";
        TorpedoText.text = "You have " + TorpAmount.ToString() + " Torpedo(s) Left";
        ShellText.text = "You have " + ShotAmount.ToString() + " Shell(s) Left";

        if(!BattleReloadOnce)
        {
            InBattle = true;
            musicSource.Play();
        }

        else if (BattleReloadOnce)
        {
            InBattle = false;
            musicSource.Play();
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
        SearchAmount--;
        yield return new WaitForSeconds(SearchReload);
        SearchLightInactive();
        yield return new WaitForSeconds(WaitTimeSearch);
        NoMultipleLights = true;
    }

    IEnumerator ReloadSearchersAndTorps()
    {
        float OSearchAmountReload = Random.Range(SearchAmountReload - ReloadVariance, SearchAmountReload + ReloadVariance);
        yield return new WaitForSeconds(OSearchAmountReload);
        if(!InBattle && TorpAmount < MaxTorp)
        {    
            if(Search4 == SearchReloadTorp && SearchAmount < MaxSearch)
            {
                SearchAmount++;
                Search4 = 0f;
            }
            TorpAmount++;
            Search4++;
        }
        StartCoroutine(ReloadSearchersAndTorps());
    }
//SEARCHLIGHT ACTIVES;
    void SearchLightInactive()
    {
        SearchLight1.enabled = false;
        SearchLight2.enabled = false;
        Ship1.enabled = true;
        Ship2.enabled = false;
        Ship3.enabled = true;
    }


    void SearchLightActive()
    {
        SearchLight1.enabled = true;
        SearchLight2.enabled = true;
        Ship1.enabled = false;
        Ship2.enabled = true;
        Ship3.enabled = false;
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

    IEnumerator MoreShots()
    {
        yield return new WaitForSeconds(ShotReloadShot);
        if(!InBattle && ShotAmount < MaxShots)
        {
            ShotAmount++;
        }
        StartCoroutine(MoreShots());
    }
//BattleStuff
    public void YesBattle()
    {
        if(BattleReloadOnce)
        {
            BattleReloadOnce = false;
            InBattle = true;
            StartCoroutine(GetReloadBack());
        }
    }

    IEnumerator GetReloadBack()
    {
        yield return new WaitForSeconds(BattleReload);
        InBattle = false;
        BattleReloadOnce = true;
    }
//RAMDOM SCORE STUFF
    public void Improvment(float Improve)
    {
        if(Improve == 1)
        {
            TorpedoStuff();                     
        }
        else if(Improve == 2)
        {
            SearchStuff();                   
        }
        else if(Improve == 3)
        {
            ShotStuff();                    
        }
    }
    
    void TorpedoStuff()
    {
        float TorpImprove = Random.Range(1,5);
        if(TorpImprove == 1)
        {
            MaxTorp += MaxTorpImprov;
            Debug.Log("Improvement Happened" + MaxTorp);
        }
        if(TorpImprove == 2 && SearchAmountReload > SearchAmountReloadLimit)
        {
            SearchAmountReload -= SearchAmountReloadImprov;
            Debug.Log("Improvement Happened" + SearchAmountReload);
        }
        if(TorpImprove == 3 && TorpReloadTime > TorpReloadTimeLimit)
        {
            TorpReloadTime -= TorpReloadTimeImprov;
            Debug.Log("Improvement Happened" + TorpReloadTime);
        }
        if(TorpImprove == 4)
        {
            TorpSpeed.Invoke();
            Debug.Log("Improvement Happened" + ": Speed, Torp");
        }
    }

    void SearchStuff()
    {
        float SearchImprove = Random.Range(1,5);
        if(SearchImprove == 1)
        {
            MaxSearch += MaxSearchImprov;
            Debug.Log("Improvement Happened" + MaxSearch);
        }
        if(SearchImprove == 2 && SearchReloadTorp > SearchReloadTorpLimit)
        {
            SearchReloadTorp -= SearchReloadTorpImprov;
            Debug.Log("Improvement Happened" + SearchReloadTorp);
        }
        if(SearchImprove == 3 && TorpReloadTime > TorpReloadTimeLimit)
        {
            SearchReload += SearchReloadImprov;
            Debug.Log("Improvement Happened" + SearchReload);
        }
        if(SearchImprove == 4 && WaitTimeSearch > WaitTimeSearchLimit)
        {
            WaitTimeSearch -= WaitTimeSearchImprov;
            Debug.Log("Improvement Happened" + WaitTimeSearch);
        }
    }

    void ShotStuff()
    {
        float ShotImprove = Random.Range(1,5);
        if(ShotImprove == 1)
        {
            MaxShots += MaxShotsImprov;
            Debug.Log("Improvement Happened" + MaxShots);
        }
        if(ShotImprove == 2 && ShotReloadShot > ShotReloadShotLimit)
        {
            ShotReloadShot -= ShotReloadShotImprov;
            Debug.Log("Improvement Happened" + ShotReloadShot);
        }
        if(ShotImprove == 3 && ShotReloadTime > ShotReloadTimeLimit)
        {
            ShotReloadTime -= ShotReloadTimeImprov;
            Debug.Log("Improvement Happened" + ShotReloadTime);
        }
        if(ShotImprove == 4)
        {
            ShotSpeed.Invoke();
            Debug.Log("Improvement Happened" + ": Speed, Shot");
        }
    }

}
