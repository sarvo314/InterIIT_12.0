using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Die();
        }
       
    }
}
