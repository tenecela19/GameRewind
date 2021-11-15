using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillaPuzzle : MonoBehaviour
{
    public bool CanContinue = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tabla"))
        {
            CanContinue = true;
        }
    }
}
