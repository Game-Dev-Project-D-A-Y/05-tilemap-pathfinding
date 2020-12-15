using System;
using System.Collections.Generic;
using System.Diagnostics;

using IntPair = System.ValueTuple<int, int>;


/**
 * A unit-test for the abstract BFS algorithm.
 * @author Erel Segal-Halevi
 * @since 2020-02
 */
namespace TestDijkstra {

    class IntGraph: IWeightedGraph<int> {
        public IEnumerable<int> Neighbors(int node) {
            yield return node + 1;
            yield return node - 1;
        }

        public bool Equals(int node1,int node2) {
            return node1 == node2;
        }

        public double Weight(int node1, int node2) {
            return 1;
        }
    }

    class IntPairGraph : IWeightedGraph<IntPair> {
        public IEnumerable<IntPair> Neighbors(IntPair node) {
            yield return (node.Item1, node.Item2 + 1);
            yield return (node.Item1, node.Item2 - 1);
            yield return (node.Item1 + 1, node.Item2);
            yield return (node.Item1 - 1, node.Item2);
        }

        public bool Equals(IntPair node1,IntPair node2) {
            return node1.Item1 == node2.Item1 && node1.Item2 == node2.Item2;
        }

        public double Weight(IntPair node1, IntPair node2) {
            return 1;
        }
    }

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Start BFS Test");

            var intGraph = new IntGraph();
            var path = Dijkstra.ShortestPath(intGraph, 90, 95);
            var pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "90,91,92,93,94,95");
            path = Dijkstra.ShortestPath(intGraph, 85, 80);
            pathString = String.Join(",", path.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "85,84,83,82,81,80");

            var intPairGraph = new IntPairGraph();
            var path2 = Dijkstra.ShortestPath(intPairGraph, (9, 5), (7, 6));
            pathString = String.Join(",", path2.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "(9, 5),(8, 5),(7, 5),(7, 6)");

            // Here we should get an empty path because of maxiterations:
            int maxiterations = 1000;
            path2 = Dijkstra.ShortestPath(intPairGraph, (9, 5), (-7,-6), maxiterations); 
            pathString = String.Join(",", path2.ToArray());
            Console.WriteLine("path is: " + pathString);
            Debug.Assert(pathString == "");

            Console.WriteLine("End BFS Test");
        }
    }

}