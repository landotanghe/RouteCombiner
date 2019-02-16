using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

public class Permutator<T>{
    public List<Permutation<T>> Permutate(T[] original){
        return GetPermutationsWithUniquePrefix(original, original.Length);
    }

    /// <summary>
    /// Create all permutations where the prefix is unique. The order of elements in the suffix is not guaranteed.
    /// F.e. permutations of 123 (prefix 1) will result in 123, 213, 321. 
    /// As the order is not guaranteed in the suffix 321, might also be returned as 312.
    /// Note only the position of the elements are considered, not the values
    /// F.e. permutations of 112 (prefix 2) will result in 112, 112, 211
    /// </summary>
    /// <param name="original"></param>
    /// <param name="prefixLength"></param>
    /// <returns></returns>
    public List<Permutation<T>> GetPermutationsWithUniquePrefix(T[] original, int prefixLength){
        if(prefixLength < 0){
            throw new ArgumentException(nameof(prefixLength), "prefxLength can't be below 0");
        }
        if(prefixLength > original.Length){
            throw new ArgumentException(nameof(prefixLength), "prefixLength can't be longer than array length");
        }

        // When prefixLength = 0, all permutations have the same prefix
        var permutations = new List<Permutation<T>>{
            new Permutation<T>{
                Values= original.ToArray()
            }
        };

        for(int currentPrefixLength = 1; currentPrefixLength <= prefixLength; currentPrefixLength++){
            permutations = ExpandPermutation(permutations, currentPrefixLength);
        }

        return permutations;
    }

    private static List<Permutation<T>> ExpandPermutation(List<Permutation<T>> original, int prefixLength){
        return original.SelectMany(o => ExpandPermutation(o, prefixLength)).ToList();
    }


    /// <summary>
    /// Create all permutations with the same prefixLength as the original
    /// </summary>
    /// <param name="original"></param>
    /// <param name="prefixIndex"></param>
    /// <returns></returns>
    private static List<Permutation<T>> ExpandPermutation(Permutation<T> original, int prefixLength){
        var permutations = new List<Permutation<T>>();
        permutations.Add(original);
        var lastIndexPrefix = prefixLength - 1;
        for(int i = lastIndexPrefix + 1; i < original.Values.Length; i++){
            var clonedValues = original.Values.ToArray();
            SwapElements(clonedValues, i, lastIndexPrefix);
            permutations.Add(new Permutation<T>{
                Values = clonedValues
            });
        }

        return permutations;
    }

    private static void SwapElements<T>(T[] values, int index1, int index2){
        var temp = values[index1];
        values[index1] = values[index2];
        values[index2] = temp;
    }
}