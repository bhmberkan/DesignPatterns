namespace DesingPattern.Iterator.IteratorPattern
{
    public interface IMover<T>
    {
        IIterator<T> CreatorIterator();
    }
}
