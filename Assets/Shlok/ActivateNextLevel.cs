using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNextLevel : MonoBehaviour
{
    [SerializeField] GameObject portal;
    // Start is called before the first frame update
    [SerializeField] private Player player;
    private void Update()
    {
        if (player.CountStars == 6)
        {
            portal.SetActive(true);
        }
    }
}
