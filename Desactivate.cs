using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Desactivate : MonoBehaviour
{
    public GameObject back;
public void Desactivates()
    {
        back.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
