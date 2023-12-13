using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FloorCollapse : MonoBehaviour
{
    [SerializeField] private GameObject navMeshLinks;
    [SerializeField] private GameObject mimic;
    [SerializeField] private BreakableTile[] floorTiles;
    private float delay = 11;
    private float difference = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var tile in floorTiles)
        {
            BoxCollider boxcollidertile = tile.GetComponent<BoxCollider>();
            boxcollidertile.enabled = false;
        }
    }

    private void BreakTile(BreakableTile tile)
    {
        tile.BreakTileSequence();
    }

    private void DeactivateNavMashLinks()
    {
        navMeshLinks.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(BreakTilesWithDelay());
        }
        
    }
    IEnumerator BreakTilesWithDelay()
    {
        foreach (var tile in floorTiles)
        {
            tile.breakDelay = delay;
            yield return new WaitForSeconds(tile.breakDelay);
            BreakTile(tile);
            delay = difference;
        }
        if (mimic.transform.position.y < 4)
        {
            DeactivateNavMashLinks();
        }
    }
}
