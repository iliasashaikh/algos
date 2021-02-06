using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algos
{
    public class Node : IEquatable<Node>
    {
        public string Value { get; set; }
        public List<Node> Children { get; set; }

        public Node(string value, params Node[] children)
        {
            this.Value = value;
            this.Children = children.ToList();
        }

        public void Visit()
        {
            Console.WriteLine($"Visited {Value}");
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node)obj);
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }

    public class Graph
    {
        private HashSet<Node> Nodes { get; set; } = new HashSet<Node>();

        public void AddEdge(Node u, Node v)
        {
            Nodes.Add(u);
            Nodes.Add(v);
            u?.Children.Add(v);
        }
    }

    public static class GraphAlgo
    {
        public static void Test()
        {
            var g = new Graph();
            /*
             * a=>b=>c
             * c=>a
             * d=>c
             */

            var a = new Node("a");
            var c = new Node("c");
            var d = new Node("d");
            var b = new Node("b");

            g.AddEdge(a, b);
            g.AddEdge(b, c);
            g.AddEdge(c, a);
            g.AddEdge(d, c);

            Bfs(g, a, c).Dump2();
            Bfs(g, a, d).Dump2();

            HashSet<Node> h = null;
            Dfs(g, a, c, ref h).Dump2();
            h = null;
            Dfs(g, a, d, ref h).Dump2();
        }

        public static bool Bfs(Graph g, Node start, Node end)
        {
            var q = new Queue<Node>();
            q.Enqueue(start);
            var visited = new HashSet<Node>();
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                foreach (var n in node.Children)
                {
                    if (visited.Contains(n))
                        break;

                    node.Visit();
                    visited.Add(n);
                    if (n.Equals(end))
                        return true;

                    q.Enqueue(n);
                }
            }

            return false;
        }

        public static bool Dfs(Graph g, Node start, Node end, ref HashSet<Node> visited)
        {
            visited ??= new HashSet<Node>();
            if (start == null || end == null)
                return false;


            start.Visit();
            visited.Add(start);

            if (start.Equals(end))
                return true;

            foreach (var n in start.Children)
            {
                if (!visited.Contains(n))
                    return Dfs(g, n, end, ref visited);
            }

            return false;
        }

        public static bool DfsR(Graph g, Node start, Node end)
        {
            throw new NotImplementedException();
        }
    }
}
