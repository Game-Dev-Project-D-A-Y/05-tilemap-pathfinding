using System.Collections.Generic;

public interface IWeightedGraph<T>
{
    IEnumerable<T> Neighbors(T node);
    bool Equals(T node1, T node2);
    double Weight(T node1, T node2);
}