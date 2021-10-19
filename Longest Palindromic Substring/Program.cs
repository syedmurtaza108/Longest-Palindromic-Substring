using System;

namespace Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("abcba"));
            Console.WriteLine(LongestPalindrome("abbd"));
            Console.WriteLine(LongestPalindrome2("babad"));
            Console.WriteLine(LongestPalindrome2("babaddtattarrattatddetartrateedredividerb"));
        }
        static string LongestPalindrome2(string s)
        {
            if (s.Length == 0 || s.Length == 1)
            {
                return s;
            }

            int a = s.Length - 1;
            int r, l;

            for (int i = a; i >= 0; i--)
            {
                for (int ii = 0; ii <= a - i; ii++)
                {
                    l = ii;
                    r = i + l;

                    while (s[l] == s[r])
                    {
                        if (l >= r)
                        {
                            return s.Substring(ii, i + 1);
                        }

                        r--;
                        l++;
                    }
                }
            }

            return s.Substring(0, 1);
        }

        static string LongestPalindrome(string s)
        {
            if (s.Length < 1) return s;
            var mid = s.Length / 2;
            var midJ = s.Length % 2 == 0 ? mid - 1 : mid;
            var isPalindrome = true;
            for (int i = 0, j = s.Length - 1; i < mid && j > midJ; i++, j--)
            {
                if (s[i] != s[j])
                {
                    isPalindrome = false;
                    break;
                }
                if (!isPalindrome) break;
            }

            if (isPalindrome) return s;
            var a = LongestPalindrome(s.Substring(0, s.Length - 1));
            var b = LongestPalindrome(s.Substring(1, s.Length -1 ));
            return a.Length > b.Length ? a : b;
        }
    }
}
