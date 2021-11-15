using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaCreditos : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            if (CajaFuerteControl.Instance.HasGanado == true)
            {
                FindObjectOfType<AudioManager>().Play("PuertaAbierta");

                SceneManager.LoadScene("Creditos");
            }
            FindObjectOfType<AudioManager>().Play("PuertaConllave");
        }

    }

}
