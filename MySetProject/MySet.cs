namespace MySetProject
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    namespace SetProject
    {
        // Հիմնական Set դասը
        public class Set<T> : IEnumerable<T> where T : IComparable<T>
        {
            private readonly List<T> _items = new List<T>();

            // 1. Կոնստրուկտորներ
            public Set() { }

            public Set(IEnumerable<T> items)
            {
                AddRange(items);
            }

            // 2. Հիմնական մեթոդներ
            public void Add(T item)
            {
                if (Contains(item))
                {
                    throw new InvalidOperationException("Item already exists in Set");
                }
                _items.Add(item);
            }

            public void AddRange(IEnumerable<T> items)
            {
                foreach (T item in items)
                    Add(item);
            }

            private void AddSkipDuplicates(T item)
            {
                if (!Contains(item))
                    _items.Add(item);
            }

            private void AddRangeSkipDuplicates(IEnumerable<T> items)
            {
                foreach (T item in items)
                    AddSkipDuplicates(item);
            }

            public bool Remove(T item)
            {
                return _items.Remove(item);
            }

            public bool Contains(T item)
            {
                return _items.Contains(item);
            }

            public int Count => _items.Count;

            // 3. Բազմությունների գործողություններ
            public Set<T> Union(Set<T> other)
            {
                Set<T> result = new Set<T>(_items);
                result.AddRangeSkipDuplicates(other._items);
                return result;
            }

            public Set<T> Intersection(Set<T> other)
            {
                Set<T> result = new Set<T>();
                foreach (T item in _items)
                {
                    if (other.Contains(item))
                        result.Add(item);
                }
                return result;
            }

            public Set<T> Difference(Set<T> other)
            {
                Set<T> result = new Set<T>(_items);
                foreach (T item in other._items)
                {
                    result.Remove(item);
                }
                return result;
            }

            public Set<T> SymmetricDifference(Set<T> other)
            {
                Set<T> intersection = Intersection(other);
                Set<T> union = Union(other);
                return union.Difference(intersection);
            }

            // 4. Enumerator-ներ (որպեսզի foreach-ը աշխատի)
            public IEnumerator<T> GetEnumerator()
            {
                return _items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _items.GetEnumerator();
            }
        }

        // Փորձարկման համար Main դասը
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Set<int> set1 = new Set<int>(new int[] { 1, 2, 3, 4 });
                    Set<int> set2 = new Set<int>(new int[] { 3, 4, 5, 6 });

                    var union = set1.Union(set2);
                    Console.WriteLine("Union: " + string.Join(", ", union)); 

                    var intersection = set1.Intersection(set2);
                    Console.WriteLine("Intersection: " + string.Join(", ", intersection)); 

                    var difference = set1.Difference(set2);
                    Console.WriteLine("Difference (set1 - set2): " + string.Join(", ", difference)); 

                    var symDiff = set1.SymmetricDifference(set2);
                    Console.WriteLine("Symmetric Difference: " + string.Join(", ", symDiff)); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
}
