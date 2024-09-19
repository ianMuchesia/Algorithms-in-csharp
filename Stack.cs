public class Stack
{

    static readonly int MAX = 5000;

    int top;

    //declares an integer array named stack with a size of MAX (5000).
    int[] stack = new int[MAX];

    bool isEmpty()
    {
        return (top < 0);
    }

    public Stack()
    {
        top = -1;
    }

    internal bool Push(int data)
    {
        if (top >= MAX)
        {
            Console.WriteLine("Stack Overflow");
            return false;
        }
        else
        {
            stack[++top] = data;
            return true;
        }
    }

    internal int Pop()
    {
        if (isEmpty())
        {
            Console.WriteLine("Stack underflow");
            return 0;
        }
        else
        {
            int value = stack[top--];
            return value;
        }
    }

    internal void Peek()
    {
        if(isEmpty())
        {
            Console.WriteLine("Stack Underflow");
            
        }
        else{
            Console.WriteLine("The top most element of the stack is : {0}", stack[top]);
        }
    }


    internal void PrintStack()
    {
        if(top < 0)
        {
            Console.WriteLine("Stack Underflow");
            return;
        }
        else
        {
            Console.WriteLine("The element in the stack are :" );
            for( int i = top; i>=0; i--)
            {
                Console.WriteLine(stack[i]);
            }
        }
    }
}