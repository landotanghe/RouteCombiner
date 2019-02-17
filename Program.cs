using System;
using System.Linq;

namespace RouteCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            var permutator = new Permutator<int>();

            var permutations = permutator.Permutate(new[] { 1, 2});

            Console.WriteLine("Permutations before: ");
            foreach (var p in permutations)
            {
                Console.WriteLine(p.ToString());
            }

            permutations = permutator.AddDuplicateElementsToPermutations(permutations, 0, 2);

            Console.WriteLine("Permutations after: ");
            foreach (var p in permutations)
            {
                Console.WriteLine(p.ToString());
            }
            TestCombinations();

            // Console.WriteLine();
            // Console.WriteLine("Combinations: ");
            // combinations = combiner.GetCombinations(set2, set1);
            // foreach(var combination in combinations){
            //     Console.WriteLine("Combinations");
            //     Console.WriteLine(combination);
            // }
        }

        private static void TestCombinations()
        {
            Console.WriteLine("Combinations: ");
            var combiner = new Combiner<Route>();

            var set1 = new[] { 1, 2 }.Select(x => new Route(x)).ToArray();
            var set2 = new[] { 3, 4, 5, 6 }.Select(x => new Route(x)).ToArray();

            var combinations = combiner.GetCombinations(set1, set2);
            foreach (var combination in combinations)
            {
                Console.WriteLine("Combinations");
                Console.WriteLine(combination);
            }
        }

        public class Route : IComparable<Route>{
            public Route(int id){
                Id =id;
            }

            public int Id {get;set;}

            public int CompareTo(Route other)
            {
                return Id - other.Id;
            }

            public override string ToString(){
                return Id.ToString();
            }
        }
    }
}
