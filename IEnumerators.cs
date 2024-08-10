public class Number : IEnumerable
{
    private int[] _values;
    public Number(params int[] nums)
    {
        _values = nums;
    }
    public IEnumerator GetEnumerator() => new Enumerator(this);
    private class Enumerator : IEnumerator
    {
        private int _idx;
        private Number _number;
        public Enumerator(Number number)
        {
            _number = number;
            _idx = -1;
        }
        public object Current
        {
            get
            {
                if (_idx == -1) throw new InvalidEnumArgumentException("Enumeration Not Started");
                if (_idx == _number._values.Length) throw new InvalidEnumArgumentException("Enumeration ended");
                return _number._values[_idx];
            }
        }

        public bool MoveNext()
        {
            if (_idx >= _number._values.Length - 1)
                return false;
            return ++_idx < _number._values.Length;
        }

        public void Reset()
        {
            _idx = -1;
        }
    }
}
