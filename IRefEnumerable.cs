namespace RefEnumerable
{
    public interface IRefEnumerable<T>
    {
        IRefEnumerator<T> GetEnumerator();
    }
}
