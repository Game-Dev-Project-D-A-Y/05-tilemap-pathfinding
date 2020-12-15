using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int rows = 5;
    [SerializeField] int cols = 8;
    [SerializeField] float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Grass"));

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
    // Update is called once per frame
    void Update()
    {
        
    }
}
