using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaTeleport : MonoBehaviour
{
    public Transform PointToTeleport;
    public Transform CamaraTransformPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            FindObjectOfType<Camera>().transform.position = CamaraTransformPoint.position;
        }
    }
}
