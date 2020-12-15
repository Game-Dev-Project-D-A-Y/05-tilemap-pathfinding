using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] int rows = 5;
    [SerializeField] int cols = 8;
    [SerializeField] float tileSize = 1;
    [SerializeField] Tile grass;
    [SerializeField] Tile hills;
    [SerializeField] Tile swamp;
    [SerializeField] Tile shallow_sea;
    [SerializeField] Tilemap tilemap;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int x = -rows; x < rows; x++)
        {
            for (int y = -cols; y < cols; y++)
            {
                Vector3Int p = new Vector3Int(x, y, 0);
                bool odd = (x + y) % 2 == 1;
                // Tile tile = odd ? water : land;
                tilemap.SetTile(p, grass);
            }
        }
        for (int x = -rows; x < rows; x++)
        {
            for (int y = -cols; y < cols; y++)
            {
                Vector3Int p = new Vector3Int(x, y, 0);
                bool odd = (x + y) % 2 == 1;
                // Tile tile = odd ? water : land;
                tilemap.SetTile(p, grass);
            }
        }



    }
    /*
    public void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(objToInit);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                float posX = col * tileSize;
                float posY = row * tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
}
