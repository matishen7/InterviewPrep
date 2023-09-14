using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class CloneGraphSolution
    {
        //public static Node CloneGraph(Node node)
        //{
        //    var currentNode = node;
        //    Node nodeSoFar = null;
        //    while (currentNode != null)
        //    {

        //    }
        //}
    }
}
