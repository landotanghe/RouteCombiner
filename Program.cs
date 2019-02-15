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
        }
    }
}
