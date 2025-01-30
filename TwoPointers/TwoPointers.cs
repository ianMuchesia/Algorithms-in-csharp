namespace DataStructuresAlgorithms.TwoPointers
{
    public class TwoPointers
    {
        public int MaxArea(int[] height)
        {

            int result = int.MinValue;

            int left = 0;

            int right = height.Length - 1;


            while(left < right)
            {
                int currentHeight = Math.Min(height[left],height[right]);

                int currentArea = (right - left) * currentHeight;

                result = Math.Max(currentArea,result);


                if(currentHeight == height[left])
                {
                    left ++;
                }
                else
                {
                    right++;
                }
            }

            return result;

        }
    }
}