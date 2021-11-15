using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelBano : MonoBehaviour
{
    public bool[] NotasRecolectadas;
    public GameObject[] Notas;
    #region Singleton
    private static NivelBano _instance;
    public static NivelBano Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<NivelBano>();
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

        if (NotasRecolectadas[0] == true)
        {
            Notas[1].SetActive(true);
        }

    }
}
