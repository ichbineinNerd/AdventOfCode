﻿using System;
using System.Linq;

namespace AdventOfCode.Solutions._2017
{
    static class Extensions
    {
        public static void Deconstruct<T>(this T[] x, out T t0, out T t1)
        {
            t0 = x[0];
            t1 = x[1];
        }
    }
    public class Year2017Day15 : Solution
    {
        public override string Part1(string input)
        {
            long aValue, bValue;

            (aValue, bValue) = input.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => int.Parse(line.Split(' ', 5)[4])).ToArray();

            int count = 0;

            for (int i = 0; i < 40_000_000; i++)
            {
                aValue *= 16807L;
                bValue *= 48271L;
                aValue %= 2147483647L;
                bValue %= 2147483647L;

                if ((aValue & 0xFFFF) == (bValue & 0xFFFF))
                    count++;
            }

            return count.ToString();
        }

        public override string Part2(string input)
        {
            long aValue, bValue;

            (aValue, bValue) = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => int.Parse(line.Split(' ', 5)[4])).ToArray();

            int count = 0;

            for (int i = 0; i < 5_000_000; i++)
            {
                do
                    aValue = aValue * 16807 % 2147483647;
                while (aValue % 4 != 0);
                do
                    bValue = bValue * 48271 % 2147483647;
                while (bValue % 8 != 0);

                if ((aValue & 0xFFFF) == (bValue & 0xFFFF))
                    count++;
            }

            return count.ToString();
        }
    }
}