using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public float RegenTick = 0.1f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AreaLight"))
        {
           StartCoroutine(ViewPastObjects.Instance.RegenStamina(RegenTick));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AreaLight"))
        {
            StopCoroutine(ViewPastObjects.Instance.RegenStamina(RegenTick));
        }
    }
}
