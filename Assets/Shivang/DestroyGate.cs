using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyGate : MonoBehaviour
{
    [SerializeField] GameObject door;
    private int countStars;
    // Start is called before the first frame update
    [SerializeField] private Player player;
    private void Update()
    {
        if (player.CountStars == 8)
        {
            Destroy(door);
        }
    }

}

