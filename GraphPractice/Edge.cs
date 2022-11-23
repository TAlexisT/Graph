using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice
{
    internal class Edge
    {
 
        public Vertex initialNode;
        public Vertex finalNode;
        public int weight;
        public Edge(Vertex initialNode, Vertex finalNode, int weight)
        {
            if (initialNode.Dato == finalNode.Dato)
            {
                
                return;
            }
            this.initialNode = initialNode;
            this.finalNode = finalNode;
            this.weight = weight;

            this.initialNode.children.Add(finalNode);
            this.finalNode.father.Add(initialNode);
        }
    }
}
