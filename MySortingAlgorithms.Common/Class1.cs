namespace MySortingAlgorithms.Common;

public interface ISort<T> where T : IComparable<T>
{
    void Sort(T[] items);
}
