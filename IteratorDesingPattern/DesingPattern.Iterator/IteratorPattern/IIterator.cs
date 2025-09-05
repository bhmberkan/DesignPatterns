namespace DesingPattern.Iterator.IteratorPattern
{
    public interface IIterator<T>
    {
        T CurrentItem { get; }
        bool NextLocation();
    }
}
