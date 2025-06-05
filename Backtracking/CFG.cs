
//permutations of a string
class CfG
{
    public static List<string> StringPermutation(string s)
    {
        List<string> ans = [];

        RecursionPermute(0, s.ToCharArray(), ans);
        ans.Sort();
        return ans;
    }

    public static void RecursionPermute(int index, char[] s, List<string> ans)
    {
        //base case
        if (index >= s.Length)
        {
            ans.Add(new string(s));
            return;
        }


        //swap the current index with all
        for (int i = index; i < s.Length; i++)
        {
            Swap(s, index, i);
            RecursionPermute(index + 1, s, ans);
            Swap(s, index, i);

        }
    }

    public static void Swap(char[] s, int i, int j)
    {
        (s[j], s[i]) = (s[i], s[j]);
    }
}