// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using GraphLibrary;

Console.WriteLine("Hello, World!");


var t = new Tuple<int, int>(1, 2);

var p = new Tuple<int, int>(1, 3);


if (!t.Equals(p))
{
    Console.WriteLine("It works!");
}


IEnumerable<int> Range(int start, int end)
{
    var list = new List<int>();
    for (var i = start; i <= end; i++)
    {
        list.Add(i);
    }

    return list;
}

var graph = new DirectedGraph<int>();

graph.AddVertex(Range(0, 15));


var tuples = new List<Tuple<int, int>>
{
    new(0, 3),
    new(0, 4),
    new(0, 5),
    new(2, 1),
    new(3, 5),
    new(5, 9)
};

graph.AddEdge(tuples);

void DisplayAdjacent(int vertex, DirectedGraph<int> graph)
{
    foreach (var v in graph.AdjacentVertices(vertex))
    {
        Console.WriteLine($"{vertex} => {v}");
    }
}


foreach (var v in graph.Vertices)
{
    Console.WriteLine($"Adjacent vertices for {v}");
    DisplayAdjacent(v, graph);
}

Console.Write($"Vertex\t\t\tOut Degrees\t\tIn Degrees\n");
foreach (var v in graph.Vertices)
{
    Console.Write($"{v}\t\t\t{graph.DegreeOut(v)}\t\t\t{graph.DegreeIn(v)}\n");
}