using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab; // Reference to the tile prefab
    public int numRows = 10; // Number of rows
    public int numColumns = 10; // Number of columns
    public float distanceBetweenTiles = 10f; // Distance between tiles

    void Start()
    {
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
            }
        }
    }
}