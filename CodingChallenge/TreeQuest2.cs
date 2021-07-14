using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.DataModel;

namespace CodingChallenge
{
    public class TreeQuest2
    {
        public TreeQuest2()
        {
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var currentNode = root;

            while (currentNode != null || stack.Count != 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                if (stack.Count != 0)
                {
                    currentNode = stack.Pop();
                    result.Add(currentNode.val);
                    currentNode = currentNode.right;
                }
            }

            return result;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            var res = new List<IList<int>>();

            if (root == null)
                return res;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;
                var row = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    row.Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }

                }

                res.Add(row);
            }

            return res;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            int level = 0;
            while (q.Count > 0)
            {
                int count = q.Count();
                int[] l = new int[count];

                for (int i = 0; i < count; i++)
                {
                    var node = q.Dequeue();
                    if (level % 2 == 1)
                    {
                        l[count - i - 1] = (node.val);
                    }
                    else
                    {
                        l[i] = (node.val);
                    }
                    //Console.WriteLine("count-i-1:" + (count-i-1) + " val:" + node.val);

                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                        // Console.WriteLine("i:" + i + "left val:" + node.left.val);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                        //Console.WriteLine("i:" + i + "right val:" + node.right.val);
                    }
                }
                level++;
                res.Add(l.ToList());
            }
            return res;
        }

     }
}
