using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component moves its object towards a given target position.
 */
public class TargetMover: MonoBehaviour {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;

    [Tooltip("The speed by which the object moves towards the target, in meters (=grid units) per second")]
    [SerializeField] float speed = 2f;
    [SerializeField] float speedOfBushes = 1.5f;
    [SerializeField] float speedOfHills = 1f;

    [Tooltip("Maximum number of iterations before BFS algorithm gives up on finding a path")]
    [SerializeField] int maxIterations = 1000;

    [Tooltip("The target position in world coordinates")]
    [SerializeField] Vector3 targetInWorld;

    [Tooltip("The target position in grid coordinates")]
    [SerializeField] Vector3Int targetInGrid;

    protected bool atTarget;  // This property is set to "true" whenever the object has already found the target.

    public void SetTarget(Vector3 newTarget) {
        if (targetInWorld != newTarget) {
            targetInWorld = newTarget;
            targetInGrid = tilemap.WorldToCell(targetInWorld);
            atTarget = false;
        }
    }

    public Vector3 GetTarget() {
        return targetInWorld;
    }

    //private TilemapGraph tilemapGraph = null;
    private TileWeightedGraph tilemapGraph;
    private float timeBetweenSteps;

    protected virtual void Start() {
        //tilemapGraph = new TilemapGraph(tilemap, allowedTiles.Get());
        tilemapGraph = new TileWeightedGraph(tilemap, allowedTiles.Get());


        StartCoroutine(MoveTowardsTheTarget());
    }

    IEnumerator MoveTowardsTheTarget() {
        for(;;) {
            Debug.Log(""+tilemap.GetTile(tilemap.WorldToCell(transform.position)));

            TileBase currTile = tilemap.GetTile(tilemap.WorldToCell(transform.position));
            if(currTile.name == "bushes")
            {
                // timeBetweenSteps *= 1/0.9f ;
                timeBetweenSteps = 1/speedOfBushes;
            }
            if (currTile.name == "hills")
            {
                // timeBetweenSteps *= 1/0.9f ;
                timeBetweenSteps = 1/speedOfHills;
            }
            if (currTile.name == "swamp")
            {
                timeBetweenSteps = 1 / speed;
            }
            if (currTile.name == "grass")
            {
                timeBetweenSteps = 1 / speed;
            }


            yield return new WaitForSeconds(timeBetweenSteps);
            if (enabled && !atTarget)
                MakeOneStepTowardsTheTarget();
        }
    }

    private void MakeOneStepTowardsTheTarget() {
        Vector3Int startNode = tilemap.WorldToCell(transform.position);
        Vector3Int endNode = targetInGrid;
        //List<Vector3Int> shortestPath = BFS.GetPath(tilemapGraph, startNode, endNode, maxIterations);
        List<Vector3Int> shortestPath = Dijkstra.ShortestPath<Vector3Int>(tilemapGraph, 
            startNode, 
            endNode, 
            tilemapGraph.Equals, 
            tilemapGraph.Weight, 
            maxIterations);

        Debug.Log("shortestPath1 = " + string.Join(" , ",shortestPath));
        if (shortestPath.Count >= 2) {
            Vector3Int nextNode = shortestPath[1];
            transform.position = tilemap.GetCellCenterWorld(nextNode);
        } else {
            atTarget = true;
        }
    }
}
