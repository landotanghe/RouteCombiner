using System;
using System.Collections.Generic;
using System.Linq;

public class Combiner<T>{

    public List<CombinationSet<T>> GetCombinations(T[] set1, T[] set2){
        // Create extended sets with both at least one null
        // Make sure extended sets that are equally long, by pushing additional nulls
        var extendedSet1 = set1.ToList();
        extendedSet1.Add(default(T));

        var extendedSet2 = set2.ToList();
        extendedSet2.Add(default(T));

        while(extendedSet1.Count < extendedSet2.Count){
            extendedSet1.Add(default(T));
        }
        while(extendedSet2.Count < extendedSet1.Count){
            extendedSet2.Add(default(T));
        }


        var permutationLength = 1 + Math.Min(set1.Length, set2.Length);
        var permutations = new Permutator<T>().PermutatePrefix(extendedSet2.ToArray(), permutationLength);

        var combinationSets = new List<CombinationSet<T>>();
        foreach(var p in permutations){
            var combinationSet = CombineOneByOne(extendedSet1.ToArray(), p.Values);
            combinationSets.Add(combinationSet);
        }

        return combinationSets;
    }

    private CombinationSet<T> CombineOneByOne(T[] permutationSet1, T[] permutationSet2)
    {
        var combinations = new List<Tuple<T,T>>();
        for(var i = 0; i< permutationSet1.Length; i++){
            combinations.Add(new Tuple<T,T>(permutationSet1[i], permutationSet2[i]));
        }

        return new CombinationSet<T>{
            Combinations = combinations
        };
    }
}