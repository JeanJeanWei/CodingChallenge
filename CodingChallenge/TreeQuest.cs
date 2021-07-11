using System;
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
    }
}
