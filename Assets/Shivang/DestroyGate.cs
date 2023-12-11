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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            countStars += 1;
        }
    }
    private void Update()
    {
        if (countStars == 8)
        {
            Destroy(door);
        }
    }

}

