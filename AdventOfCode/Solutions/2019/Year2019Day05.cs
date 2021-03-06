using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Solutions.IntCode;

namespace AdventOfCode.Solutions
{
    public class Year2019Day05 : Solution
    {
        public override string Part1(string input)
        {
            int[] nums = input.Split(',').Select(int.Parse).ToArray();
            Dictionary<int, int> program = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                program.Add(i, nums[i]);

            Computer c = new Computer(program);
            c.input.Enqueue(1);
            c.RunUntilHalted();
            while (c.output.Peek() == 0)
                c.output.Dequeue();

            return c.output.Dequeue().ToString();
        }

        public override string Part2(string input)
        {
            int[] nums = input.Split(',').Select(int.Parse).ToArray();
            Dictionary<int, int> program = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                program.Add(i, nums[i]);

            Computer c = new Computer(program);
            c.input.Enqueue(5);
            c.RunUntilHalted();
            while (c.output.Peek() == 0)
                c.output.Dequeue();

            return c.output.Dequeue().ToString();
        }
    }
}