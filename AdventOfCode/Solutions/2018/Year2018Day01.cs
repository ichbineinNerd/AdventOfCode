﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions
{
    public class Year2018Day01 : Solution
    {
        private static IEnumerable<int> Cycle(IEnumerable<int> source)
        {
            List<int> elementBuffer = new List<int>(((ICollection)source).Count);
            foreach (int element in source)
            {
                elementBuffer.Add(element);
            }

            ushort index = 0;
            while (true)
            {
                yield return elementBuffer[index];
                index++;
                index = (ushort)(index % elementBuffer.Count);
            }
        }
        
        public override string Part1(string s)
        {
            List<int> inputs = new List<int>();
            foreach (string s1 in s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                inputs.Add(int.Parse(s1));
            }
            return inputs.Sum().ToString();
        }

        public override string Part2(string s)
        {
            List<int> inputs = new List<int>();
            foreach (string s1 in s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                inputs.Add(int.Parse(s1));
            }

            int tmpSum = 0;
            HashSet<int> reachedSums = new HashSet<int>();

            foreach (int i in Cycle(inputs))
            {
                if (reachedSums.Contains(tmpSum))
                    break;
                reachedSums.Add(tmpSum);
                tmpSum += i;
            }

            return tmpSum.ToString();
        }
    }
}