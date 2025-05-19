
namespace DataStructuresAlgorithms.Trees;

class TreeNode
{
    
   public TreeNode? Left;

   public TreeNode? Right;

   public int Value;

   public TreeNode(int Val)
   {
      Left = null;
      Right=null;
      Value = Val;
   }

    
}


class BinarySearchTree
{
   public TreeNode? Root;

   public BinarySearchTree()
   {
      Root = null;
   }


   public bool IsEmpty()
   {
      return Root == null;
   }


   public void Insert(int value)
   {
      var newNode = new TreeNode(value);

      if(Root == null) 
      {
         Root = newNode;
      }
      else
      {
         InsertNode(Root,newNode);
      }
   }

   //insert node;
   public static void InsertNode(TreeNode root,TreeNode newNode)
   {

      if(newNode == null) return;

      if(newNode.Value < root.Value)
      {
         if(root.Left == null)
         {
            root.Left = newNode;
         }
         else
         {
                InsertNode(root.Left,newNode);
         }
      }
      else
      {
         if(root.Right == null)
         {
            root.Right = newNode;
         }
         else
         {
                InsertNode(root.Right,newNode);
         }
      }

   }

   public static bool SearchNode(TreeNode? root,int value)
   {
      if(root == null)
      {
         Console.WriteLine("The value does not exist in the tree");
         return false;
      }

      else
      {
         if(root.Value == value)
         {
            return true;
         }
         else if(value < root.Value)
         {
            return SearchNode(root.Left, value);
         }
         else
         {
            return SearchNode(root.Right,value);
         }
      }
   }

   public static void PreOrder(TreeNode? root)
   {
      if(root != null)
      {
         Console.WriteLine(root.Value);
         PreOrder(root.Left);
         PreOrder(root.Right);

      }
   }

   public static void InOrder(TreeNode? root)
   {
      if(root != null)
      {
         InOrder(root.Left);
         Console.WriteLine(root.Value);
         InOrder(root.Right);
      }
   }


   public static void PostOrder(TreeNode? root)
   {
      if(root != null)
      {
         PostOrder(root.Left);
         PostOrder(root.Right);
         Console.WriteLine(root.Value);
      }
   }


   public  void LevelOrder()
   {
      var queue = new Queue<TreeNode?>();

        queue.Enqueue(Root);
     

      while(queue.Count > 0)
      {
         var current = queue.Dequeue();

         Console.WriteLine(current?.Value);

         if(current?.Left != null)
         {
            queue.Enqueue(current.Left);
         }

         if(current?.Right != null)
         {
            queue.Enqueue(current.Right);
         }
      }

      
   }
}

