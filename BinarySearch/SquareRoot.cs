

namespace DataStructuresAlgorithms.BinarySearch
{
    public class SquareRoot
    {
        public int MySqrt(int x)
        {

            if (x < 1) return 0;
            int right = x / 2;

            int left = 1;

            while (right > left)
            {
                var middlepoint = (right + left) / 2;


                long currentSquare = middlepoint * middlepoint;


                Console.WriteLine(middlepoint);


                if (currentSquare == x)
                {
                    return middlepoint;
                }
                else if (currentSquare > x)
                {
                    right = middlepoint-1;
                }
                else
                {
                    left = middlepoint+1;
                }


            }

            return left;
        }
    }
}