using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile: KeyboardMover {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] TileBase tileChangeFirst =null ;
    [SerializeField] TileBase tileChangeSecond =null ;


    [SerializeField] AllowedTiles allowedTiles = null;

    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()  {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contain(tileOnNewPosition)) {
            transform.position = newPosition;
        } else {
            if (tileOnNewPosition != null && tileOnNewPosition.name == "mountains")
            {
                if (Input.GetKey("x"))
                {
                    Vector3Int newPositionV3 = tilemap.WorldToCell(newPosition);
                    tilemap.SetTile(newPositionV3,tileChangeFirst);

                }
                
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
            }
                    if (tileOnNewPosition != null && tileOnNewPosition.name == "mountainBreak")
                    {
                          if (Input.GetKey("x"))
                            {
                                 Vector3Int newPositionV3 = tilemap.WorldToCell(newPosition);
                                 tilemap.SetTile(newPositionV3,tileChangeSecond);
                                transform.position = newPosition;
                            }
                    }

        }
    }
}
