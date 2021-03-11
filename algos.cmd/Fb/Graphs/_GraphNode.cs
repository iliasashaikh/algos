using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Fb
{
    public class GraphNode
    {
        public int val;
        public IList<GraphNode> neighbors;

        public GraphNode()
        {
            val = 0;
            Neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val)
        {
            val = _val;
            Neighbors = new List<GraphNode>();
        }

        public GraphNode(int _val, List<GraphNode> _neighbors)
        {
            val = _val;
            Neighbors = _neighbors;
        }

        public IList<GraphNode> Neighbors { get => neighbors; set => neighbors = value; }
        public int Val { get => val; set => val = value; }
    }
}
