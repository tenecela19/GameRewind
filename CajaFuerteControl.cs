using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaFuerteControl : MonoBehaviour
{
    public Text CajaFuerteClave;
    public GameObject Wrong;
    public GameObject Win;
    public bool WrongCode;
    public Sprite Past_im;
    public Sprite Present_im;
    public GameObject Botones;
    public GameObject UICajaFuerte;
    public bool HasGanado =false;
    #region Singleton
    private static CajaFuerteControl _instance;
    public static CajaFuerteControl Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CajaFuerteControl>();
            }

            return _instance;
        }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {

        if (UICajaFuerte.GetComponent<Image>().sprite == Past_im)
        {
            if (CajaFuerteClave.text == CodigoDeCartas.Instance.codigoFinal)
            {
                HasGanado = true;
                StartCoroutine(HasGanadoTio());
            }
            if (CajaFuerteClave.text != CodigoDeCartas.Instance.codigoFinal && CajaFuerteClave.text.Length == CodigoDeCartas.Instance.Numeros.Length)
            {
                StartCoroutine(TiempoDeError());

            }
            Botones.SetActive(true);
        }
        else
        {
            Botones.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("AccesoDenegado");
            FindObjectOfType<AudioManager>().Stop("AccesoConcedido");

        }

    }
    IEnumerator TiempoDeError()
    {
        WrongCode = true;
        FindObjectOfType<AudioManager>().Play("AccesoDenegado");
        Wrong.SetActive(true);
        yield return new WaitForSeconds(2);
        CajaFuerteClave.text = "";
        Wrong.SetActive(false);
        WrongCode = false;
    }
    IEnumerator HasGanadoTio()
    {
        Win.SetActive(true);
        FindObjectOfType<AudioManager>().Play("AccesoConcedido");
        yield return new WaitForSeconds(1);
        CajaFuerteClave.text = "";
        Win.SetActive(false);
    }
}
