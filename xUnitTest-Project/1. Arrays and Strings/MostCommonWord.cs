/*

Given a paragraph and a list of banned words, return the most frequent word that is not in the list of banned words.  It is guaranteed there is at least one word that isn't banned, and that the answer is unique.

Words in the list of banned words are given in lowercase, and free of punctuation.  Words in the paragraph are not case sensitive.  The answer is in lowercase.

 

Example:

Input: 
paragraph = "Bob hit a ball, the hit BALL flew far after it was hit."
banned = ["hit"]
Output: "ball"
Explanation: 
"hit" occurs 3 times, but it is a banned word.
"ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
Note that words in the paragraph are not case sensitive,
that punctuation is ignored (even if adjacent to words, such as "ball,"), 
and that "hit" isn't the answer even though it occurs more because it is banned.
 

Note:

1 <= paragraph.length <= 1000.
0 <= banned.length <= 100.
1 <= banned[i].length <= 10.
The answer is unique, and written in lowercase (even if its occurrences in paragraph may have uppercase symbols, and even if it is a proper noun.)
paragraph only consists of letters, spaces, or the punctuation symbols !?',;.
There are no hyphens or hyphenated words.
Words only consist of letters, never apostrophes or other punctuation symbols.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Xunit;

namespace xUnitTest_Project.ArraysandStrings
{
    public partial class Solution
    {
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            if (string.IsNullOrEmpty(paragraph))  
            {
                return "";
            }

            var punctuation = paragraph.Where(Char.IsPunctuation).Concat(" ".ToCharArray()).Distinct().ToArray();
            var words = paragraph.ToLower().Split(punctuation).Select(x => x.Trim()).ToArray();

            var list = new Dictionary<string, int>();

            for (int i = 0; i < words.Count(); i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    var item = list.FirstOrDefault(x => x.Key == words[i].Trim());
                    if (!item.Equals(default(KeyValuePair<string, int>)))
                    {
                        list[item.Key] = item.Value + 1;
                    }
                    else
                    {
                        list.Add(words[i].Trim(), 1);
                    }
                }
            }

            foreach (var item in list.OrderByDescending(x => x.Value))
            {
                if (banned.Length == 0 || !banned.Contains(item.Key))
                {
                    return item.Key;
                }
            }

            return "";
        }

        [Fact]
        public static void MostCommonWord1()
        {
            var input = "Bob hit a ball, the hit BALL flew far after it was hit.";
            var input1 = new string[] { "hit" };
            var expected = "ball";
            var result = MostCommonWord(input, input1);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MostCommonWord2()
        {
            var input = "a.";
            var input1 = new string[] { };
            var expected = "a";
            var result = MostCommonWord(input, input1);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void MostCommonWord3()
        {
            var input = "a, a, a, a, b,b,b,c, c";
            var input1 = new string[] { "a" };
            var expected = "b";
            var result = MostCommonWord(input, input1);
            Assert.Equal(expected, result);
        }
    }
}
