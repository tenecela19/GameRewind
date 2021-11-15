using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoDeCartas : MonoBehaviour
{
    public int[] Numeros;
    public Text[] TextoNumerosCarta;
    public bool[] CartaDeCuartoAbierta;
    public GameObject CajaFuerte;
    public string codigoFinal;
    public GameObject Cuadro;
    public int UltimoCuarto =2;
    // Start is called before the first frame update

    #region Singleton
    private static CodigoDeCartas _instance;
    public static CodigoDeCartas Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CodigoDeCartas>();
            }

            return _instance;
        }
    }
    #endregion
    void Start()
    {

        for (int i = 0; i < Numeros.Length; i++)
        {
            Numeros[i] = Random.Range(0, 10);
            TextoNumerosCarta[i].text = Numeros[i].ToString();
        }
        for (int i = 0; i < 3; i++)
        {
            codigoFinal += Instance.Numeros[i].ToString();
        }
    }
    private void Update()
    {
    }
}

