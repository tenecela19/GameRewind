using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
   
    #region Singleton
    private static EnemyController _instance;
    public static EnemyController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<EnemyController>();
            }

            return _instance;
        }
    }


    #endregion
    public Animator anim;

    public NavMeshAgent Eagent;
    Transform Player;

    [Header("Enemy Settings")]
    public Enemy enemy;
    public  int health = 10;
    public bool StopMoving;

    void Start() {
       
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (ViewPastObjects.Instance.IsActive == false && gameObject.GetComponentInChildren<EnemyFollow>().IsInArea == true)
        {
            Eagent.isStopped = false;
        }
            if (Eagent.isStopped == false && gameObject.GetComponentInChildren<EnemyFollow>().IsInArea == true)
            {

                anim.SetBool("isWalking", true);
                Eagent.SetDestination(Player.position);
            }
        
        if(gameObject.GetComponentInChildren<EnemyFollow>().IsInArea == false)
        {
            anim.SetBool("isWalking", false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Jugador esta muerto ");
            Player.GetComponent<Player_Move>().Isdead = true;
            Player.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
            if (other.gameObject.CompareTag("AreaKill"))
            {
            Debug.Log("IsinArea");
            anim.SetBool("isWalking", false);
            Eagent.isStopped = true;

            }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AreaKill") && ViewPastObjects.Instance.IsActive == true)
        {
            Eagent.isStopped = false;
        }
        if (other.gameObject.CompareTag("AreaKill") && ViewPastObjects.Instance.IsActive == false)
        {
            anim.SetBool("isWalking", false);
            Eagent.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
       Eagent.isStopped = true;
      anim.SetBool("isWalking", false);
    }
}
