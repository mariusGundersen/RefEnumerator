namespace RefEnumerable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    public class Program
    {

        [Params(10, 10_000)]
        public int Count;

        IEnumerable<int> GetRange(int from, int to)
        {
            for (var i = from; i < to; i++)
            {
                yield return i;
            }
        }

        [Benchmark(Baseline = true)]
        public int BuiltInnForeach()
        {
            var sum = 0;

            foreach (var current in GetRange(0, Count))
            {
                sum += current;
            }

            return sum;
        }

        [Benchmark]
        public int DecompiledEquivalent()
        {
            var sum = 0;
            var range = new EnumerableRange(0, Count);
            var rangeEnumerator = ((IEnumerable<int>)range).GetEnumerator();
            while (rangeEnumerator.MoveNext())
            {
                sum += rangeEnumerator.Current;
            }
            return sum;
        }

        [Benchmark]
        public int RefEnumerate()
        {
            var range = new RefRange(0, Count);
            var sum = 0;
            var rangeEnumerator = range.GetEnumerator();
            int current = 0;
            while (rangeEnumerator.MoveNext(ref current))
            {
                sum += current;
            }
            return sum;
        }

        [Benchmark]
        public int NonRefEnumerate()
        {
            var range = new NonRefRange(0, Count);
            var sum = 0;
            var rangeEnumerator = range.GetEnumerator();
            int current = 0;
            while (rangeEnumerator.MoveNext(ref current))
            {
                sum += current;
            }
            return sum;
        }

        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
        }
    }
}
