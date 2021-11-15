using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NIvelTcela : MonoBehaviour
{
    public bool[] NotasRecolectadas;
    public GameObject[] Notas;
    public PastillaPuzzle pastilla;
    public GameObject Pastillaobjects;
    #region Singleton
    private static NIvelTcela _instance;
    public static NIvelTcela Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<NIvelTcela>();
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

        if (NotasRecolectadas[0] == true && pastilla.CanContinue == true)
        {
            Notas[1].SetActive(true);
           //Pastillaobjects.SetActive(true);
        }
        if (NotasRecolectadas[1] == true )
        {
            Notas[2].SetActive(true);
        }
    }

}