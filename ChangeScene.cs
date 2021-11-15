using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int WaitForSeconds;

    public void Scene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void WaitForSceneToInvoke() {
     Invoke("InvokeScene", WaitForSeconds);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void InvokeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
