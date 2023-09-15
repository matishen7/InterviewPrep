using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleApp1.BST;

namespace ConsoleApp1
{
    internal class BinaryTreeProblems
    {
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            return Invert(root);
        }

        internal static TreeNode Invert(TreeNode root)
        {
            if (root == null) return root;

            var temp = root.right;
            root.right = root.left;
            root.left = temp;

            Invert(root.right);
            Invert(root.left);

            return root;
        }

        public static bool isBalanced(TreeNode root)
        {
            if (root == null) return true;
            return Balanced(root);
        }

        private static bool Balanced(TreeNode root)
        {
            int lh = MaxHeight(root.left);
            int rh = MaxHeight(root.right);
            if (Math.Abs(lh - rh) <= 1 && Balanced(root.left) && Balanced(root.right)) return true;
            return false;
        }

        private static int MaxHeight(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(MaxHeight(root.left), MaxHeight(root.right));
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return SameTreeDFS(p, q);
        }

        public static bool SameTreeDFS(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null && q != null) return false;
            if (p != null && q == null) return false;

            if (p.value != q.value) return false;
            if (SameTreeDFS(p.left, q.left) && SameTreeDFS(p.right, q.right))
                return true;
            return false;
        }

        public static IList<IList<int>> LevelOrder(TreeNode node)
        {

            var answer = new List<IList<int>>();
            if (node == null) return answer;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                var currentLevelValues = new List<int>();
                int count = 0;
                int level = q.Count;
                while (count < level)
                {
                    TreeNode currentNode = q.Dequeue();
                    currentLevelValues.Add(currentNode.value);
                    count++;
                    if (currentNode.left != null) q.Enqueue(currentNode.left);
                    if (currentNode.right != null) q.Enqueue(currentNode.right);
                }

                answer.Add(currentLevelValues);
            }
            return answer;
        }
    }
}
