

using Microsoft.VisualBasic;

namespace DataStructuresAlgorithms.Revision
{
    public class TwoSum
    {

        private readonly int[] _nums;

        private readonly int _target;
        public TwoSum(int[] nums, int target)
        {
            _nums = nums;
            _target = target;
        }


        public int[] HashMapMethod()
        {
           Dictionary<int,int> valuePairs = new Dictionary<int, int>();

           var result = new int[2];

           for(int i=0;i<_nums.Length;i++)
           {

                var current_difference = _target - _nums[i];

                if(valuePairs.ContainsKey(current_difference))
                {
                    result = [valuePairs[current_difference],i];
                }
                else
                {
                    valuePairs[_nums[i]] = i;
                }

           }

           foreach(var item in result)
           {
            Console.WriteLine(item);
           }


           return result;



        }

        public int[] TwoPointerMethod(int[] numbers, int target)
        {

            int left = 0;
            int right = numbers.Length -1;

            while(left <= right)
            {

                var currentMax = numbers[left] + numbers[right];

                if(currentMax == target)
                {
                    break;
                }
                else if(currentMax > target)
                {
                    right -= 1;

                }
                else{
                    left += 1;
                }


            }



            return [left+1,right+1];

        }


    }
}