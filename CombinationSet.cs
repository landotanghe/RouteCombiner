using System;
using System.Collections.Generic;
using System.Linq;

public class CombinationSet<T>{
    public IEnumerable<Tuple<T,T>> Combinations{ get; set; }

    public override string ToString(){
        var readableCombinations = Combinations.Select(c =>$"{c.Item1}, {c.Item2}");
        return string.Join("\r\n", readableCombinations);
    }
}