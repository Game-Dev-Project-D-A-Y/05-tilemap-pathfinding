# Tilemap - Path Finding  
## Weekly assignment No8 Part A,C,D,E  

#### [View On Itch](https://game-dev-project-d-a-y.itch.io/dijkstracave)
<img src=https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/itch.jpg width="180"/>    
    
    
### Part A - Dijkstra's algorithm   
We implemented a [Dijkstra script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/Dijkstra.cs) (you may see all the  notes in the script)  and swapped the BFS part to Dijkstra. To implement this code we **added** to the [IWeightedGraph](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/IWeightedGraph.cs) two functions: _Equals_ & _Weight_ and we implemented them in [TileWeightedGraph](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/5-dijkstra/TileWeightedGraph.cs).    
    
[Dijkstra Unit Test](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/TestBFS/TestDijkstra.cs)
    
<img src= https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/tests.jpg width="250"/> 
### Part C - Unique speed for tiles
We added to _MoveTowardsTheTarget_ function in [TargetMover script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/2-player/TargetMover.cs) a simple check of the type of tile we are on and according to it we change the speed.  

### Part D - Randomize Map   
<img src=https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Generate%20Map.jpg width="300"/>    
    
    
We changed in [TilemapCaveGenerator script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/4-generation/TilemapCaveGenerator.cs) in the GenerateAndDisplayTexture() function, oldBuffer which holds integer numbers ( 1,0,-1) where each one of them represents some tile.
after adding to oldBuffer the numbers. In CaveGenerator script in the SmoothMap() function we updated to newBuffer new numbers ( 1,0,-1) by checking the size of surroundingWalls which will change the tile depends on the number of surroundingWalls.
The change on the surroundingWalls in our [script](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/4-generation/CaveGenerator.cs) is that if we have less than 4 walls we check what is the most common tile surronding the current tile and we change it according to the number of surroundingWalls.
After updating the newBuffer with the right numbers we change each number (1,0,-1) to the representing tile.

### Part E - "Digging" the mountain until it becoms grass   
    
<img src=https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/digging.jpg width="300"/>    
  
While pressing the 'X' key our player can dig through "mountain" tile only while the first strike will make the tile purpule the seconed stroke will make it grass.    
We uset the **setTile** command to change the tile every time you are infront of a 'mountain' tile and you have pressed x (same with second stroke). Please look at our [KeyboardMoverByTile](https://github.com/Game-Dev-Project-D-A-Y/05-tilemap-pathfinding/blob/master/Assets/Scripts/2-player/KeyboardMoverByTile.cs) script
