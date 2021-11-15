using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    #region Singleton
    private static EnemyFollow _instance;
    public static EnemyFollow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyFollow>();
            }

            return _instance;
        }
    }


    #endregion

    public bool IsInArea;
    bool PlaySongOnce =true;

    public void Awake()
    {
        IsInArea = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            if(PlaySongOnce == true)
            {
                FindObjectOfType<AudioManager>().Play("Enemigo");
                PlaySongOnce = false;
            }
            IsInArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInArea = false;
        }
    }
}
