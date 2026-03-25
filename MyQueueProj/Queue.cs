using MyLinkedListLib;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    private MyLinkedList<T> _items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T value = _items.Head.Value; 
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _items.Head.Value;
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}