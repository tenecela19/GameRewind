using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnim : MonoBehaviour
{
    public GameObject DeadText;

   public void IsDead()
    {
        DeadText.SetActive(true);
    }
}
