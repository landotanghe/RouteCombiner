using System.Linq;

public class Permutation<T>{
    public T[] Values { get; set; }

    public override string ToString(){
        var readableValues = Values.Select(v => v.ToString()).ToArray();
        return string.Join(", ", readableValues);
    }
}