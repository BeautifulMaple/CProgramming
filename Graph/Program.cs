using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Graph
    {
        private int V;
        private List<int>[] list;

        public Graph(int v) 
        { 
            V = v;
            list = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                list[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            list[v].Add(w);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 5);
        }
    }
}
