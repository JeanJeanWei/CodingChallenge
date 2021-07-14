using System;
using System.Collections.Generic;
using CodingChallenge.DataModel;

namespace CodingChallenge
{
    public class TreeQuest
    {
        public TreeQuest()
        {
        }

        public int MaxDepth(TreeNode root)
        {

            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }

            int left = MaxDepth(root.left);
            int right = MaxDepth(root.right);

            return left >= right ? left + 1 : right + 1;
        }

        public IList<int> RightSideView(TreeNode root)
        {

            List<int> rightList = new List<int>();
            if (root == null)
                return rightList;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                // number of nodes at current level 
                int n = queue.Count;

                // Traverse all nodes of current level 
                for (int i = 0; i < n; i++)
                {
                    TreeNode temp = queue.Dequeue();

                    // Print the right most element at 
                    // the level 
                    if (i + 1 == n)
                    {
                        rightList.Add(temp.val);
                    }

                    // Add left node to queue 
                    if (temp.left != null)
                        queue.Enqueue(temp.left);

                    // Add right node to queue 
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }
            }
            return rightList;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return DFS(root.left, root.right);
        }

        private bool DFS(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            if (left.val == right.val)
            {
                return DFS(left.left, right.right) && DFS(left.right, right.left);
            }
            return false;
        }

        public bool IsValidBST(TreeNode root)
        {
            return DFS(root, long.MinValue, long.MaxValue);
        }

        private bool DFS(TreeNode root, long min, long max)
        {
            if (root == null)
            {
                //Console.WriteLine("root = null");
                return true;
            }
            if (min < root.val && root.val < max)
            {
                var leftResult = DFS(root.left, min, root.val);
                var rightResult = DFS(root.right, root.val, max);
                // Console.WriteLine("min: " + min + " max: " + max);
                if (leftResult && rightResult)
                {
                    //Console.WriteLine("left && Right = true");
                    return true;
                }
            }
            // Console.WriteLine("return false");
            return false;
        }
     }
 }
