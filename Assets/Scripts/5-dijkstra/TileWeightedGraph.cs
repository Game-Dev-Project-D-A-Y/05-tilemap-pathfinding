using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A graph that represents a tilemap, using only the allowed tiles.
 */
public class TileWeightedGraph : IWeightedGraph<Vector3Int>
{
    private Tilemap tilemap;
    private TileBase[] allowedTiles;

    public TileWeightedGraph(Tilemap tilemap, TileBase[] allowedTiles)
    {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
    }

    static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
    };

    public IEnumerable<Vector3Int> Neighbors(Vector3Int node)
    {
        foreach (var direction in directions)
        {
            Vector3Int neighborPos = node + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            if (allowedTiles.Contains(neighborTile))
                yield return neighborPos;
        }
    }

    public bool Equals(Vector3Int node1, Vector3Int node2)
    {
        return node1.x == node2.x && node1.y == node2.y && node1.z == node2.z;
    }

    public double Weight(Vector3Int node1, Vector3Int node2)
    {
        TileBase node1Tile = tilemap.GetTile(node1);
        TileBase node2Tile = tilemap.GetTile(node2);
        switch (node2Tile.name)
        {
            case "bushes":
                return 4;
                
            case "swamp":
                return 1;

            case "hills":
                return 10;

            case "grass":
                return 3;

            default:
                return 1 ;

        }


    }
}
