using UnityEngine;
using Random = UnityEngine.Random;
public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Reference to the tile prefab
    public int numRows = 10; // Number of rows
    public int numColumns = 10; // Number of columns
    public float distanceBetweenTiles = 10f; // Distance between tiles
    
    public GameObject starPrefab; // Reference to the star prefab
    //Offset for position above tile
    private float offset ;

    void Start()
    {
        offset = starPrefab.transform.localScale.y / 2;
        GenerateTiles();
    }

    void GenerateTiles()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                Vector3 tilePosition = new Vector3(col * distanceBetweenTiles, 0f, row * distanceBetweenTiles);
                Instantiate(tilePrefab, tilePosition, Quaternion.identity, transform);
                //5% probability of instantiating a star
                if (Random.Range(0f, 1f) > 0.05f)
                {
                    Instantiate(starPrefab, tilePosition + Vector3.up*offset, Quaternion.identity, transform);
                }
            }
        }
    }
}