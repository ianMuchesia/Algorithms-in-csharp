using System.Collections;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Transactions;

namespace DataStructuresAlgorithms.Stack
{
    public class StackSolution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {

            var stack = new Stack<int>();

            var right = 0;

            var left = 0;

            while (left < pushed.Length)
            {
                stack.Push(pushed[left]);

                while (stack.Count > 0 && right < popped.Length && stack.Peek() == popped[right])
                {
                    Console.WriteLine(stack.Pop());
                    Console.WriteLine(string.Join(",", stack));
                    if (stack.Count > 0) Console.WriteLine("top of the stack is: " + stack.Peek());
                    right++;
                    if (right < popped.Length) Console.WriteLine("popped right is: " + popped[right]);
                    Console.WriteLine("Hey");
                }
                left++;
            }
            return stack.Count == 0;

        }

        public string DecodeString2(string s)
        {
            var stack = new List<char>();



            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != ']')
                {
                    stack.Add(s[i]);
                    Console.WriteLine(string.Join("", stack));
                }
                else
                {
                    var substirng = new StringBuilder();

                    while (stack[^1] != '[')
                    {

                        substirng.Insert(0, stack[^1]);
                        stack.RemoveAt(stack.Count - 1);
                    }

                    stack.RemoveAt(stack.Count - 1);

                    var k = new StringBuilder();

                    while (stack.Count > 0 && char.IsDigit(stack[^1]))
                    {
                        k.Insert(0, stack[^1]);
                        stack.RemoveAt(stack.Count - 1);

                    }

                    int kBuilder = int.Parse(k.ToString());



                    for (int j = 0; j < kBuilder; j++)
                    {
                        foreach (var sub in substirng.ToString())
                        {
                            stack.Add(sub);
                        }
                    }
                }
            }

            return string.Join("", stack);
        }


        public string DecodeString3(string s)
        {
            var stack = new Stack<string>();

            var numStack = new Stack<int>();

            var currentString = new StringBuilder();

            var currentNum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    currentNum = currentNum * 10 + (s[i] - '0');
                }
                else if (s[i] == '[')
                {
                    numStack.Push(currentNum);
                    stack.Push(currentString.ToString());
                    currentString.Clear();
                    currentNum = 0;
                }
                else if (s[i] == ']')
                {
                    string originalString = currentString.ToString();
                    int repeatCount = numStack.Pop();

                    IEnumerable<string> repeatedEnumerable = Enumerable.Repeat(originalString, repeatCount);

                    var repeatedString = string.Concat(repeatedEnumerable);
                    currentString.Clear();
                    currentString.Append(stack.Pop() + repeatedString);
                }
                else
                {
                    currentString.Append(s[i]);

                }
            }

            return currentString.ToString();
        }

        public string CountOfAtoms(string formula)
        {
            var numStack = new Stack<int>();
            var stack = new Stack<string>();
            var currentString = new StringBuilder();
            var currentNum = 1;
            var dict = new Dictionary<string, int>();


            foreach (char f in formula)
            {
                if (char.IsDigit(f))
                {
                    currentNum = currentNum * 10 + (f - '0');

                }
                else if (char.IsUpper(f))
                {
                    if (currentString.ToString() != "")
                    {
                        if (dict.ContainsKey(currentString.ToString()))
                        {
                            dict[currentString.ToString()] = currentNum;
                        }

                    }
                    dict.Add(currentString.ToString(), currentNum);
                    currentString.Append(f);
                    currentNum = 1;

                }
                else if (char.IsLower(f))
                {
                    currentString.Append(f);
                }

            }

            return string.Join("", dict);
        }

        public int ScoreOfParentheses(string s)
        {
            var currentNum = 0;
            var stack = new Stack<char>();

            foreach (char c in s)
            {
                if (c == '[')
                {
                    stack.Push(c);
                }
                else
                {
                    stack.Pop();
                    currentNum += 1;
                }
            }

            return currentNum;
        }


        public string SimplifyPath(string path)
        {

            var stack = new List<char>();

            var currentDotNumber = 0;
            var characterCount = 0;

            foreach (char c in path)
            {
                if (c == '/' && stack.Count > 0)
                {
                    Console.WriteLine(characterCount);
                    var slashCount = 0;

                    while (currentDotNumber == 2 && slashCount < 2 && stack.Count > 1 && characterCount == 2)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        if (stack[^1] == '/')
                        {
                            slashCount++;
                        }

                    }


                    if (currentDotNumber == 1 && characterCount == 1)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }

                    if (stack[^1] == '/' && stack.Count > 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }

                    currentDotNumber = 0;
                    characterCount = 0;



                }

                if (c != '/')

                {
                    characterCount++;

                }

                if (c == '.')
                {
                    currentDotNumber += 1;
                }


                stack.Add(c);


            }

            if (stack.Count > 1 && stack[^1] == '.')
            {
                var slashCount2 = 0;
                while (currentDotNumber == 2 && slashCount2 < 2 && stack.Count > 1)
                {

                    stack.RemoveAt(stack.Count - 1);
                    if (stack[^1] == '/')
                    {
                        slashCount2++;
                    }

                }

                if (stack.Count > 1 && currentDotNumber == 1)
                {
                    stack.RemoveAt(stack.Count - 1);
                }
            }

            while (stack.Count > 1 && stack[^1] == '/')
            {
                stack.RemoveAt(stack.Count - 1);
            }




            return string.Join("", stack);

        }


        public string SimplifyPath2(string path)
        {
            var stack = new List<string>();
            var stringItem = new StringBuilder();


            foreach (char c in path)
            {
                if (c == '/')
                {
                    if (stringItem.ToString() == ".." && stack.Count > 0)
                    {
                        stack.RemoveAt(stack.Count - 1);


                    }
                    else if (stringItem.ToString() != string.Empty && stringItem.ToString() != "." && stringItem.ToString() != "..")
                    {
                        Console.WriteLine("This is the string: " + stringItem.ToString());
                        stack.Add(stringItem.ToString());
                    }

                    stringItem.Clear();
                }
                else
                {
                    stringItem.Append(c);
                }


            }

            if (stringItem.ToString() == ".." && stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1);
                stringItem.Clear();

            }
            else if (stringItem.ToString() != string.Empty && stringItem.ToString() != "." && stringItem.ToString() != "..")
            {
                Console.WriteLine("This is the string: " + stringItem.ToString());
                stack.Add(stringItem.ToString());
            }




            return "/" + string.Join("/", stack);

        }


        public string SimplifyPath3(string path)
        {
            var stack = new List<string>();

            foreach (var dir in path.Split('/'))
            {
                if (dir == "..")
                {
                    if (stack.Count > 0) stack.RemoveAt(stack.Count - 1); // Go back one level
                }
                else if (dir.Length > 0 && dir != ".")
                {
                    stack.Add(dir); // Add valid directory
                }


            }

            return "/" + string.Join("/", stack);
        }


        public string RemoveStars(string s)
        {
            var substr = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(substr);
                if (s[i] == '*')
                {
                    substr.Remove(substr.Length - 1, 1);
                }
                else
                {
                    substr.Append(s[i]);
                }
            }


            return substr.ToString();



        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new List<int>();

            foreach (var ast in asteroids)
            {
                var num = ast;
                while (stack.Count > 0 && num < 0 && stack[^1] > 0)
                {
                    var currentDiff = num + stack[^1];

                    if (currentDiff < 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                    else if (currentDiff == 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        num = 0;
                    }
                    else
                    {
                        num = 0;
                        break;
                    }
                }

                if (num != 0)
                {
                    stack.Add(ast);
                }
            }

            Console.WriteLine(string.Join(",", stack));

            return [.. stack];

        }


        public int EvalRPN(string[] tokens)
        {

            var stack = new List<int>();

            foreach (var c in tokens)
            {
                if (int.TryParse(c, out int result))
                {
                    stack.Add(result);
                }
                else
                {
                    result = EvaluateForRPN(stack[^2],stack[^1], c);
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(result);
                }


            }

            return stack[^1];

        }

        private int EvaluateForRPN(int firstNumber,int secondNumber, string operation)
        {
           

            
            return operation switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "/" => firstNumber / secondNumber,
                "*" => firstNumber * secondNumber,
                _ => 0,
            };
        }
    }
}