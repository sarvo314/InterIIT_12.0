using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("something entered");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();
        }
       
    }
}
