using System.Diagnostics;

namespace DataStructuresAlgorithms.Prefix
{
    public class PrefixSum
    {
        public int[] RunningSum(int[] nums)
        {
            var result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result += nums[i];
                nums[i] = result;
            }

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(",", nums));
            return nums;
        }

        public int SubarraySum(int[] nums, int k)
        {
            var result = 0;

            var occurrences = new Dictionary<int, int>{
                {0,1}
            };


            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                var currentDifference = sum - k;

                if (occurrences.ContainsKey(currentDifference))
                {
                    result = occurrences[currentDifference];
                }

                occurrences[sum] = occurrences.GetValueOrDefault(sum, 0) + 1;

            }

            Console.WriteLine(string.Join(",", occurrences));


            return result;

        }

        public int NumberOfNiceSubarrays(int[] nums, int k)
        {
            // subarray is called nice if there are k odd numbers on i

            var occurrences = new Dictionary<int, int>{
                {0,1}
            };

            var sum = 0;

            var result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 != 0)
                {
                    sum += 1;
                }

                var currentDifference = sum - k;

                if (occurrences.ContainsKey(currentDifference))
                {
                    result += occurrences[currentDifference]; // Add the count of how many times we've seen (sum - k)
                }

                if (occurrences.ContainsKey(sum))
                {
                    occurrences[sum] += 1; // Increment count of this sum
                }
                else
                {
                    occurrences[sum] = 1; // Store first occurrence of this sum
                }


            }


            return result;

        }


        public int BinaryNumSubarraysWithSum(int[] nums, int goal)
        {

            var result = 0;

            var occurences = new Dictionary<int, int>{
                {
                    0,1
                }
            };


           
           var total = 0;


            for(int i=0;i<nums.Length;i++)
            {
                
                total += nums[i];
                int currentDifference = total - goal;

                if(occurences.ContainsKey(currentDifference))
                {
                    result += occurences[currentDifference];
                }

                if(occurences.ContainsKey(total))
                {
                    occurences[total] += 1;
                }
                else
                {
                    occurences[total] = 1;
                }
            }


            return result;

     

        }



    }
}