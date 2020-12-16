using System;
using System.Collections.Generic;
using System.Diagnostics;

using IntPair = System.ValueTuple<int, int>;


/**
 * A unit-test for the abstract BFS algorithm.
 * @author Erel Segal-Halevi
 * @since 2020-02
 */
namespace TestDijkstra
{

    class IntGraph : IWeightedGraph<int>
    {
        public IEnumerable<int> Neighbors(int node)
        {
            yield return node + 1;
            yield return node - 1;
        }

        public bool Equals(int node1, int node2)
        {
            return node1 == node2;
        }

        public double Weight(int node1, int node2)
        {
            return 1;
        }
    }

    class IntPairGraph : IWeightedGraph<IntPair>
    {
        public IEnumerable<IntPair> Neighbors(IntPair node)
        {
            yield return (node.Item1, node.Item2 + 1);
            yield return (node.Item1, node.Item2 - 1);
            yield return (node.Item1 + 1, node.Item2);
            yield return (node.Item1 - 1, node.Item2);
        }

        public bool Equals(IntPair node1, IntPair node2)
        {
            return node1.Item1 == node2.Item1 && node1.Item2 == node2.Item2;
        }

        public double Weight(IntPair node1, IntPair node2)
        {
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Dijkstra Test");

            //Test 1
            Console.WriteLine("  ");
            Console.WriteLine("Test No 1 ");
            var intGraph = new IntGraph();
            var path = Dijkstra.ShortestPath(intGraph, 900, 905);
            var pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "900,901,902,903,904,905");

            //Test 2
            Console.WriteLine("  ");
            Console.WriteLine("Test No 2 ");
            path = Dijkstra.ShortestPath(intGraph, 85, 80);
            pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "85,84,83,82,81,80");

            //Test 3
            Console.WriteLine("  ");
            Console.WriteLine("Test No 3 ");
            var intPairGraph = new IntPairGraph();
            var path2 = Dijkstra.ShortestPath(intPairGraph, (9, 5), (7, 6));
            pathString = String.Join(",", path2.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(9, 5),(9, 6),(8, 6),(7, 6)");

            //Test 4
            Console.WriteLine("  ");
            Console.WriteLine("Test No 4 ");
            intPairGraph = new IntPairGraph();
            var path3 = Dijkstra.ShortestPath(intPairGraph, (3002, 3010), (3011, 3010));
            pathString = String.Join(",", path3.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(3002, 3010),(3003, 3010),(3004, 3010),(3005, 3010)," +
                "(3006, 3010),(3007, 3010),(3008, 3010),(3009, 3010),(3010, 3010),(3011, 3010)");

            //test 5
            Console.WriteLine("  ");
            Console.WriteLine("Test No 5 ");
            intPairGraph = new IntPairGraph();
            var path4 = Dijkstra.ShortestPath(intPairGraph, (252, -2), (256, 4));
            pathString = String.Join(",", path4.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(252, -2),(252, -1),(252, 0),(252, 1),(252, 2)," +
                "(252, 3),(252, 4),(253, 4),(254, 4),(255, 4),(256, 4)");

            // Here we should get an empty path because of maxiterations:
            //Test 6
            Console.WriteLine("  ");
            Console.WriteLine("Test No 6 ");
            intPairGraph = new IntPairGraph();
            var path5 = Dijkstra.ShortestPath(intPairGraph, (100, 100), (2010, -5));
            pathString = String.Join(",", path5.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(100, 100)");
            Console.WriteLine(" No Path Under 1000 iterations ");


            // Here we should get an empty path because of maxiterations:
            //Test 7
            Console.WriteLine("  ");
            Console.WriteLine("Test No 7 ");
            int maxiterations = 1000;
            var path6 = Dijkstra.ShortestPath(intPairGraph, (50, 2), (-7, -6), maxiterations);
            pathString = String.Join(",", path6.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(50, 2)");
            Console.WriteLine(" No Path Under 1000 iterations ");

            //test 8  - point to the same point
            Console.WriteLine("  ");
            Console.WriteLine("Test No 8 ");
            intPairGraph = new IntPairGraph();
            var path7 = Dijkstra.ShortestPath(intPairGraph, (5, -6), (5, -6));
            pathString = String.Join(",", path7.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(5, -6)");


            Console.WriteLine("Dijkstra Test Completed Successfully");
        }
    }

}