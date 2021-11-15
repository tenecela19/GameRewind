using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigo : MonoBehaviour
{
    #region Singleton
    private static Codigo _instance;
    public static Codigo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Codigo>();
            }

            return _instance;
        }
    }
    #endregion
    public int cuarto;
}
