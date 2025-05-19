



using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;

namespace DataStructuresAlgorithms.Trees;

public class TreeNode2
{
    public int val;
    public TreeNode2? left;
    public TreeNode2? right;
    public TreeNode2(int val = 0, TreeNode2 left = null, TreeNode2 right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class TreeSolutions
{
    public IList<int> InorderTraversal(TreeNode2 root)
    {

        var result = new List<int>();

        var stack = new Stack<TreeNode2>();

        var node = root;

        if (node == null)
        {
            return result;
        }


        while (node != null)
        {

            while (node.left != null)
            {
                stack.Push(node);
                node = node.left;
            }

            node = stack.Pop();
            result.Add(node.val);


            node = node.right;

        }

        return result;

    }

    public bool HasPathSum(TreeNode2 root, int targetSum)
    {
        var result = HelperPathSum(root, targetSum, 0);

        Console.WriteLine(result);

        return result;


    }


    private bool HelperPathSum(TreeNode2? node, int targetSum, int currentSum)
    {
        if (node == null)
        {
            return false;
        }

        if (node.left == null && node.right == null)
        {
            currentSum += node.val;
            return currentSum == targetSum;
        }

        currentSum += node.val;
        Console.WriteLine(node.val);
        Console.WriteLine($"Current sum: {currentSum}");

        bool left = HelperPathSum(node.left, targetSum, currentSum);


        bool right = HelperPathSum(node.right, targetSum, currentSum);


        Console.WriteLine("We are here");
        return left || right;



    }


    public int MinDepth(TreeNode2 root)
    {
        var result = HelperMinDepth(root, 0);
        Console.WriteLine(result);
        return result;

    }

    public int HelperMinDepth(TreeNode2? node, int currentSum)
    {
        if (node == null)
        {
            return int.MaxValue;
        }


        if (node.left == null && node.right == null)
        {
            return currentSum + 1;
        }

        currentSum += 1;

        var left = HelperMinDepth(node.left, currentSum);
        var right = HelperMinDepth(node.right, currentSum);

        return Math.Min(left, right);
    }

    public bool IsSameTree(TreeNode2 p, TreeNode2 q)
    {
        return HelperSameTree(p, q);


    }


    public bool HelperSameTree(TreeNode2? p, TreeNode2? q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (p == null || q == null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        return HelperSameTree(p.left, q.left) && HelperSameTree(p.right, q.right);


    }

    public bool IsSymmetric(TreeNode2 root)
    {

        var queue = new Queue<List<TreeNode2?>>();

        queue.Enqueue([root.left, root.right]);


        while (queue.Count > 0)
        {

            var current = queue.Dequeue();

            if (current[0] == null && current[1] == null)
            {
                continue;
            }

            if (current[0] == null || current[1] == null)
            {
                return false;
            }

            if (current[0].val != current[1].val)
            {
                return false;
            }

            queue.Enqueue([current[0].left, current[1].right]);
            queue.Enqueue([current[0].right, current[0].left]);








        }

        return true;

    }


    public List<int> SumOfAllNodes(TreeNode2 root)
    {
        var sums = new Dictionary<int, int>();
        int SumOfAllNodesHelper(TreeNode2? node)
        {
            if (node == null)
            {
                return 0;
            }
            if (node.left == null && node.right == null)
            {
                Console.WriteLine("node.val: " + node.val);
                sums[node.val] = sums.GetValueOrDefault(node.val, 0) + 1;

                return node.val;
            }

            var left = SumOfAllNodesHelper(node.left);

            var right = SumOfAllNodesHelper(node.right);


            var result = right + left + node.val;
            Console.WriteLine("The sum: " + result);
            sums[result] = sums.GetValueOrDefault(result, 0) + 1;


            return result;


        }
        SumOfAllNodesHelper(root);
        var maxNum = int.MinValue;

        foreach (var val in sums.Values)
        {
            if (val > maxNum)
            {
                maxNum = val;
            }
        }

        var list = new List<int>();

        foreach (var key in sums.Keys)
        {
            if (sums[key] == maxNum)
            {
                list.Add(key);
            }
        }

        Console.WriteLine(string.Join(",", list));
        return list;

    }

    // public IList<int> SumOfAllNodesHelper(TreeNode2? node,IList<int> sums)
    // {
    //     if (node == null)
    //     {
    //         return 0;
    //     }
    //     if (node.left == null && node.right == null)
    //     {
    //         return node.val;
    //     }

    //     var left = SumOfAllNodesHelper(node.left,sums);

    //     var right = SumOfAllNodesHelper(node.right,sums);


    //     sums.Add(right + left + node.val);
    //     return right + left + node.val;


    // }

    public int FindBottomLeftValue(TreeNode2 root)
    {
        if (root.left == null && root.right == null)

        {
            return root.val;
         }

        var dict = new Dictionary<int, int>();
        void Helper(TreeNode2? node, bool leftSide, int count)
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null)
            {

                if (dict.ContainsKey(node.val))
                {
                    dict[node.val] = Math.Max(dict[node.val], count);
                }
                else
                {
                    dict[node.val] = count;
                }

                return;

            }


            Helper(node.left, true, count += 1);

            Helper(node.right, false, count += 1);


        }

        Helper(root, false, 0);

        Console.WriteLine(string.Join("", dict));

        int max = int.MinValue;
        foreach (var pair in dict)
        {
            max = Math.Max(max, pair.Value);
        }
        Console.WriteLine(max);
        foreach (var pair in dict)
        {
            if (dict[pair.Key] == max)
            {
                Console.WriteLine("This is the pair: " + pair.Key);
                return pair.Key;
            }
        }


        return 1;

    }



}