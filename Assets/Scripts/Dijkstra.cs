using System;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra
{
	public static List<TNode> ShortestPath<TNode>(
		IWeightedGraph<TNode> graph,
		TNode sourceNode,
		TNode targetNode,
		Func<TNode, TNode, bool> fnEquals,
		Func<TNode, TNode, double> fnDistance,
		int maxiterations = 1000
	)
	{
		// Initialize values
		Dictionary<TNode, double> distance = new Dictionary<TNode, double>();
		Dictionary<TNode, TNode> previous = new Dictionary<TNode, TNode>();
		List<TNode> localNodes = new List<TNode>();

		localNodes.Add(sourceNode);
		distance.Add(sourceNode, 0);  //distance[sourceNode] = 0;

		int i = 0;
		while (localNodes.Count > 0 && i < maxiterations)
		{
			i++;
			// Return and remove best vertex (that is, connection with minimum distance
			TNode minNode = localNodes.OrderBy(n => distance[n]).First();
			localNodes.Remove(minNode);

			// Loop all connected nodes
			// foreach (TNode neighbor in connections[minNode])
			foreach (TNode neighbor in graph.Neighbors(minNode))
			{
				if (!distance.ContainsKey(neighbor))
				{
					localNodes.Add(neighbor);
					distance.Add(neighbor, double.PositiveInfinity);
				}

				// The positive distance between node and it's neighbor, added to the distance of the current node
				double dist = distance[minNode] + fnDistance(minNode, neighbor);

				if (dist < distance[neighbor])
				{
					distance[neighbor] = dist;
					previous[neighbor] = minNode;
				}
			}

			// If we're at the target node, break
			if (fnEquals(minNode, targetNode))
				break;
		}

		// Construct a list containing the complete path. We'll start by looking at the previous node of the target and then making our way to the beginning.
		// We'll reverse it to get a source->target list instead of the other way around. The source node is manually added.
		List<TNode> result = new List<TNode>();
		TNode target = targetNode;

		while (previous.ContainsKey(target))
		{
			result.Add(target);
			target = previous[target];
		}
		result.Add(sourceNode);
		result.Reverse();


		return result;

	}
}