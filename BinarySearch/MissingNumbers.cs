namespace DataStructuresAlgorithms.BinarySearch
{

    public class MissingNumber
    {

        public int Solution(int[] nums)
        {
            int[] sortedNums = nums;

            Array.Sort(sortedNums);



            for (int i = 1; i < sortedNums.Length; i++)
            {
                var currentDifference = sortedNums[i] - sortedNums[i - 1];

                if (currentDifference > 1)
                {
                    return sortedNums[i] - 1;
                }
            }

            return 0;
        }


        public int Solution2(int[] nums)
        {
            int sum = 0;
            int expectedSum = 0;

            for(int i= 0;i<nums.Length;i++)
            {
                sum += nums[i];
                expectedSum += i+1;
            }

            return expectedSum - sum;
        }
    }
}