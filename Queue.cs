

using System.Diagnostics;

public class Queue
{

    static readonly int MAX = 5000;

    int rear;


    int[] queue = new int[MAX];

    bool isEmpty()
    {
        return (rear < 0);
    }

    public Queue()
    {
        rear = -1;
    }

    internal bool Enqueue(int data)
    {
        if(rear >= MAX)
        {
            Console.WriteLine("Stack Overflow");
            return false;
        }
        else
        {
            queue[++rear] = data;
            return true;
        }
    }


   // internal int Dequeue
}