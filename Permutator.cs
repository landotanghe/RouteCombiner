using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

public class Permutator<T>{
    public List<Permutation<T>> Permutate(T[] original){
        return PermutatePrefix(original, original.Length);
    }

    public List<Permutation<T>> PermutatePrefix(T[] original, int prefixLength){
        if(prefixLength <1){
            throw new ArgumentException(nameof(prefixLength), "at least 1 element should be permutated");
        }
        if(prefixLength > original.Length){
            throw new ArgumentException(nameof(prefixLength), "prefixLength can't be longer than array length");
        }

        var permutations = new List<Permutation<T>>{
            new Permutation<T>{
                Values= original.ToArray()
            }
        };

        for(int currentPrefixLength = 2; currentPrefixLength <= prefixLength; currentPrefixLength++){
            permutations = ExpandPermutation(permutations, original, currentPrefixLength);
        }

        return permutations;
    }


    /// <summary>
    /// Starting from a set of permutations for prefixLength -1, generates a set of permutations for prefixLength
    /// </summary>
    /// <param name="original"></param>
    /// <param name="prefixLength"></param>
    /// <returns></returns>
    private static List<Permutation<T>> ExpandPermutation(List<Permutation<T>> originalPermutations, T[] original, int prefixLength){
        var prefixIndex = prefixLength -1;

        //For prefixLength N, we already have N-1 original permutations
        //For every original permutation we add N permutations with the Nth element inserted at every possible position in the original permutation
        //F.e original permutation  123, N=4:
        //new permutations for 123: 1234, 4123, 1423, 1243
        //The same process will be repeated for all other original permutations (132, 213, 231, 312, 321)

        var result = originalPermutations;
        for(var indexToSwap = 0; indexToSwap < prefixIndex; indexToSwap++){
            var clonedPermutations = originalPermutations.Select(p => new Permutation<T>{
                Values = p.Values.ToArray()
            }).ToArray();

            foreach(var clone in clonedPermutations){
                SwapElements(clone.Values, prefixIndex, indexToSwap);
            }

            result = result.Concat(clonedPermutations).ToList();
        }

        return result;
    }

    private static void SwapElements<T>(T[] values, int index1, int index2){
        var temp = values[index1];
        values[index1] = values[index2];
        values[index2] = temp;
    }
}