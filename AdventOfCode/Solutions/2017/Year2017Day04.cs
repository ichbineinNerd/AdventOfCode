﻿using System;
using System.Collections.Generic;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace AdventOfCode.Solutions._2017
{
    public class Year2017Day04 : Solution
    {
        public override string Part1(string input)
        {
            string[] passPhrases = input.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            int valid = passPhrases.Length;
            foreach (string s in passPhrases)
            {
                HashSet<string> words = new HashSet<string>();
                foreach (string word in s.Split(' '))
                {
                    if (words.Contains(word))
                    {
                        valid--;
                        break;
                    }

                    words.Add(word);
                }
            }

            return valid.ToString();
        }

        public override string Part2(string input)
        {
            string[] passPhrases = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int valid = passPhrases.Length;
            foreach (string s in passPhrases)
            {
                HashSet<string> words = new HashSet<string>();
                foreach (string word in s.Split(' '))
                {
                    string ordered = new string(word.OrderBy(c => c).ToArray());
                    if (words.Contains(ordered))
                    {
                        valid--;
                        break;
                    }

                    words.Add(ordered);
                }
            }

            return valid.ToString();
        }
    }
}