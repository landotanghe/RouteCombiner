using System;


namespace RouteCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            var permutator = new Permutator<int>();

            var permutations = permutator.PermutatePrefix(new[]{1, 2, 3, 4, 5, 6}, 4);
            foreach(var p in permutations){
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Combinations: ");
            var combiner = new Combiner<int>();

            var set1 = new[]{1, 2, 3, 4};
            var set2 = new[]{5, 6};

            var combinations = combiner.GetCombinations(set1, set2);
            foreach(var combination in combinations){
                Console.WriteLine("Combinations");
                Console.WriteLine(combination);
            }
        }
    }
}
