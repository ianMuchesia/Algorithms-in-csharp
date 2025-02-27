




namespace DataStructuresAlgorithms.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {

        
        public void ReorderList(ListNode head)
        {

            var stack = new List<ListNode>();

            var node = head;
            while(node != null)
            {
                stack.Add(head);
                node = node.next;
            }

            stack[^1].next = head.next;
            head.next = stack[^1];



            stack.RemoveAt(stack.Count - 1);

            stack[^1].next = null;

            while(head != null)
            {
                Console.WriteLine(head.val);
            }



        }
    }
}