using System;
using System.Collections.Generic;
using System.Linq;

public class Combiner<T> where T : class{

    public List<CombinationSet<T>> GetCombinations(T[] set1, T[] set2) {
        if(set1.Length > set2.Length){
            // Ensure set1 is smallest
            return GetCombinations(set2, set1).Select(c => c.Invert()).ToList();
        }

        // Create extended sets with both at least one null
        // Make sure extended sets that are equally long, by pushing additional nulls
        var extendedSet2 = set2.ToList();
        extendedSet2.Add(default(T));

        var extendedSet1 = set1.ToList();
        while(extendedSet1.Count < extendedSet2.Count){
            extendedSet1.Add(default(T));
        }

        var permutationLength = set1.Length;

        // Combine extended set1 with every permutation of extended set2
        // When there are lots of nulls (when set1 is much shorter than set2) there could be many equivalent permutations 
        // F.e set1( 1, x, x) set2 (2, 3, 4) => 1,2 x,3 x,4 and equivalent 1,2 x,4 x,3
        // (nulls are marked by x)
        // We know that set1 is shorter or as long as set2. We will keep extended set1 unchanged, so nulls are always at the end.
        var combinationSets = new List<CombinationSet<T>>();
        var permutationsSet2 = new Permutator<T>().GetPermutationsWithUniquePrefix(extendedSet2.ToArray(), permutationLength);
        foreach(var p in permutationsSet2){
            var combinationSet = CombineOneByOne(extendedSet1.ToArray(), p.Values);
            combinationSets.Add(combinationSet);
        }

        return combinationSets;
    }


    private List<T[]> GetRotations(T[] original)
    {
        var rotations = new List<T[]>();

        var rotation = original.ToArray();
        for(int i = 0; i < original.Length; i++){
            rotations.Add(rotation);
            rotation = RotateLeft(rotation);
        }

        return rotations;
    }

    private static T[] RotateLeft(T[] values){
        var rotation = new T[values.Length];
        for(int i= 0; i < values.Length - 1; i++){
            rotation[i] = values[i+1];
        }
        rotation[values.Length-1] = values[0];

        return rotation;
    }

    private CombinationSet<T> CombineOneByOne(T[] permutationSet1, T[] permutationSet2)
    {
        var combinations = new List<Tuple<T,T>>();
        for(var i = 0; i< permutationSet1.Length; i++){
            var value1 = permutationSet1[i];
            var value2 = permutationSet2[i];
            if(value1 != default(T) || value2 != default(T)){
                combinations.Add(new Tuple<T,T>(value1, value2));
            }
        }

        return new CombinationSet<T>{
            Combinations = combinations
        };
    }
}