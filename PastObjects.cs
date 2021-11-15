using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastObjects : MonoBehaviour
{

    private void OntriggerExit(Collider other)
    {
 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
