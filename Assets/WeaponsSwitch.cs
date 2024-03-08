using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public Transform TorpedoLauncher;
    public GameObject Torpedo;
    public Light SearchLight1, SearchLight2;
    public float SearchReload;
    public float IncreaserStatic, Increaser, DecreaseStatic, Decreaser;
    void Start()
    {
        SearchLight1 = GetComponent<Light>();
        SearchLight2 = GetComponent<Light>();
        SearchLightInactive();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            TurnOnSearchers();
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
        SearchLightInactive();
    }

    IEnumerator IncreaseLight()
    {
        while(Increaser != 5)
        {
            yield return new WaitForSeconds(0.25f);
            SearchLight1.intensity += 0.1f;
            SearchLight2.intensity += 0.1f;
            Increaser++;
        }
    }

    IEnumerator DecreaseLight()
    {
        while(Decreaser != 0)
        {
            yield return new WaitForSeconds(0.25f);
            SearchLight1.intensity += 0.1f;
            SearchLight2.intensity -= 0.1f;
            Decreaser--;
        }

        if(Decreaser == 0f)
        {
            SearchLight1.enabled = false;
            SearchLight2.enabled = false;
        }
    }
//SEARCHLIGHT ACTIVES;
    void SearchLightInactive()
    {
        Decreaser = DecreaseStatic;
        StartCoroutine(DecreaseLight());
        SearchLight1.enabled = false;
        SearchLight2.enabled = false;
    }


    void SearchLightActive()
    {
        SearchLight1.enabled = true;
        SearchLight2.enabled = true;
        Increaser = IncreaserStatic;
        StartCoroutine(IncreaseLight());
    }

}
