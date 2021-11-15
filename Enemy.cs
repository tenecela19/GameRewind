using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public  int Edamage = 1;
    public float nextDamageEvent;
    public float attackDelay;
}
