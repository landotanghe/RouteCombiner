using System;
using System.Linq;

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
            var combiner = new Combiner<Route>();

            var set1 = new[]{1, 2}.Select(x => new Route(x)).ToArray();
            var set2 = new[]{3, 4, 5, 6}.Select(x => new Route(x)).ToArray();

            var combinations = combiner.GetCombinations(set1, set2);
            foreach(var combination in combinations){
                Console.WriteLine("Combinations");
                Console.WriteLine(combination);
            }

            Console.WriteLine();
            Console.WriteLine("Combinations: ");
            combinations = combiner.GetCombinations(set2, set1);
            foreach(var combination in combinations){
                Console.WriteLine("Combinations");
                Console.WriteLine(combination);
            }
        }

        public class Route{
            public Route(int id){
                Id =id;
            }
            public int Id {get;set;}

            public override string ToString(){
                return Id.ToString();
            }
        }
    }
}
