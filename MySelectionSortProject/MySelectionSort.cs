namespace MySelectionSortProject
{
    public class MySelectionSort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (Compare(items[j], items[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                swap(items, i, minIndex);
            }
        }

        private void swap(T[] items, int i, int minIndex)
        {
            T temp = items[i];
            items[i] = items[minIndex];
            items[minIndex] = temp;
        }

        private int Compare(T t1, T t2)
        {
            return t1.CompareTo(t2);
        }
    }
}
