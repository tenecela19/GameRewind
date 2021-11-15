using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public Light lightpoint;
    public float TimeToShow;

    private void Update()
    {
        StartCoroutine(ParpadeoLuz());
    }
    IEnumerator ParpadeoLuz()
    {
        if(lightpoint.isActiveAndEnabled == true)
        {
            lightpoint.enabled = true;
            yield return new WaitForSeconds(TimeToShow);
            lightpoint.enabled = false;
        }
        if (lightpoint.isActiveAndEnabled == false)
        {
             lightpoint.enabled = false;
            yield return new WaitForSeconds(TimeToShow);
            lightpoint.enabled = true;
        }
       
    }
}
