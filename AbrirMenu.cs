using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{
    public GameObject menu; //activar canvas de menu
    public GameObject activacionDeMenu; //instruccioens de como activar

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Presiona A para mover la camara a la derecha
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("Start");
            menu.gameObject.SetActive(true);
            activacionDeMenu.gameObject.SetActive(false);
        }
    }
}
