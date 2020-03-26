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
            int[] minDist = new int[size];
            for (int i = 0; i < minDist.Length; i++)
            {
                minDist[i] = int.MaxValue;
            }
            int[] dist = new int[size];
            int[] prev = new int[size];
            int u = source;
            for (int i = 0; i < size; i++)
            {
                if (G.IsEdge(u, i) && !S.Contains(i))
                {
                    dist[i] = G.GetWeight(u, i);
                    minDist[i] = dist[i];
                }
                else
                {
                    dist[i] = int.MaxValue;
                }
                prev[i] = u;
                S.Add(i);
            }
            dist[source] = 0;
            while (S.Count !=0)
            {
                int min = int.MaxValue, v, alt;
                for (int i = 0; i < dist.Length; i++)
                {
                    if (min > dist[i])
                    {
                        u = dist[i];
                    }
                }
                int[] edges = G.GetEdges(u);
                S.Remove(u);

                for (int i = 0; i < edges.Length; i++)
                {
                    v = edges[i];
                    alt = dist[v] + G.GetWeight(u, v);
                    if (alt < minDist[v])
                    {
                        minDist[v] = alt;
                        prev[v] = u;
                    }
                }
            }
            return new result <int[], int[]> (minDist,prev);
        }
    }
}

