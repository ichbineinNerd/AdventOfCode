﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions
{
    public class Year2019Day06 : Solution
    {
        private static int GetOrbitCount(string id, Dictionary<string, string> direct, Dictionary<string, int> count)
        {
            if (id == "COM")
                return 0;
            if (count.ContainsKey(id))
                return count[id];
            int count2 = GetOrbitCount(direct[id], direct, count) + 1;
            count.Add(id, count2);
            return count2;
        }

        public override string Part1(string input)
        {
            /*
            input = "COM)B\nB)C\nC)D\nD)E\nE)F\nB)G\nG)H\nD)I\nE)J\nJ)K\nK)L";
            //*/

            Dictionary<string, string> orbits = new Dictionary<string, string>
            {
                { "COM", null }
            };

            foreach (string[] s in input.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(')')))
            {
                orbits.Add(s[1], s[0]);
            }

            Dictionary<string, int> counts = new Dictionary<string, int>();
            int count = 0;

            foreach (string s in orbits.Keys)
                count += GetOrbitCount(s, orbits, counts);

            return count.ToString();
        }

        public override string Part2(string input)
        {
            /*
            input = "COM)B\nB)C\nC)D\nD)E\nE)F\nB)G\nG)H\nD)I\nE)J\nJ)K\nK)L\nK)YOU\nI)SAN";
            //*/

            Dictionary<string, string> orbits = new Dictionary<string, string>
            {
                { "COM", null }
            };

            foreach (string[] s in input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(')')))
            {
                orbits.Add(s[1], s[0]);
            }

            List<string> youOrbits = new List<string>();
            string current = "YOU";
            while (current != null)
            {
                current = orbits[current];
                youOrbits.Add(current);
            }

            current = "SAN";
            int i = 0;
            while (current != null)
            {
                current = orbits[current];
                int indexOfCurrent = youOrbits.IndexOf(current);
                if (indexOfCurrent > 0)
                    return (i + indexOfCurrent).ToString();
                i++;
            }

            return "";
        }
    }
}
