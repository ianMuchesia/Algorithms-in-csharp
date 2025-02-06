


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

            var charCount = new Dictionary<char, int>();

            while (right < s.Length)
            {
                if (charCount.ContainsKey(s[right]))
                {
                    charCount[s[right]] += 1;
                }
                else
                {
                    charCount[s[right]] = 1;
                }

                while (charCount[s[right]] < k && right - left >= k)
                {


                }



                right++;
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


        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();

            if (s.Length == 0) return result;


            var validDict = new Dictionary<char, int>();

            foreach (var item in p)
            {
                if (validDict.ContainsKey(item))
                {
                    validDict[item] += 1;
                }
                else
                {
                    validDict[item] = 1;
                }
            }


            var left = 0;

            var right = 0;


            while (right < s.Length)
            {
                //incoming
                var incomingCharacter = s[right];

                if (validDict.ContainsKey(incomingCharacter))
                {
                    validDict[incomingCharacter] -= 1;

                    if (validDict[incomingCharacter] == 0)
                    {
                        left += 1;
                    }
                }


                //outgoing
                if (right >= p.Length)
                {
                    var outgoingCharacter = s[right - p.Length];
                    if (validDict.ContainsKey(outgoingCharacter))
                    {
                        validDict[outgoingCharacter] += 1;

                        if (validDict[outgoingCharacter] == 1)
                        {
                            left -= 1;
                        }
                    }
                }

                if (left == validDict.Count)
                {
                    result.Add(right - p.Length + 1);
                }
                right++;
            }

            return result;
        }

        public bool CheckInclusion(string s1, string s2)
        {

            var dict = new Dictionary<char, int>();

            foreach (var item in s1)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item] += 1;
                }
                else
                {
                    dict[item] = 1;
                }
            }

            var left = 0;

            var right = 0;

            while (right > s2.Length)
            {
                var incomingCharacter = s2[right];

                if (dict.ContainsKey(incomingCharacter))
                {
                    dict[incomingCharacter] -= 1;
                    if (dict[incomingCharacter] == 0)
                    {
                        left += 1;
                    }
                }


                if (right >= s1.Length)
                {
                    var outgoingCharacter = s2[right - s1.Length];

                    if (dict.ContainsKey(outgoingCharacter))
                    {
                        dict[outgoingCharacter] += 1;
                        if (dict[outgoingCharacter] == 1)
                        {
                            left -= 1;
                        }
                    }



                }


                if (left == dict.Count)
                {
                    return true;
                }
                right++;
            }

            return false;

        }

        public int LongestOnes(int[] nums, int k)
        {
            int result = int.MinValue;

            var myDict = new Dictionary<int, int>{
                {0,0}

            };

            int left = 0;

            int right = 0;


            while (right < nums.Length)
            {
                if (nums[right] == 0)
                {
                    myDict[0] += 1;
                }

                while (myDict[0] > k)
                {

                    if (nums[left] == 0)
                    {
                        myDict[0] -= 1;
                    }
                    left++;

                }

                result = Math.Max(result, right - left + 1);

                Console.WriteLine("result: " + result);

                right++;
            }



            if (result == int.MinValue)
            {
                return 0;
            }
            return result;
        }

        public int LongestSubarray(int[] nums)
        {

            int result = 0;

            int countZero = 0;

            int left = 0;

            for(int right=0; right<nums.Length;right++)
            {

                if(nums[right] == 0)
                {
                    countZero++;
                }
                if(countZero>1)
                {
                    if(nums[left] == 0)
                    {
                        countZero--;
                    }

                    left++;
                }

                result = Math.Max(result,right-left);
            }
            
            if(result == nums.Length)
            {
                return result-1;
            }

            return result;

        }

    }




}
