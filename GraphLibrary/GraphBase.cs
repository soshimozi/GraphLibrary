using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    public abstract class GraphBase<T> : IGraph<T>
    {
        protected readonly  List<T> _vertices = new();
        protected readonly List<Tuple<T, T>> _edges = new();
        protected readonly Dictionary<int, string> labels = new();

        public bool AddVertex(T vertex)
        {
            if(vertex == null)
                throw new ArgumentNullException(nameof(vertex));

            if (_vertices.Contains(vertex))
            {
                return false;
            }

            _vertices.Add(vertex);
            return true;
        }

        public void AddVertex(IEnumerable<T> vertices)
        {
            if(vertices == null) throw new ArgumentNullException(nameof(vertices));

            _vertices.AddRange(vertices);
            
        }

        public bool RemoveVertex(T vertex)
        {
            if(vertex == null) throw new ArgumentNullException(nameof(vertex));

            if (!_vertices.Contains(vertex))
            {
                return false;
            }

            _vertices.Remove(vertex);
            return true;
        }

        public void RemoveVertex(IEnumerable<T> vertices)
        {
            if(vertices == null) throw new ArgumentNullException(nameof(vertices));
            foreach (var vertex in vertices)
            {
                if (_vertices.Contains(vertex))
                    _vertices.Remove(vertex);
            }
        }

        public abstract bool AddEdge(T v1, T v2);
        public abstract void AddEdge(IEnumerable<Tuple<T, T>> edges);
        public abstract void RemoveEdge(T v1, T v2);
        public abstract bool IsAdjacent(T v1, T v2);
        public abstract int Degree(T vertex);
        public abstract int DegreeOut(T vertex);
        public abstract int DegreeIn(T vertex);
        public abstract IEnumerable<T> AdjacentVertices(T vertex);
        public abstract IEnumerable<T> Vertices { get; }
        public abstract IEnumerable<Tuple<T, T>> Edges { get; }
    }
}
