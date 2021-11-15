using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
public class NumeroCaja : MonoBehaviour
{
    private Inventory inventory;
    public Text numtext;
    public int num;
    public void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("CajaFuerte").GetComponent<Inventory>();

    }
    public void NumeroQueSeleccionar()
    {
        FindObjectOfType<AudioManager>().Play("BotonCajaFuerte");
        if(CajaFuerteControl.Instance.UICajaFuerte.GetComponent<Image>().sprite == CajaFuerteControl.Instance.Past_im)
        {
            if (CajaFuerteControl.Instance.WrongCode == false)
            {
                CheckString();
            }

        }
        else
        {
            return;
        }

    }
    void CheckString()
    {
        if (numtext.text.Length > 2)
        {
            numtext.text = numtext.text.Substring(0, 3);
        }
        else
        {
                    numtext.text += num;
        }
    }
}
