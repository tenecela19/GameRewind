using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {


    private Inventory inventory;
    public int index;

    private void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("CajaFuerte").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) {
            inventory.items[index] = 0;
        }
    }

}
