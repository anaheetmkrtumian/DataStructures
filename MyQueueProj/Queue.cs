using MyLinkedListLib;
using System.Collections;

namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> _items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    public T Dequeue()
    {
        T value = _items.First();
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        return _items.First();
    }

    public int Count()
    {
        return (_items.Count);
    }
    public void Clear()
    {
        _items.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
