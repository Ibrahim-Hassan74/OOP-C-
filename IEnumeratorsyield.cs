public class Number : IEnumerable
{
    private int[] _values;
    public Number(params int[] nums)
    {
        _values = nums;
    }
    public IEnumerator GetEnumerator() 
    {
        foreach(var item in _values)
            yield return item;
    }
}
