


using System.Security.Cryptography;

namespace DataStructuresAlgorithms.BinarySearch
{
    public class SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            return RecursiveSearchInsert(nums,0,nums.Length-1,target);
        }

        public int RecursiveSearchInsert(int[] arr, int left,int right,int target)
        {
            if(right < left)
            {
                return left;
            }

            int middlepoint = (right + left) / 2;

            

            if(arr[middlepoint] == target)
            {
                return middlepoint;
            }
         
            else if(arr[middlepoint] > target)
            {
                return RecursiveSearchInsert(arr,left,middlepoint-1,target);
            }
            else
            {
                return RecursiveSearchInsert(arr,middlepoint+1,right,target);
            }


           
        }
    }
}