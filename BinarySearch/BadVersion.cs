namespace DataStructuresAlgorithms.BinarySearch
{
    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

    public class BadVersion
    {
        public int FirstBadVersion(int n)
        {
            int high = n;
            int low = 1;

            int middlepoint = 0;



            while(high>low)
            {
                middlepoint = (high + low) / 2;
                Console.WriteLine(middlepoint);

                //if(middlepoint == 1)break;

                if(IsBadVersion(middlepoint))
                {
                    high = middlepoint-1;
                }
                else
                {
                    low = middlepoint+1;
                }

            }

            return low;
        }


        public bool IsBadVersion(int version)
        {
            if (version >= 2)
            {
                return true;
            }

            return false;
        }
    }
}