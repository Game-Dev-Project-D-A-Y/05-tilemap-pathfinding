# Tilemap - Path Finding  
## Weekly assignment No8 Part A,C,D,E   
    
    
### Part A - Dijkstra's algorithm   
We implemented a [Dijkstra script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/Dijkstra.cs) (you may see all the  notes in the script)  and swapped the BFS part to Dijkstra. To implement this code we **added** to the [IWeightedGraph](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/IWeightedGraph.cs) two functions: _Equals_ & _Weight_ and we implemented them in [TileWeightedGraph](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/TileWeightedGraph.cs).    
    
### Part C - Unique speed for tiles
We added to _MoveTowardsTheTarget_ function in [TargetMover script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/2-player/TargetMover.cs) a simple check of the type of tile we are on and according to it we change the speed.  

### Part D - Randomize Map   
