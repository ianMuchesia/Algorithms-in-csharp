


using System.Reflection.PortableExecutable;
using System.Text;

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

                Console.WriteLine("currentString: " + currentString);


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


    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        IList<IList<int>> result = [];

        void Dfs(int index, int depth, int sum, IList<int> subset)
        {
            if (sum > n)
            {
                return;
            }

            if (depth == k)
            {
                if (sum == n)
                {
                    // result.Add([.. subset]);
                    Console.WriteLine("This is the subset length: " + subset.Count);
                    result.Add([.. subset]);
                    Console.WriteLine("This is the sum: " + sum);
                }
                // Console.WriteLine("This is the sum: " + sum);
                //  result.Add([.. subset]);
                Console.WriteLine("This is the array content: " + string.Join("", subset));

                return;
            }

            for (int i = index; i < 10; i++)
            {
                subset.Add(i);

                // if (sum + i > n)
                // {
                //     break;
                // }

                Dfs(i + 1, depth + 1, sum + i, subset);
                subset.RemoveAt(subset.Count - 1);

            }



        }
        Dfs(1, 0, 0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));

        }



        return result;

    }

    // public int NumTilePossibilities(string tiles)
    // {
    //     IList<IList<char>> result = [];

    //     var seen = new HashSet<int>();


    //     void Dfs(int depth, IList<char> subset)
    //     {
    //         result.Add([.. subset]);
    //         if (depth >= tiles.Length)
    //         {

    //             return;
    //         }

    //         for (int i = 0; i < tiles.Length; i++)
    //         {
    //             if (seen.Contains(i)) continue;
    //             seen.Add(i);
    //             subset.Add(tiles[i]);
    //             Dfs(depth + 1, subset);
    //             subset.RemoveAt(subset.Count - 1);
    //             seen.Remove(i);
    //         }
    //     }

    //     Dfs(0, []);
    //     foreach (var arr in result)
    //     {
    //         Console.WriteLine(string.Join(",", arr));

    //     }


    //     return result.Count;

    // }

    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = [];

        var used = new bool[nums.Length];


        void Dfs(int depth, IList<int> subset)
        {
            if (depth >= nums.Length)
            {
                result.Add([.. subset]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;
                used[i] = true;
                subset.Add(nums[i]);
                Dfs(depth + 1, subset);
                subset.RemoveAt(subset.Count - 1);
                used[i] = false;
            }

        }

        Dfs(0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));
        }
        return result;
    }
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        IList<IList<int>> result = [];

        Array.Sort(nums);

        var used = new bool[nums.Length];


        void Dfs(int depth, IList<int> subset)
        {
            if (depth >= nums.Length)
            {
                result.Add([.. subset]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;
                if (i > 0 && !used[i - 1] && nums[i] == nums[i - 1])
                {
                    Console.WriteLine("nums[i] is equals to: " + nums[i] + " and nums[i-1] is: " + nums[i - 1]);
                    continue;
                }

                used[i] = true;
                subset.Add(nums[i]);
                Dfs(depth + 1, subset);
                subset.RemoveAt(subset.Count - 1);
                used[i] = false;
            }

        }

        Dfs(0, []);

        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));
        }
        return result;
    }

    public int NumTilePossibilities(string tiles)
    {
        IList<IList<char>> result = [];

        var used = new bool[tiles.Length];

        char[] chars = tiles.ToCharArray();
        Array.Sort(chars);
        string sorted = new string(chars);


        void Dfs(int depth, IList<char> subset)
        {
            result.Add([.. subset]);
            if (depth >= tiles.Length)
            {

                return;
            }

            for (int i = 0; i < tiles.Length; i++)
            {
                if (used[i]) continue;
                if (i > 0 && sorted[i] == sorted[i - 1] && !used[i - 1])
                {
                    continue;
                }


                used[i] = true;
                subset.Add(sorted[i]);
                Dfs(depth + 1, subset);

                subset.RemoveAt(subset.Count - 1);
                used[i] = false;
            }
        }

        Dfs(0, []);
        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        return result.Count;
    }

    public IList<string> LetterCasePermutation(string s)
    {
        IList<string> result = [];

        char[] chars = s.ToCharArray();

        var used = new bool[s.Length];

        void Dfs(int depth, char[] subset)
        {
            result.Add(new string(subset));
            if (depth >= s.Length)
            {   
                Console.WriteLine();
                Console.WriteLine("\nThis is the subset on returning: " + string.Join("->", subset));
                return;
            }

            for (int i = depth; i < chars.Length; i++)
            {


                if (!char.IsLetter(chars[i]))
                {
                    continue;
                }




                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else
                {
                    chars[i] = char.ToUpper(chars[i]);

                }

                Console.WriteLine("We are at depth:" + (depth + 1) + " and the subset is: " + string.Join("-", subset));

                Dfs(i + 1, subset);

                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else
                {
                    chars[i] = char.ToUpper(chars[i]);




                }

                Console.WriteLine();
                Console.WriteLine("After Backtracking the string: "+string.Join("--", subset)+" we are at depth: "+depth);


            }
        }

        Dfs(0, chars);
        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        return result;
    }



    public IList<string> LetterCasePermutation2(string s)
    {
        IList<string> result = [];

        char[] chars = s.ToCharArray();

        var used = new bool[s.Length];

        void Dfs(int depth, char[] subset)
        {
             result.Add(new string(subset));
            
            if (depth >= s.Length)
            {

                return;
            }

            for (int i = depth; i < chars.Length; i++)
            {

                if (!char.IsLetter(chars[i]))
                {
                    continue;
                }

                if (used[i]) continue;

                used[i] = true;
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else
                {
                    chars[i] = char.ToUpper(chars[i]);

                }

                Dfs(depth + 1, subset);

                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToLower(chars[i]);
                }
                else
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
                used[i] = false;
            }
        }

        Dfs(0, chars);
        foreach (var arr in result)
        {
            Console.WriteLine(string.Join(",", arr));
        }

        return result;
    }


}