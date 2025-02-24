// See https://aka.ms/new-console-template for more information


using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using DataStructuresAlgorithms.BinarySearch;
using DataStructuresAlgorithms.Graphs;
using DataStructuresAlgorithms.Hashmaps;
using DataStructuresAlgorithms.Prefix;
using DataStructuresAlgorithms.Revision;
using DataStructuresAlgorithms.SlidingWindow;
using DataStructuresAlgorithms.Stack;
using DataStructuresAlgorithms.SubArrays;


class Program
{
    static void Main(string[] args)
    {
        Arrays arrays = new Arrays();

        // arrays.ExampleMethod();
        // arrays.MoveZeroes([1,2,0,3,0]);
        //arrays.RemoveDuplicates([0,0,1,1,1,2,2,3,3,4]);
        //arrays.RemoveElement([0,1,2,2,3,0,4,2],2);
        // arrays.ClosetTarget( ["a","b","leetcode"], "leetcode",0);
        // Stack stack = new Stack();


        // stack.Push(1);
        //stack.Peek();


        // SearchInsertPosition searchInsert = new SearchInsertPosition();

        // int[] nums = [1,3,5,6];
        // int target = 2;

        // int result =searchInsert.SearchInsert(nums,target);


        // SquareRoot squareRoot = new SquareRoot();

        // decimal result = squareRoot.MySqrt(3);

        // MissingNumber missingNumber = new MissingNumber();

        // var result = missingNumber.Solution2([1,0,3]);

        // BadVersion badVersion = new BadVersion();

        // int result = badVersion.FirstBadVersion(6);

        // LeetCodeHashmaps leetCodeHashmaps = new LeetCodeHashmaps();

        // var result = leetCodeHashmaps.IsAnagram("anagram","nagaram");

        // AdjacencyListGraph adjacencyListGraph = new AdjacencyListGraph();

        // adjacencyListGraph.addVertex("A");
        // adjacencyListGraph.addVertex("B");
        // adjacencyListGraph.addVertex("C");

        // adjacencyListGraph.addEdge("A","B");
        // adjacencyListGraph.addEdge("B","C");

        // //adjacencyListGraph.removeEdge("A","B");
        // adjacencyListGraph.removeVertex("B");

        // adjacencyListGraph.display();

        // bool result =  adjacencyListGraph.hasEdge("A","B");

        LeetCodeGraph codeGraph = new LeetCodeGraph();

        // int result = codeGraph.FindJudge(3,[[1,3],[2,3]]);

        // bool result = codeGraph.ValidPath(10, [[4,3],[1,4],[4,8],[1,7],[6,4],[4,2],[7,4],[4,0],[0,9],[5,4]],5,9);


        // var result = new IPLocationFinder();

        // string results = result.GetIPLocation("41.90.106.13").Result;
        // Console.WriteLine(results);

        LeetCodeHashmaps hashmaps = new LeetCodeHashmaps();

        // Console.WriteLine(hashmaps.LengthOfLongestSubstring("abcabcbb"));
        //Console.WriteLine(hashmaps.FindRepeatedDnaSequences2("AAAAAAAAAAA"));
        // Console.WriteLine(hashmaps.MinSubArrayLen(4,[1,4,4]));


        TwoSum twoSum = new TwoSum([2, 7, 11, 15], 9);

        SlidingWindow slidingWindow = new SlidingWindow();


        //Console.WriteLine(slidingWindow.LongestSubstring2("ababbc",2));

        // Console.WriteLine(slidingWindow.NumberOfArithmeticSlices([1,2,3,4,7,9,1,8,3,4,5,6,1,4,5,6]));
        //    Console.WriteLine(slidingWindow.NumberOfArithmeticSlices([1,2,3,4]));


        //var prefix = new PrefixSum();

        //Console.WriteLine(prefix.RunningSum([1,2,3,4]));

        //Console.WriteLine(prefix.SubarraySum([1,2,1,2,1],3));

        //Console.WriteLine(prefix.BinaryNumSubarraysWithSum([1,0,1,0,1],2));

        //Console.WriteLine(slidingWindow.MaxSubarrayLength([2,2,3],1));


        var subarrays = new SubArrays();

        //Console.WriteLine(slidingWindow.CheckInclusion("ab","eidbaooo"));
        // Console.WriteLine(subarrays.IsSubsequence("b","abc"));

        // Console.WriteLine(subarrays.MinSubArrayLen(7,[2,3,1,2,4,3]));

        //Console.WriteLine(subarrays.NumSubarrayProductLessThanK([10,9,10,4,3,8,3,3,6,2,10,10,9,3],19));

        //Console.WriteLine(slidingWindow.LongestOnes([0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1],3));
        //Console.WriteLine(slidingWindow.LongestSubarray([1,1,1,0,0,0,1,1,1,0,1,1,0,0,1,1,1,1,1,1]));

        //Console.WriteLine(slidingWindow.MaximumUniqueSubarray([4,2,4,5,6]));

        //Console.WriteLine(slidingWindow.SubarraysWithKDistinct([1,2,1,3,4],3));

        //Console.WriteLine(slidingWindow.TotalFruit([1,2,1]));


        var stack = new Stack();

        // Console.WriteLine(stack.IsValid("([])"));

        var minStack = new MinStack();

        var queueStack = new MyQueue();

        // queueStack.Push(1);
        // queueStack.Pop();
        // queueStack.Empty();

        // Console.WriteLine(stack.BackspaceCompare("a##c","#a#c"));
        //Console.WriteLine(stack.DailyTemperatures2( [30,40,50,60]));

        // StockSpanner stockSpanner = new StockSpanner();
        // stockSpanner.Next(28); // return 1
        // stockSpanner.Next(14);  // return 1
        // stockSpanner.Next(28);  // return 1
        // stockSpanner.Next(35);  // return 2
        // stockSpanner.Next(60);  // return 1
        // stockSpanner.Next(75);  // return 4, because the last 4 prices (including today's price of 75) were less than or equal to today's price.
        // stockSpanner.Next(85);  // return 6

        // Console.WriteLine(stack.NextGreaterElement([1,3,5,2,4],[6,5,4,3,2,1,7]));

        var stackSolution = new StackSolution();

       // Console.WriteLine(stackSolution.ValidateStackSequences([1,2,3,4,5],[4,5,3,2,1]));
        // Console.WriteLine(stackSolution.DecodeString3("3[a]2[bc]"));
        //Console.WriteLine(stackSolution.CountOfAtoms("H20"));
        Console.WriteLine(stackSolution.SimplifyPath("/home/user/Documents///../Pictures"));




    }
}