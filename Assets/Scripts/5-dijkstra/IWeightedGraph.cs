using System.Collections.Generic;

/**
* Interface that represents weighted graph which its nodes are T type
*/
public interface IWeightedGraph<T>
{
    /**
    * Returns iterable container of 'node' neighbors
    */
    IEnumerable<T> Neighbors(T node);

    /**
    * Returns whether node1 and node2 are equals
    */
    bool Equals(T node1, T node2);

    /**
    * Returns the weight between node1 and node2
    */
    double Weight(T node1, T node2);
}