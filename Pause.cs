using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool IsOn = false;
    public GameObject MenuSecu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play("BotonPausa");
            if(IsOn == false)
            {
                IsOn = true;
                MenuSecu.SetActive(IsOn);

            }
            else
            {
                IsOn = false;
                MenuSecu.SetActive(IsOn);

            }

        }
        
    }
}
