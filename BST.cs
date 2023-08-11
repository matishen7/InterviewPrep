using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BST
    {
        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
            public Node(int val = 0, Node left = null, Node right = null)
            {
                this.value = val;
                this.left = left;
                this.right = right;
            }
        }

        

        public List<int> BFS(Node node)
        {
            var list = new List<int>();
            Console.WriteLine("***BFS of Binary Tree***");
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                Node currentNode = q.Dequeue();
                list.Add(currentNode.value);
                if (currentNode.left != null) q.Enqueue(currentNode.left);
                if (currentNode.right != null) q.Enqueue(currentNode.right);
            }
            return list;
        }
    }

}
