using MyLinkedListLib;
using System;

namespace MyStackProj;

public class MyStack<T>
{
    private MyLinkedList<T> _items = new MyLinkedList<T>();

    public int Count
    {
        get { return _items.Count; }
    }

    public void Push(T item)
    {
        _items.AddFirst(item);
    }

    public T Pop()
    {
        T value = _items.First();
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        return _items.First();
    }
}
