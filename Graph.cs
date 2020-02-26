using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Graph
    {
        private int[,] _graph;
        private int _size;
        bool _visited 
        public Graph(int size)
        {
            this._size = size;
            _graph = new int[size, size];
        }
        public void AddEdge(int src, int dst, int weight = 1, bool directed = true)
        {
            _graph[src, dst] = weight;
            if(!directed)
            {
                _graph[dst, src] = weight;
            }
        }
        public void RemoveEdge(int src, int dst, bool directed = true)
        {
            _graph[src, dst] = 0;
            if (!directed)
            {
                _graph[dst, src] = 0;
            }
        }
        public bool IsEdge(int src, int dst)
        {
            return _graph[src, dst] != 0;
        }
        public int[] GetEdges(int src)
        {
            int count = 0;
            for (int i = 0; i < _size; i++)
            {
                count += IsEdge(src, i) ? 1 : 0;
            }
            int[] res = new int[count];
            count = 0;
            for (int i = 0; i < _size; i++)
            {
                if(IsEdge(src, i))
                {
                    res[count] = i;
                    count++;
                }
            }
            return res;
        }
        public int GetSize() { return this._size; }
        
    }
}
