﻿using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile : KeyboardMover
{
    [SerializeField]
    Tilemap tilemap = null;

    [SerializeField]
    TileBase tileOnQuarrying;

    [SerializeField]
    TileBase tileAfterQuarrying;

    [SerializeField]
    AllowedTiles allowedTiles = null;

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()
    {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contain(tileOnNewPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            // For quarrying mountains:
            if (tileOnNewPosition != null && tileOnNewPosition.name == "mountains")
            {
                if (Input.GetKey("x"))
                {
                    Vector3Int newPositionV3 = tilemap.WorldToCell(newPosition);
                    tilemap.SetTile (newPositionV3, tileOnQuarrying);
                }

                Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
            }

            if (tileOnNewPosition != null && tileOnNewPosition.name == tileOnQuarrying.name)
            {
                if (Input.GetKey("x"))
                {
                    Vector3Int newPositionV3 = tilemap.WorldToCell(newPosition);
                    tilemap.SetTile (newPositionV3, tileAfterQuarrying);
                    transform.position = newPosition;
                }
            }
            //
        }
    }
}
