using System;
using System.Collections.Generic;

namespace Graphs
{

    public struct result <T1,T2>
    {
        public result(T1 a, T2 b )
        {
            this.a = a;
            this.b = b;
        }
        T1 a;
        T2 b;
        public T1 getA()
        {
            return a;
        }
        public T2 getB()
        {
            return b;
        }
        public void setA( T1 a)
        {
            this.a = a;
        }
        public void setB( T2 b)
        {
            this.b = b;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
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

            Graph G2 = new Graph(7);
            G2.AddEdge(0, 1, 3, true);
            G2.AddEdge(0, 2, 4, true);
            G2.AddEdge(1, 3, 7, true);
            G2.AddEdge(1, 4, 6, true);
            G2.AddEdge(2, 4, 2, true);
            G2.AddEdge(3, 6, 12, true);
            G2.AddEdge(3, 5, 9, true);
            G2.AddEdge(4, 5, 5, true);
            G2.AddEdge(1, 6, 20, true);
            result<int[], int[]> res;
            res = DijkstraAlgorithm(G2, 0);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(i + ", " + res.getA()[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(i + ", " + res.getB()[i]);
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
        public static result<int[], int[]> DijkstraAlgorithm (Graph G, int source)
        {
            int size = G.GetSize();
            
            List<int> S = new List<int>();
            int[] dist = new int[size];
            int[] prev = new int[size];
            int u = source;
            for (int i = 0; i < size; i++)
            {
                dist[i] = int.MaxValue;
                prev[i] = -1;
                S.Add(i);
            }
            dist[source] = 0;
            while (S.Count !=0)
            {
                int[] edges = new int[size];
                int min = int.MaxValue;
                if (!S.Contains(u))
                {
                    for (int i = 0; i < edges.Length; i++)
                    {
                        if (G.GetWeight(u, i) < G.GetWeight(u, min) && G.GetWeight(u, i) != 0 && S.Contains(i))
                        {
                            min = i;
                        }
                    }
                }
                else
                {
                    min = 0;
                }
                u = min;
                S.Remove(u);
                int alt;
                for (int i = 0; i < size; i++)
                {
                    if (G.IsEdge(u,i))
                    {
                        alt = dist[u] + G.GetWeight(u, i);
                        if (alt < dist[i])
                        {
                            dist[i] = alt;
                            prev[i] = u;
                        }
                    }
                }
            }
            return new result <int[], int[]> (dist,prev);
        }
    }
}

/*
 1  function Dijkstra(Graph, source):
 2
 3      create vertex set Q
 4
 5      for each vertex v in Graph:
 6          dist[v] ← INFINITY
 7          prev[v] ← UNDEFINED
 8          add v to Q
10      dist[source] ← 0
11
12      while Q is not empty:
13          u ← vertex in Q with min dist[u]
14
15          remove u from Q 
16
17          for each neighbor v of u:           // only v that are still in Q
18              alt ← dist[u] + length(u, v)
19              if alt < dist[v]:
20                  dist[v] ← alt 
21                  prev[v] ← u 
22
23      return dist[], prev[]
 */

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









