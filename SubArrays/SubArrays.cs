using System.Security.AccessControl;

namespace DataStructuresAlgorithms.SubArrays
{
    public class SubArrays
    {
        public bool IsSubsequence(string s, string t)
        {
            var fast = 0;

            var slow = 0;


            while (fast < t.Length)
            {
                if (s[slow] == t[fast])
                {
                    slow++;
                    if (slow == s.Length)
                    {
                        return true;
                    }

                }

                fast++;
            }


            return slow == s.Length;

        }


        public int MinSubArrayLen(int target, int[] nums)
        {
            int result = int.MaxValue;


            int fast = 0;

            int slow = 0;

            int currentSum = 0;



            while (fast < nums.Length)
            {
                currentSum += nums[fast];
                Console.WriteLine(currentSum);
                while (currentSum >= target)
                {

                    result = Math.Min(result, fast - slow + 1);
                    currentSum -= nums[slow];
                    Console.WriteLine("inside loop current sum:  " + currentSum);
                    slow++;
                }


                fast++;
            }


            if (result == int.MaxValue)
            {
                return 0;
            }
            return result;
        }


        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int result = 0;

            int fast = 0;

            int slow = 0;

            int currentSum = 1;

            while (fast < nums.Length)
            {
                currentSum = nums[fast] * currentSum;



                while(currentSum >= k && slow <= fast)
                {
                    Console.WriteLine("Current sum is: "+currentSum);
                    currentSum = currentSum / nums[slow];
                    slow++;
                }

                result += (fast - slow + 1);

                Console.WriteLine(result);

                fast++;
            }


            return result;
        }
    }
}