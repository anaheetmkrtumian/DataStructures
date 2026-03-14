using BinaryTreeProj;

namespace MyBinaryTreeProj;

public class MyBinaryTree<T> where T : IComparable<T>
{
    public MyBinaryTreeNode<T> Root { get; private set; }

    public void Add(T data)
    {
        if (Root == null)
        {
            Root = new MyBinaryTreeNode<T>(data);
            return;
        }
        Insert(Root, data);
    }

    private void Insert(MyBinaryTreeNode<T> node, T data)
    {
        if (data.CompareTo(node.Value) < 0)
        {
            if (node.Left == null) node.Left = new MyBinaryTreeNode<T>(data);
            else Insert(node.Left, data);
        }
        else if (data.CompareTo(node.Value) > 0)
        {
            if (node.Right == null) node.Right = new MyBinaryTreeNode<T>(data);
            else Insert(node.Right, data);
        }
    }

    public bool Contains(T data)
    {
        MyBinaryTreeNode<T> current = Root;
        while (current != null)
        {
            int compare = data.CompareTo(current.Value);
            if (compare == 0) return true;
            current = (compare < 0) ? current.Left : current.Right;
        }
        return false;
    }

    public void Remove(T data)
    {
        Root = RemoveRecursive(Root, data);
    }

    private MyBinaryTreeNode<T> RemoveRecursive(MyBinaryTreeNode<T> node, T data)
    {
        if (node == null) return null;

        int compare = data.CompareTo(node.Value);
        if (compare < 0) node.Left = RemoveRecursive(node.Left, data);
        else if (compare > 0) node.Right = RemoveRecursive(node.Right, data);
        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            node.Value = GetMin(node.Right);
            node.Right = RemoveRecursive(node.Right, node.Value);
        }
        return node;
    }

    private T GetMin(MyBinaryTreeNode<T> node)
    {
        T min = node.Value;
        while (node.Left != null)
        {
            node = node.Left;
            min = node.Value;
        }
        return min;
    }

    public void PrintSorted()
    {
        InOrder(Root);
        Console.WriteLine();
    }

    private void InOrder(MyBinaryTreeNode<T> node)
    {
        if (node == null) return;
        InOrder(node.Left);
        Console.Write(node.Value + " ");
        InOrder(node.Right);
    }
}