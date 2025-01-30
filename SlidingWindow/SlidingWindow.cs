


namespace DataStructuresAlgorithms.SlidingWindow
{
    public class SlidingWindow
    {


        public int MinSubArrayLen(int target, int[] nums)
        {

            int left = 0;

            int currentSum = 0;

            int result = int.MaxValue;


            for (int right = 0; right < nums.Length; right++)
            {
                currentSum = currentSum + nums[right];

                while (currentSum >= target)
                {
                    result = Math.Min(result, right - left + 1);
                    currentSum = currentSum - nums[left];
                    left++;
                }

            }


            if (result == int.MaxValue) return 0;
            return result;

        }


        public int LongestSubstring(string s, int k)
        {

            int result = 0;

            var myDict = new Dictionary<char, int>();


            for (int i = 0; i < s.Length; i++)
            {
                if (myDict.ContainsKey(s[i]))
                {
                    myDict[s[i]] = myDict[s[i]] + 1;
                }
                else
                {
                    myDict[s[i]] = 1;
                }
            }


            foreach (var item in myDict)
            {
                if (item.Value >= k)
                {
                    result = result + item.Value;
                }
            }



            return result;

        }


        public int LongestSubstring2(string s, int k)
        {

            int left = 0;
            int right = 0;

            var charCount = new Dictionary<char,int>();

            while(right < s.Length)
            {
                if(charCount.ContainsKey(s[right]))
                {
                    charCount[s[right]] += 1;
                }
                else
                {
                    charCount[s[right]] = 1;
                }

                while(charCount[s[right]] < k && right - left >= k)
                {


                }

               
               
                right ++;
            }

            return 1;
        }


        //get the maximum number of unique letters in the string s
        private int getMaxUniqueLetters(string s)
        {
            var hashset = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                hashset.Add(s[i]);

            }

            return hashset.Count();
        }


        public int NumberOfArithmeticSlices(int[] nums)
        {

            if (nums.Length < 3) return 0;
            int left = 0;

            int right = 1;

            int result = 0;

            int mainDifference = nums[right] - nums[left];

            while (right < nums.Length)
            {
                int current_difference = nums[right] - nums[right - 1];

                if (current_difference != mainDifference)
                {

                    Console.WriteLine("main difference: " + mainDifference);
                    Console.WriteLine("Current Difference: " + current_difference);

                    Console.WriteLine("*********");
                    if (right - left + 1 > 3)
                    {
                        result++;
                    }

                    left = right - 1;

                    mainDifference = current_difference;

                }

                right++;
            }

            Console.WriteLine("right is: " + right + " left is " + left);



            return result;



        }

        public int MaxSubarrayLength(int[] nums, int k)
        {
            //Length of Longest Subarray With at Most K Frequency
          

            int right = 0;
            int left = 0;

            var windowMap = new Dictionary<int, int>();


            var result = int.MinValue;



            while (right < nums.Length)
            {

                if (windowMap.ContainsKey(nums[right]))
                {
                    windowMap[nums[right]] += 1;
                }
                else
                {
                    windowMap[nums[right]] = 1;
                }


                while (windowMap[nums[right]] > k)
                {
                    windowMap[nums[left]] -= 1;
                    left++;
                }

                result = Math.Max(result, right - left + 1);

                right++;

            }




            return result;

        }

    }


}
