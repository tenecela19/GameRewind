using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    #region Singleton
    private static ChangeMaterial _instance;
    public static ChangeMaterial Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ChangeMaterial>();
            }

            return _instance;
        }
    }


    #endregion
    public Material Past_M;
    public Material Present_M;
    public void ChangeMateria(bool IsChangedToPast) {
        if(IsChangedToPast == true)
        {
            GetComponent<Renderer>().sharedMaterial = Past_M; 
        }
        else
        {
            GetComponent<Renderer>().sharedMaterial = Present_M;

        }

    }
}
