
using System.Security.Cryptography;

namespace DataStructuresAlgorithms.Trees;

public class BfsNode
{
    public int val;
    public BfsNode left;
    public BfsNode right;
    public BfsNode next;

    public BfsNode() { }

    public BfsNode(int _val)
    {
        val = _val;
    }

    public BfsNode(int _val, BfsNode _left, BfsNode _right, BfsNode _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class BfsSolution {
    public BfsNode Connect(BfsNode root)
    {

        if (root == null)
        {
            return new BfsNode();
        }

        var queue = new Queue<BfsNode>();

        queue.Enqueue(root);


        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var midpoint = levelSize / 2;

            var currentList = new List<BfsNode>();



            for (int i = 0; i < levelSize; i++)
            {

                var current = queue.Dequeue();



                if (current.left != null)
                {
                    queue.Enqueue(current.left);

                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
                currentList.Add(current);
            }

            if (midpoint >= 1)
            {
                currentList[midpoint - 1].next = currentList[midpoint];
            }


        }

        return root;
        
    }
}