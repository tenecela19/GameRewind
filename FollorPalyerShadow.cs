using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollorPalyerShadow : MonoBehaviour
{
    public GameObject Player;

    public enum ShadowDirection { Xaxis, ZAxis }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public ShadowDirection shadow;
    void Update()
    {
        if(shadow == ShadowDirection.Xaxis)
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
        }
        if(shadow == ShadowDirection.ZAxis)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z);

        }
    }
}
