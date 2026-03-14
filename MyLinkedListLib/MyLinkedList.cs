using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedListLib;

public class MyLinkedList<T> : ICollection<T>
{
    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    #region Add Methods

    public void Add(T item)
    {
        AddLast(item); // ICollection convention
    }

    public void AddFirst(T item)
    {
        var node = new MyLinkedListNode<T>(item);

        node.Next = Head;
        Head = node;

        if (Count == 0)
            Tail = Head;

        Count++;
    }

    public void AddLast(T item)
    {
        var node = new MyLinkedListNode<T>(item);

        if (Count == 0)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail.Next = node;
            Tail = node;
        }

        Count++;
    }

    #endregion

    #region Remove Methods

    public void RemoveFirst()
    {
        if (Count == 0)
            throw new InvalidOperationException("List is empty.");

        Head = Head.Next;
        Count--;

        if (Count == 0)
            Tail = null;
    }

    public void RemoveLast()
    {
        if (Count == 0)
            throw new InvalidOperationException("List is empty.");

        if (Count == 1)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            var current = Head;

            while (current.Next != Tail)
                current = current.Next;

            current.Next = null;
            Tail = current;
        }

        Count--;
    }

    public bool Remove(T item)
    {
        if (Count == 0)
            return false;

        var comparer = EqualityComparer<T>.Default;

        if (comparer.Equals(Head.Value, item))
        {
            RemoveFirst();
            return true;
        }

        var current = Head;

        while (current.Next != null)
        {
            if (comparer.Equals(current.Next.Value, item))
            {
                if (current.Next == Tail)
                    Tail = current;

                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    #endregion

    #region Other ICollection Methods

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        var current = Head;

        while (current != null)
        {
            if (comparer.Equals(current.Value, item))
                return true;

            current = current.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (arrayIndex < 0 || arrayIndex + Count > array.Length)
            throw new ArgumentOutOfRangeException();

        var current = Head;

        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion

    #region Extra Helper

    public T GetAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException();

        var current = Head;
        int i = 0;

        while (i < index)
        {
            current = current.Next;
            i++;
        }

        return current.Value;
    }

    #endregion
}