using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Vertex
    {
        
        public int Dato;
        public List<Vertex> children = new List<Vertex>();
        public List<Vertex> father = new List<Vertex>();
        public Vertex(Graph graph)
        {
            
            Dato = graph.VertexD;
            graph.VertexD++;
        }
    }
}
