﻿using System;
using System.Collections.Generic;

namespace CodePractice
{
    public class Graph<T>
    {
        public Graph() { }
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            AdjacencyList = new Dictionary<T, HashSet<T>>();
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public Dictionary<T, HashSet<T>> AdjacencyList { get; set; }

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        public static class GraphAlgorithms
        {
            public static HashSet<T> DFS<T>(Graph<T> graph, T start)
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var stack = new Stack<T>();
                stack.Push(start);

                while (stack.Count > 0)
                {
                    var vertex = stack.Pop();

                    if (visited.Contains(vertex))
                        continue;

                    visited.Add(vertex);

                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor))
                            stack.Push(neighbor);
                }

                return visited;
            }

            public static HashSet<T> BFS<T>(Graph<T> graph, T start)
            {
                var visited = new HashSet<T>();

                if (!graph.AdjacencyList.ContainsKey(start))
                    return visited;

                var queue = new Queue<T>();
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    var vertex = queue.Dequeue();

                    if (visited.Contains(vertex))
                        continue;

                    visited.Add(vertex);

                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor))
                            queue.Enqueue(neighbor);
                }

                return visited;
            }
        }

        public class DirectedGraph
        {
            public int V;

            public HashSet<int>[] AdjacencyList;

            public DirectedGraph(int v)
            {
                V = v;
                AdjacencyList = new HashSet<int>[v];
                for (int i = 0; i < v; i++)
                    AdjacencyList[i] = new HashSet<int>();
            }

            public void AddEdge(int u, int v)
            {
                AdjacencyList[u].Add(v);
            }

            public void TopologicalSort()
            {
                bool[] visited = new bool[V];
                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < V; i++)
                {
                    if (visited[i] == false)
                        TopologicalSortUtil(i, visited, stack);
                }

                while (stack.Count != 0)
                {
                    Console.Write(stack.Pop() + "  ");
                }
            }

            private void TopologicalSortUtil(int i, bool[] visited, Stack<int> stack)
            {
                visited[i] = true;

                foreach (int v in AdjacencyList[i])
                {
                    if (!visited[v])
                        TopologicalSortUtil(v, visited, stack);
                }

                stack.Push(i);
            }
        }

        public class GraphExt
        {
            public static void Execute()
            {
                var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};
                Tuple<int, int>[] edg1 = new Tuple<int, int>[2];

                var graph = new Graph<int>(vertices, edges);

                Console.WriteLine(string.Join(", ", GraphAlgorithms.DFS(graph, 2)));

                Console.WriteLine(string.Join(", ", GraphAlgorithms.BFS(graph, 2)));
            }

            public static void ExecuteDirectedGraph()
            {
                DirectedGraph graph = new DirectedGraph(6);
                graph.AddEdge(5, 2);
                graph.AddEdge(5, 0);
                graph.AddEdge(4, 0);
                graph.AddEdge(4, 1);
                graph.AddEdge(2, 3);
                graph.AddEdge(3, 1);
                graph.TopologicalSort();
            }
        }
    }
