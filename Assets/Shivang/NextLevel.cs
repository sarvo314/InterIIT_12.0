using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] private Player player;

    private void Start()
    {
        portal.SetActive(false);
       
    }
    // Update is called once per frame
    void Update()
    {
        if (player.CountStars == 15)
        {
            portal.SetActive(true);
        }
    }
}
