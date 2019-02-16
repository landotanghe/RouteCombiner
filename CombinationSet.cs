using System;
using System.Collections.Generic;
using System.Linq;

public class CombinationSet<T> where T: class{
    public IEnumerable<Tuple<T,T>> Combinations{ get; set; }

    public override string ToString(){
        var readableCombinations = Combinations
        //.OrderBy(c => c.Item1).ThenBy(c => c.Item2)
        .Select(c =>$"{PrettyPrint(c.Item1)}, {PrettyPrint(c.Item2)}");
        return string.Join("\r\n", readableCombinations);
    }

    public CombinationSet<T> Invert(){
        var invertedCombinations = Combinations.Select(c => new Tuple<T,T>(c.Item2, c.Item1));
        return new CombinationSet<T>{
            Combinations = invertedCombinations
        };
    }

    private string PrettyPrint(T item){
        if(item == null){
            return "-";
        }
        return item.ToString();
    }
}