using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BST
    {
        public class TreeNode
        {
            public int value;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.value = val;
                this.left = left;
                this.right = right;
            }
        }

        

        public List<int> BFS(TreeNode node)
        {
            var list = new List<int>();
            Console.WriteLine("***BFS of Binary Tree***");
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                TreeNode currentNode = q.Dequeue();
                list.Add(currentNode.value);
                if (currentNode.left != null) q.Enqueue(currentNode.left);
                if (currentNode.right != null) q.Enqueue(currentNode.right);
            }
            return list;
        }
    }

}
