using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            else if (p == null && q != null) return false;
            else if (p != null && q == null) return false;

            else if ( p.value != q.value) return false;
            SameTreeDFS(p.left, q.left);
            SameTreeDFS(p.right, q.right);
            return true;
        }
    }
}
