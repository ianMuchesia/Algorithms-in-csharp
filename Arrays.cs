using System.Security.Principal;

public class Arrays
{
    public void ExampleMethod()
    {
        int[] numbers = { 1, 2, 3, 4 };

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    public void MoveZeroes(int[] nums)
    {

        //int zeros = 0;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                Console.WriteLine("Hello world");
            }
        }

    }

    public int RemoveDuplicates(int[] nums)
    {
        int slow = 0;
        int fast = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[fast] > nums[slow])
            {
                nums[slow + 1] = nums[fast];
                slow++;
            }
            fast++;
        }

        Console.WriteLine(nums);
        Console.WriteLine(string.Join(", ", nums));
        Console.WriteLine(slow);
        return slow + 1;
    }
    public int RemoveElement(int[] nums, int val)
    {
        int slow = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[slow] == val)
            {
                if (nums[i] != val)
                {
                    (nums[i], nums[slow]) = (nums[slow], nums[i]);
                    slow += 1;
                }
            }
            else
            {
                slow += 1;
            }
        }

        Console.WriteLine(nums);
        Console.WriteLine(string.Join(", ", nums));
        Console.WriteLine(slow);

        return slow;

    }

    public int ClosetTarget(string[] words, string target, int startIndex)
    {
        int left = startIndex;
        int right = startIndex;
        int counter = 0;


        while (counter < words.Length)
        {
            if (right >= words.Length)
            {
                right = 0;
            }

            if (left < 0)
            {
                left = words.Length - 1;
            }

            if (words[left] == target || words[right] == target)
            {
                Console.WriteLine(counter);
                return counter;
            }


            right++;
            left--;
            counter += 1;
        }

        Console.WriteLine(counter);
        Console.WriteLine(string.Join(", ", words));
        //Console.WriteLine(slow);
        return -1;
        // if (counter >= words.Length)
        // {
        //     return -1;
        // }
        // return counter+1;
    }
}