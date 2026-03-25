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
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        T value = _items.Head.Value;
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");
        return _items.Head.Value;
    }

    public void Clear()
    {
        _items.Clear();
    }
} 

