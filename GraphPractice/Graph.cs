using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GraphPractice
{
	internal class Graph
	{

		public List<Vertex> ListVertex = new List<Vertex>();
		private List<Edge> ListEdges = new List<Edge>();

		public int VertexD=0;

		public int Cam = 0;

		public List<Vertex> NodoCorto = new List<Vertex>();

        public List<Edge> shortestPathC = new List<Edge>();
		public bool firstTime = true;

        public int[] ListCorto = new int[3];

        public void CrearNodo(Vertex node)
		{
			foreach (Vertex nodes in ListVertex)
            {
				if(node == nodes)
                {
					
					return;
                }
            }
			ListVertex.Add(node);
		}

		public void EliminarNodo(Vertex node)
		{
			for (int i = 0; i < ListVertex.Count; i++)
			{
				for (int k = 0; k < ListVertex[i].children.Count; k++)
				{
					if (ListVertex[i].children[k] == node)
					{
						ListVertex[i].children.RemoveAt(k);
					}
				}
			}
			for (int i = 0; i < ListVertex.Count; i++)
            {
				
				if (ListVertex[i] == node)
                {
					for (int k = 0; k > node.children.Count; k++)
					{
						ListVertex[i].children.RemoveAt(k);
                    }
					for (int k = 0; k<ListEdges.Count ;k++)
					{
						if (ListEdges[k].initialNode == node || ListEdges[k].finalNode == node )
						{
							ListEdges.RemoveAt(k);
						}
					}
					ListVertex.RemoveAt(i);
					return;
                }
            }
			
		}

		public void CrearEdge(Edge edge)
		{
			ListEdges.Add(edge);
		}

		public void EliminarEdge(Edge edge)
        {
			for (int i = 0; i < ListVertex.Count; i++)
			{
				if (edge.initialNode == ListVertex[i])
				{
					for (int k = 0; k<ListVertex[i].children.Count;k++)
					{
						if (edge.finalNode == ListVertex[i].children[k])
						{
							ListVertex[i].children.RemoveAt(k);
						}
					}
				}
			}
               
                for (int i = 0; i<ListEdges.Count;i++)
            {
                if (ListEdges[i]==edge)
                {
					ListEdges.RemoveAt(i);
					return;
				}
			}
			
        }

		public void Connections()
		{
			int zeroCounter = 0;

			
			Console.WriteLine("Connections\n");
			Console.Write("   ");
			foreach (Vertex node in ListVertex)
			{
				Console.Write(node.Dato + "  ");
			}
			Console.WriteLine();
			Console.Write("  ");
			foreach (Vertex node in ListVertex)
			{
				Console.Write("---");
			}
			Console.WriteLine();

			for (int i = 0; i < ListVertex.Count;i++)
			{
				Console.Write(ListVertex[i].Dato + "| ");

				
				for(int j = 0; j < ListVertex.Count; j++)
				{
					foreach(Edge edge in ListEdges)
					{
						if (edge.initialNode.Dato==ListVertex[i].Dato && edge.finalNode.Dato == ListVertex[j].Dato)
						{
							Console.Write(1 + "  ");
							zeroCounter = zeroCounter + 1;
						}
					}
                    if (zeroCounter <= 0)
                    {
						Console.Write(0 + "  ");
					}
                    else
                    {
						zeroCounter=zeroCounter-1;
                    }
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		public void Weight()
		{
			int zeroCounter = 0;

			
			Console.WriteLine("Edges Values\n");
			Console.Write("   ");
			foreach (Vertex node in ListVertex)
			{
				Console.Write(node.Dato + "  ");
			}
			Console.WriteLine();
			Console.Write("  ");
			foreach (Vertex node in ListVertex)
			{
				Console.Write("---");
			}
			Console.WriteLine();

			
			for (int i = 0; i < ListVertex.Count; i++)
			{
				Console.Write(ListVertex[i].Dato + "| ");
				for (int j = 0; j < ListVertex.Count; j++)
				{
					foreach (Edge edge in ListEdges)
					{
						if (edge.initialNode.Dato == ListVertex[i].Dato&& edge.finalNode.Dato == ListVertex[j].Dato)
						{
							Console.Write(edge.weight+"  ");
							zeroCounter = zeroCounter + 1;	
						}
					}
					if (zeroCounter <= 0)
					{
						Console.Write(0 + "  ");
					}
					else
					{
						zeroCounter = zeroCounter - 1;
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		public void BFS(Vertex node)
		{
			int[] values = new int[ListVertex.Count];

			values[0] = node.Dato;

			foreach (Vertex nodes in node.children)
			{
				BFS(nodes,values);
			}
            Console.Write("\n" + "Order BFS: (");
            for (int i = 0; i < values.Length; i++)
			{
				if (values.Length-1==i)
				{
					Console.Write(values[i]+")");
                }
				else
				{
					Console.Write(values[i] + ", ");
                }
				
			}
		}

		public void BFS(Vertex node, int[] values)
		{
			if (!values.Contains(node.Dato))
				{
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.Dato;
                        break;
                    }
                }
            }

			foreach (Vertex nodes in node.children)
			{
				BFS(nodes,values);
			}
		}

		public void DFS(Vertex node)
		{
            int[] values = new int[ListVertex.Count];

            foreach (Vertex nodes in node.children)
			{
				DFS(nodes,values);
			}

            if (!values.Contains(node.Dato))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.Dato;
                        break;
                    }
                }
            }

            Console.Write("\n" + "Order DFS: (");
            for (int i = 0; i < values.Length; i++)
            {
                if (values.Length - 1 == i)
                {
                    Console.Write(values[i] + ")");
                }
                else
                {
                    Console.Write(values[i] + ", ");
                }

            }
        }

		public void DFS(Vertex node, int[] values)
		{
            foreach (Vertex nodes in node.children)
            {
                DFS(nodes, values);
            }

            if (!values.Contains(node.Dato))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.Dato;
                        break;
                    }
                }
            }
        }
		
		public void MasCorto(Vertex initialNode, Vertex goal)
		{
			List <Edge> pathOfEdges = new List<Edge>();
			
			foreach (Edge edges in ListEdges)
			{
				if (edges.initialNode == initialNode)
				{
					pathOfEdges.Add(edges);

					foreach(Vertex nodeChildren in initialNode.children)
					{
						if (nodeChildren == edges.finalNode)
						{
                            MasCorto(nodeChildren, goal, pathOfEdges);
                        }
					}
					pathOfEdges.Remove(edges);

				}
			}
            Console.Write("\n"+"\n"+"Shortest way : (");
            for (int i = 0; i< ListCorto.Length; i++)
			{
				if (i == ListCorto.Length - 1)
				{
					Console.Write(ListCorto[i] + ")\n\n\n");
				}
				else
				{
					Console.Write(ListCorto[i] + ", ");
				}
                
            }
			
		}

		public void MasCorto(Vertex VertexChi, Vertex goal, List<Edge> pathOfEdges)
		{
			if (VertexChi == goal)
			{
				if (firstTime == true)
				{
					foreach (Edge edge in pathOfEdges)
					{
						for (int i = 0; i < ListCorto.Length; i++)
						{
							if (ListCorto[i] == 0)
							{
								ListCorto[i] = edge.weight;
								break;
							}
						}
					}
					
					firstTime = false;
				}
				else if(MasCorto_Cal(ListCorto) > MasCorto_Cal(pathOfEdges))
				{
					for (int j = 0; j < ListCorto.Length; j++)
					{
						if (ListCorto[j] != 0)
						{
							ListCorto[j] = 0;
						}

					}
                    foreach (Edge edge in pathOfEdges)
                    {
                        for (int i = 0; i < ListCorto.Length; i++)
                        {
                            if (ListCorto[i] == 0)
                            {
                                ListCorto[i] = edge.weight;
                                break;
                            }
                        }
                    }
                    
				}
				return;
			}

            foreach (Edge edges in ListEdges)
            {
                if (edges.initialNode == VertexChi)
                {
                    pathOfEdges.Add(edges);

                    foreach (Vertex nodeChildrens in VertexChi.children)
                    {
                        if (nodeChildrens == edges.finalNode)
                        {
                            MasCorto(nodeChildrens, goal, pathOfEdges);
                        }
                    }
                    pathOfEdges.Remove(edges);

                }
            }
        }

		public int MasCorto_Cal(List<Edge> path)
		{
			int pathResult = 0;
			foreach (Edge edge in path)
			{
				pathResult = edge.weight + pathResult;
			}
			return pathResult;
		}

		public int MasCorto_Cal(int[] path)
		{
			int pathResult = 0;
			for (int i = 0; i < path.Length; i++)
			{
				pathResult = path[i] + pathResult;
			}
			return pathResult;
		}
	}
}
