using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public int Regenerate;


    private void Oncol(Collider other)
    {

        }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Move>().AddPowerToPast(Regenerate);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
