using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Graph G = new Graph(6);
            G.AddEdge(0, 1, 1, false);
            G.AddEdge(0, 3, 1, false);
            G.AddEdge(0, 4, 1, false);
            G.AddEdge(1, 2, 1, false);
            G.AddEdge(2, 3, 1, false);
            G.AddEdge(4, 5, 1, false);

            int [] arr = BFSAlgorithm(G, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(i + ", " + arr[i]);
            }
            Console.ReadLine();
        }

        public static int[] BFSAlgorithm(Graph G, int source)
        {
            Queue<int> Q = new Queue<int>();
            Queue<int> Discovered = new Queue<int>();
            int size = G.GetSize();
            int[] parants = new int[size];
            int v = source;
            Discovered.Enqueue(source);
            Q.Enqueue(source);
            while( Q.Count != 0)
            {
                v = Q.Dequeue();
                for (int i = 0; i < size; i++)
                {
                    if (G.IsEdge(v, i) && !Discovered.Contains(i))
                    {
                        Discovered.Enqueue(i);
                        parants[i] = v;
                        Q.Enqueue(i);
                    }
                }
            }
            return parants;
        }
    }
}
/*
1  procedure BFS(G, start_v) is
2      let Q be a queue
3      label start_v as discovered
4      Q.enqueue(start_v)
5      while Q is not empty do
6          v := Q.dequeue()
7          if v is the goal then
8              return v
9          for all edges from v to w in G.adjacentEdges(v) do
10             if w is not labeled as discovered then
11                 label w as discovered
12                 w.parent := v
13                 Q.enqueue(w)
 */
