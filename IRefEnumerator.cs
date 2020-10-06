namespace RefEnumerable
{
    public interface IRefEnumerator<T>
    {
        bool MoveNext();

        bool MoveNext(ref T current)
        {
            if (MoveNext())
            {
                current = Current;
                return true;
            }

            return false;
        }

        T Current { get; }
    }
}
