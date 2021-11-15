using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel_Final : MonoBehaviour
{
    public bool [] NotasRecolectadas;
    public GameObject[] Notas;
    #region Singleton
    private static Nivel_Final _instance;
    public static Nivel_Final Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Nivel_Final>();
            }

            return _instance;
        }
    }
    #endregion 

    private void Start()
    {
        Notas[0].SetActive(true);
        for (int i = 1; i < Notas.Length; i++)
        {
            Notas[i].SetActive(false);
        }
    }
    public void Update()
    {
        NotasTomadas();
    }


    public void NotasTomadas()
    {

        if(NotasRecolectadas[0] == true)
        {
            Notas[1].SetActive(true);
        }
        if(NotasRecolectadas[1] == true)
        {
            Notas[2].SetActive(true);
        }
        if(NotasRecolectadas[2] == true)
        {
            Notas[3].SetActive(true);
        }
    }
               
}

