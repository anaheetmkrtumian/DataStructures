namespace MyBubbleSortProject;

public class MyBubbleSort<T>
    where T:IComparable<T> 
{
    public void Sort(T[] items)
    {
        bool swapped;

        do
        {
            swapped = false;
            for (int i = 1; i < items.Length; i++)
            { 
              if (Compare(items[i - 1], items[i])>0)
                {
                    swap(items, i - 1, i);
                    swapped = true;
                }
            }
        }while (swapped !=false);
    }

    private void swap(T[] items, int v, int i)
    {
        T temp = items[v];
        items[v] = items[i];    
        items[i] = temp;
    }

    private int Compare(T t1, T t2)
    {
        return t1.CompareTo(t2);        
    }
}

