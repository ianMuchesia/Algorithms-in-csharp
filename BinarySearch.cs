

public class BinarySearch
{


    public bool Search(int[] arr, int target)
    {
        int right = arr.Length - 1;
        int left = 0;



        while (right >= left)
        {
            int middlepoint = (right + left) / 2;
            Console.WriteLine(middlepoint);

            if (arr[middlepoint] == target)
            {
                return true;
            }
            else if (arr[middlepoint] < target)
            {
                left = middlepoint + 1;
            }
            else
            {
                right = middlepoint - 1;
            }
        }
        return false;
    }


    public bool RecursiveSearch(int[] arr, int target)
    {

        return RecursiveBinarySearch(arr, 0, arr.Length - 1, target);
    }

    public bool RecursiveBinarySearch(int[] arr, int left, int right, int target)
    {
        if (right < left)
        {
            return false;
        }

        int middlepoint = (right + left) / 2;

        if (arr[middlepoint] == target)
        {
            return true;
        }
        else if (arr[middlepoint] < target)
        {
            return RecursiveBinarySearch(arr, middlepoint + 1, right, target);
        }
        else
        {
            return RecursiveBinarySearch(arr, left, middlepoint - 1, target);
        }
    }

}