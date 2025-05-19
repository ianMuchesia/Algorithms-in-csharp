

using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataStructuresAlgorithms.Hashmaps
{
    public class LeetCodeHashmaps
    {


        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> myDict = new Dictionary<int, int>();


            foreach (var num in nums)
            {
                if (myDict.ContainsKey(num))
                {
                    myDict[num] = myDict[num] + 1;
                }
                else
                {
                    myDict[num] = 1;
                }
            }

            var maxValue = 1;
            var result = 0;



            foreach (var item in myDict)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    result = item.Key;
                }

            }

            return result;

        }

        public int LengthOfLongestSubstring(string s)
        {


            var charSet = new HashSet<int>();

            int left = 0;

            int res = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (charSet.Contains(s[i]))
                {
                    charSet.Remove(s[left]);
                    left++;
                }

                charSet.Add(s[i]);

                res = Math.Max(res, (i - left) + 1);
            }


            return res;


        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {

            IList<string> myResult = new List<string>();

            if (s.Length <= 10)
            {
                return myResult;
            }

            var myDict = new Dictionary<string, int>();

            int right = 10;

            int left = 0;


            while (right <= s.Length)
            {
                var windowString = s.Substring(left, 10);

                Console.WriteLine(right);

                Console.WriteLine(s.Length);

                if (myDict.ContainsKey(windowString))
                {
                    myDict[windowString] = myDict[windowString] + 1;
                }
                else
                {
                    myDict[windowString] = 1;
                }

                right++;
                left++;

            }

            foreach (var item in myDict)
            {
                Console.WriteLine("this is the key: " + item.Key + " and the value: " + item.Value);
                if (item.Value > 1)
                {
                    myResult.Add(item.Key);
                }
            }



            return myResult;


        }

        public IList<string> FindRepeatedDnaSequences2(string s)
        {

            IList<string> myResult = new List<string>();

            if (s.Length <= 10)
            {
                return myResult;
            }

            var myDict = new HashSet<string>();

            var tempResult = new HashSet<string>();


            int left = 0;

            for (int i = 10; i <= s.Length; i++)
            {
                Console.WriteLine("iam here");
                var windowString = s.Substring(left, 10);

                if (myDict.Contains(windowString))
                {
                    tempResult.Add(windowString);
                }
                else
                {
                    myDict.Add(windowString);
                }

                left++;
            }


            foreach (var item in tempResult)
            {
                myResult.Add(item);
            }




            return myResult;

        }


        public int MinSubArrayLen(int target, int[] nums)
        {
            int currentSum = 0;

            int currentLength = 0;

            int result = int.MaxValue;




            for (int i = 0; i < nums.Length; i++)
            {
                currentSum = currentSum + nums[i];
                Console.WriteLine(currentSum);

                if (currentSum >= target)
                {
                    currentLength = i - currentLength;

                    result = Math.Min(result, currentLength);


                    currentSum = 0;
                }
            }

            if (result == int.MaxValue) return 0;
            return result;

        }

        // public bool ContainsDuplicate(int[] nums)
        // {

        // }

        // public bool IsAnagram(string s, string t)
        // {


        public string IntToRoman(int num)
        {
            Dictionary<int,string> romans = new Dictionary<int, string>
            {
               {  1,   "1"},
               {4,"IV"},
               {5,"V"},
               {9,"IX"},
               {10,"X"},
               {40,"XL"},
               {50,"L"},
               {90,"XC"},
               {100,"C"},
               {400,"CD"},
               {500,"D"},
               {900,"CM"},
               {1000,"M"}    
  
            };

            var ouptut = new StringBuilder();

            int length = num.ToString().Length;

            

            return "";


        }













    }


}