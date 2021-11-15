using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject DeadUI;
    public bool GameOver;
    void Update()
    {
        if(Player_Move.Instance.Isdead == true)
        {
            GameOver = true;
            IsGameover();
        }
    }



    void IsGameover()
    {
        if(GameOver == true)
        {
            FindObjectOfType<AudioManager>().Stop("MusicaAmbiente");
            FindObjectOfType<AudioManager>().Play("Muerte");
            DeadUI.SetActive(true);
        }
    }
}
