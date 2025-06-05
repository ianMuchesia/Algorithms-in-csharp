


class BacktrackingSolutions
{
    public IList<List<int>> Subsets(IList<int> ints)
    {
        IList<List<int>> result = new List<List<int>>();
        var subset = new List<int>();


        void dfs(int index)
        {
            if (index >= ints.Count)
            {
                result.Add([.. subset]);
                return;
            }

            //decisions to include nums of i
            subset.Add(ints[index]);

            dfs(index + 1);

            //decisions not to include nums of i
            subset.RemoveAt(subset.Count - 1);
            dfs(index + 1);

        }

        dfs(0);
        return result;


    }

    public IList<string> LetterCombinations(string digits)
    {

        IList<string> results = [];

        var digitsToChar = new Dictionary<char, string>
        {
            {'2',"abc"},
            {'3',"def"},
            {'4',"ghi"},
            {'5',"jkl"},
            {'6',"mno"}

        };

        void BackTrack(int index, string currentString)
        {
            if (currentString.Length == digits.Length)
            {
                results.Add(currentString);
                return;
            }

            foreach (var c in digitsToChar[digits[index]])
            {
                BackTrack(index + 1, currentString + c);
            }

        }

        if (digits != string.Empty)
        {
            BackTrack(0, "");
        }




        return results;

    }


    public IList<IList<int>> RepeatedPermutations(IList<int> nums, int k)
    {
        IList<IList<int>> result = [];


        void BackTrack(int depth, IList<int> subset)
        {
            if (depth >= k)
            {
                Console.WriteLine("Subset " + string.Join(",", subset));
                result.Add([.. subset]);
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {

                subset.Add(nums[i]);
                BackTrack(depth + 1, subset);
                subset.RemoveAt(subset.Count - 1);
            }

        }

        BackTrack(0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }

        return result;
    }

    public IList<IList<int>> NonRepeatedCombinations(IList<int> nums, int k)
    {
        IList<IList<int>> result = [];


        void BackTrack(int depth, int index, IList<int> subset)
        {
            if (depth >= k)
            {
                Console.WriteLine("Subset " + string.Join(",", subset));
                result.Add([.. subset]);
                return;
            }

            for (int i = index; i < nums.Count; i++)
            {

                subset.Add(nums[i]);

                BackTrack(depth + 1, index + 1, subset);
                subset.RemoveAt(subset.Count - 1);
                Console.WriteLine("the value of i is: " + index);
                index++;

            }

        }

        BackTrack(0, 0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }

        return result;
    }

    public IList<IList<int>> RepeatedCombinations(IList<int> nums, int k)
    {
        IList<IList<int>> result = [];


        void BackTrack(int depth, int index, IList<int> subset)
        {
            if (depth >= k)
            {
                Console.WriteLine("Subset " + string.Join(",", subset));
                result.Add([.. subset]);
                return;
            }

            for (int i = index; i < nums.Count; i++)
            {

                subset.Add(nums[i]);

                BackTrack(depth + 1, index, subset);
                subset.RemoveAt(subset.Count - 1);
                Console.WriteLine("the value of i is: " + index);
                index++;

            }

        }

        BackTrack(0, 0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }

        return result;
    }


    public IList<IList<int>> PermutationOrderMatters(IList<int> nums, int k)
    {

        IList<IList<int>> result = [];

        var set = new HashSet<int>();

        void BackTrack(int depth, IList<int> subset)
        {

            if (depth >= k)
            {
                result.Add([.. subset]);
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (set.Contains(i)) continue;
                set.Add(i);


                subset.Add(nums[i]);
                BackTrack(depth + 1, subset);
                subset.RemoveAt(subset.Count - 1);

                set.Remove(i);

            }

        }

        BackTrack(0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }



        return result;


    }



    public IList<IList<int>> PermutationOrderMatterSum(IList<int> nums, int k, int d)
    {

        IList<IList<int>> result = [];

        var used = new bool[nums.Count];



        void BackTrack(int sum, IList<int> subset)
        {

            if (subset.Count >= k)
            {
                if (sum % 5 == 0)
                {
                    result.Add([.. subset]);
                }
                return;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if (used[i]) continue;

                used[i] = true;


                subset.Add(nums[i]);
                BackTrack(sum += nums[i], subset);
                subset.RemoveAt(subset.Count - 1);
                sum -= nums[i];

                used[i] = false;

            }

        }

        BackTrack(0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }



        return result;


    }


    public IList<string> LetterCombinations2(string input)
    {
        IList<string> result = [];

        var combo = new Dictionary<char, string>
        {
            {'2',"abc"},
            {'3',"def"},
            {'4', "ghi"},
            {'5',"jkl"},
            {'6',"mno"},
            {'7',"pqrs"},
            {'8',"tuv"},
            {'9',"wxyz"},


        };


        void BackTrack(string currentString, int index)
        {

            Console.WriteLine(index);

            if (index == input.Length)
            {
                result.Add(new string(currentString));
                return;
            }



            foreach (var letter in combo[input[index]])
            {
                currentString = currentString + letter;

                BackTrack(currentString, index + 1);

                currentString = currentString.Remove(currentString.Length - 1);
                
                Console.WriteLine("currentString: "+currentString );


               // currentString.Remove(letter);
            }


        }

        BackTrack("", 0);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }




        return result;
    }

}