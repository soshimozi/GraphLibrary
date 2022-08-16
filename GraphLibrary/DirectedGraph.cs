using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public class DirectedGraph<T> : GraphBase<T>
    {
        public override bool AddEdge(T v1, T v2)
        {
            if (!_vertices.Contains(v1) || !_vertices.Contains(v2)) throw new ArgumentException();

            var edge = new Tuple<T, T>(v1, v2);

            if (_edges.Contains(edge)) return false;

            _edges.Add(edge);
            return true;
        }

        public override void AddEdge(IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var edge in edges)
            {
                AddEdge(edge.Item1, edge.Item2);
            }
        }

        public override void RemoveEdge(T v1, T v2)
        {
            if (!_vertices.Contains(v1) || !_vertices.Contains(v2)) throw new ArgumentException();

            var edge = new Tuple<T, T>(v1, v2);
            if (_edges.Contains(edge))
            {
                _edges.Remove(edge);
            }
        }

        public override bool IsAdjacent(T v1, T v2)
        {
            if (!_vertices.Contains(v1) || !_vertices.Contains(v2)) throw new ArgumentException();
            var edge = new Tuple<T, T>(v1, v2);

            // look for an edge between these two
            return _edges.Contains(edge);
        }

        public override int Degree(T vertex)
        {
            return DegreeOut(vertex) + DegreeIn(vertex);
        }

        public override int DegreeOut(T vertex)
        {
            if (!_vertices.Contains(vertex)) throw new ArgumentException();
            return _edges.Count(edge => edge.Item1 != null && edge.Item1.Equals(vertex));
        }

        public override int DegreeIn(T vertex)
        {
            if (!_vertices.Contains(vertex)) throw new ArgumentException();
            return _edges.Count(edge => edge.Item2 != null && edge.Item2.Equals(vertex));
        }

        public override IEnumerable<T> AdjacentVertices(T vertex)
        {
            return _edges.Where(e => e.Item1.Equals(vertex)).Select(e => e.Item2);
        }

        public override IEnumerable<T> Vertices => _vertices.AsReadOnly();
        public override IEnumerable<Tuple<T, T>> Edges => _edges.AsReadOnly();
    }
}
