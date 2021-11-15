using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notas : MonoBehaviour
{
    #region Singleton
    private static Notas _instance;
    public static Notas Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Notas>();
            }

            return _instance;
        }
    }
    #endregion

    public enum NOTASLUGARES {Oficina,bano,cocina }
    public int NotasNum;
    public  NOTASLUGARES GetNOTASLUGARES;
}
