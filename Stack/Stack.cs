



using System.Globalization;

namespace DataStructuresAlgorithms.Stack
{
    public class Stack
    {

        public bool IsValid(string s)
        {

            var myDict = new Dictionary<char, char>
            {
                {'(',')'},
                {'{','}'},
                {'[',']'}
            };

            var stack = new List<char>();


            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("The character is: " + s[i]);
                if (myDict.ContainsKey(s[i]))
                {
                    stack.Add(s[i]);
                    Console.WriteLine("The total length of stack is: " + stack.Count);
                }
                else
                {
                    var lastIndex = stack.Count - 1;
                    Console.WriteLine("this is the last index " + lastIndex);
                    if (myDict[stack[lastIndex]] == s[i])
                    {
                        stack.RemoveAt(lastIndex);
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            return true;

        }

        public bool BackspaceCompare(string s, string t)
        {

            var stack1 = new List<char>();
            var stack2 = new List<char>();

            var length = Math.Max(s.Length, t.Length);
            Console.WriteLine(length);

            var right = 0;

            while (right < length)
            {
                Console.WriteLine("I am here");
                if (right == 0)
                {
                    if (s[right] != '#')
                    {
                        stack1.Add(s[right]);

                    }
                    if (t[right] != '#')
                    {
                        stack2.Add(t[right]);

                    }

                    right++;
                    continue;

                }
                Console.WriteLine("stack 1 content: " + string.Join(",", stack1));
                Console.WriteLine("stack 2 content: " + string.Join(",", stack2));

                if (s.Length > right && s[right] == '#' && stack1.Count > 0)
                {
                    stack1.RemoveAt(stack1.Count - 1);
                }
                else if (s.Length > right && s[right] != '#')
                {
                    stack1.Add(s[right]);
                }


                if (t.Length > right && t[right] == '#' && stack2.Count > 0)
                {
                    stack2.RemoveAt(stack2.Count - 1);
                }
                else if (t.Length > right && t[right] != '#')
                {
                    stack2.Add(t[right]);
                }


                right++;
            }
            Console.WriteLine("stack 1 content: " + string.Join(",", stack1));
            Console.WriteLine("stack 2 content: " + string.Join(",", stack2));


            if (stack1.Count != stack2.Count) return false;

            for (int i = 0; i < stack1.Count; i++)
            {
                if (stack1[i] != stack2[i])
                {
                    return false;
                }
            }

            return true;




        }
        public bool BackspaceCompare2(string s, string t)
        {
            //using to pointer
            int sLength = s.Length - 1;
            int tLength = t.Length - 1;

            int skipS = 0;
            int skipT = 0;


            while (sLength >= 0 || tLength >= 0)
            {
                //process bakcspace in s
                while (sLength >= 0)
                {
                    if (s[sLength] == '#')
                    {
                        skipS++;
                        sLength--;
                        //increase backspace count
                    }
                    else if (skipS > 0)
                    {
                        skipS--;
                        sLength--;
                        //skip the character
                    }
                    else
                    {
                        break; //valid character found
                    }

                }


                //process backspace in t
                while (tLength >= 0)
                {
                    if (t[tLength] == '#')
                    {
                        skipT++;
                        tLength--;
                    }
                    else if (skipT > 0)
                    {
                        skipT--;
                        tLength--;
                        //skip the character
                    }
                    else
                    {
                        break; //valid character found
                    }


                }
                // Compare current valid characters
                if (sLength >= 0 && tLength >= 0 && s[sLength] != t[tLength])
                {
                    return false;
                }

                //if one string is finished but the othre s still has charcters
                if ((sLength >= 0) != (tLength >= 0)) return false;


                sLength--;
                tLength--;
            }

            return true;




        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            //brute force

            var result = new int[temperatures.Length];

            var fast = 1;
            var slow = 0;


            while (slow < temperatures.Length)
            {
                while (fast < temperatures.Length && temperatures[fast] <= temperatures[slow])
                {
                    Console.WriteLine(temperatures[fast]);
                    fast++;
                }



                var difference = 0;

                if (fast < temperatures.Length)
                {
                    difference = fast - slow;
                }

                result[slow] = difference;

                slow++;
                fast = slow + 1;
            }
            Console.WriteLine(string.Join(",", result));


            return result;



        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];

            var stack = new List<int>();

            for(int i=0;i<temperatures.Length;i++)
            {
                while(stack.Count > 0 && temperatures[i] > stack[stack.Count-1])
                {
                    var tempStack = stack[stack.Count - 1];
                    
                }
            }

        }




    }


    public class MinStack
    {

        private IList<int> list;


        private IList<int> minStack;

        public MinStack()
        {
            list = new List<int>();

            minStack = new List<int>();

        }

        public void Push(int val)
        {
            list.Add(val);

            if (minStack.Count == 0 || val <= minStackPeek())
            {
                minStack.Add(val);
            }
            else
            {
                minStack.Add(minStackPeek());
            }

            Console.WriteLine("The array is now: " + string.Join(",", list));
        }

        private int minStackPeek()
        {
            return minStack[minStack.Count - 1];

        }

        public void Pop()
        {
            if (list.Count < 1) return;
            var lastIndex = list.Count - 1;
            var poppedNumber = list[lastIndex];
            Console.WriteLine("Popped number is: " + poppedNumber);

            list.RemoveAt(lastIndex);
            minStack.RemoveAt(lastIndex);





        }

        public int Top()
        {
            var lastIndex = list.Count - 1;
            Console.WriteLine("The value at the top is :" + list[lastIndex]);
            return list[lastIndex];
        }

        public int GetMin()
        {

            return minStackPeek();
        }
    }



    //implement queue using stacks
    public class MyQueue
    {
        private IList<int> inputStack;

        private IList<int> outputStack;

        public MyQueue()
        {
            inputStack = new List<int>();

            outputStack = new List<int>();

        }

        public void Push(int x)
        {
            inputStack.Add(x);

        }

        public int Pop()
        {
            if (outputStack.Count == 0)
            {
                var right = inputStack.Count - 1;

                while (right >= 0)
                {

                    outputStack.Add(inputStack[right]);
                    inputStack.RemoveAt(right);
                    right--;
                }
            }

            var popedItem = outputStack[outputStack.Count - 1];
            outputStack.RemoveAt(outputStack.Count - 1);
            return popedItem;

        }

        public int Peek()
        {
            if (outputStack.Count == 0)
            {
                var right = inputStack.Count - 1;

                while (right >= 0)
                {
                    outputStack.Add(inputStack[right]);
                    inputStack.RemoveAt(right);

                    right--;
                }
            }

            return outputStack[outputStack.Count - 1];


        }

        public bool Empty()
        {
            return inputStack.Count == 0 && outputStack.Count == 0;
        }
    }

}