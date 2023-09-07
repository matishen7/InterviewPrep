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
    }
}
