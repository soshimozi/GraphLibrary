using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public interface IGraph<T>
    {
        bool AddVertex(T vertex);
        void AddVertex(IEnumerable<T> vertices);
        bool RemoveVertex(T vertex);
        void RemoveVertex(IEnumerable<T> vertices);
        bool AddEdge(T v1, T v2);
        void AddEdge(IEnumerable<Tuple<T, T>> edges);
        void RemoveEdge(T v1, T v2);
        bool IsAdjacent(T v1, T v2);
        int Degree(T vertex);
        int DegreeOut(T vertex);
        int DegreeIn(T vertex);
        IEnumerable<T> AdjacentVertices(T vertex);
        IEnumerable<T> Vertices { get; }
        IEnumerable<Tuple<T, T>> Edges { get; }


    }
}
