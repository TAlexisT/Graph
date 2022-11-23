using GraphPractice;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {

        Graph graph = new Graph();
        Vertex n0 = new Vertex(graph);
        Vertex n1 = new Vertex(graph);
        Vertex n2 = new Vertex(graph);
        Vertex n3 = new Vertex(graph);
        Vertex n4 = new Vertex(graph);
        Vertex n5 = new Vertex(graph);
        Vertex n6 = new Vertex(graph);

        Edge e1 = new Edge(n0, n1, 6);
        Edge e2 = new Edge(n0, n2, 7);
        Edge e3 = new Edge(n0, n3, 1);
        Edge e4 = new Edge(n2, n4, 2);
        Edge e5 = new Edge(n2, n5, 9);
        Edge e6 = new Edge(n1,n6,70);
        Edge e7 = new Edge(n4,n6,22);
        Edge e8 = new Edge(n5,n6,23);

        graph.CrearNodo(n0);
        graph.CrearNodo(n1);
        graph.CrearNodo(n2);
        graph.CrearNodo(n3);
        graph.CrearNodo(n4);
        graph.CrearNodo(n5);
        graph.CrearNodo(n6);

        graph.CrearEdge(e1);
        graph.CrearEdge(e2);
        graph.CrearEdge(e3);
        graph.CrearEdge(e4);
        graph.CrearEdge(e5);
        graph.CrearEdge(e6);
        graph.CrearEdge(e7);
        graph.CrearEdge(e8);

        //graph.EliminarNodo(n3);

        //graph.EliminarEdge(e6);

        graph.Connections();
        graph.Weight();
        
        graph.BFS(n0);
        graph.DFS(n0);
        graph.MasCorto(n0, n6);
    }
}
