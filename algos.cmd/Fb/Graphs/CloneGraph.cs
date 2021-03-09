using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb.Graphs
{
    [TestFixture]
    public class CloneGraph
    {
        Dictionary<GraphNode,GraphNode> _visited = new Dictionary<GraphNode, GraphNode>();
        public GraphNode Clone(GraphNode node)
        {
            if (node == null)
                return null;

            if (!_visited.TryGetValue(node, out var clone))
            {
                clone = new GraphNode(node.val, new List<GraphNode>(node.neighbors.Count));
                _visited[node] = clone;
                foreach (var n in node.neighbors)
                {
                    clone.neighbors.Add(Clone(n));
                }
            }

            return clone;
        }
        
    }
}
