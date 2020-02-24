/*



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
        public static string[] ReorderLogFiles(string[] logs)
        {
            var letterList = new Dictionary<string, string>();
            var digitList = new Dictionary<string, string>();

            for (int i = 0; i < logs.Length; i++)
            {
                var log = logs[i];
                var spaceIndex = log.IndexOf(" ");
                var id = log.Substring(0, spaceIndex);
                var words = log.Substring(spaceIndex + 1, log.Length - spaceIndex - 1);
                var firstLetter = log.Substring(spaceIndex + 1, 1).ToCharArray();

                if (Char.IsNumber(firstLetter[0]))
                {
                    digitList.Add(log, words);
                }
                else
                {
                    letterList.Add(log, words);
                }
            }

            var sorted = letterList.OrderBy(x => x.Value).ThenBy(y => y.Key).ToList();
            foreach (var item in digitList)
            {
                sorted.Add(item);
            }

            return sorted.Select(v => v.Key).ToArray();
        }

        [Fact]
        public static void ReorderLogFiles1()
        {
            var input = new string[] { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            var expected = new string[] { "let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6" };
            var result = ReorderLogFiles(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void ReorderLogFiles2()
        {
            var input = new string[] { "a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo", "a2 act car" };
            var expected = new string[]{"a2 act car", "g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7"};
            var result = ReorderLogFiles(input);
            Assert.Equal(expected, result);
        }
    }
}
