using System.Runtime.InteropServices.ComTypes;

MyList<int> list = new(1, 2, 3, 4);
Console.WriteLine(list.Size);
list.Add(5);
Console.WriteLine(list.Size);
Console.WriteLine($"list[2] = {list[2]}");
list[2] = 2;
Console.WriteLine($"list[2] = {list[2]}");

internal class MyList<T>
{
    private T[] _list;
    public int Size { get; private set; } = 0;

    public MyList(params T[] list)
    {
        _list = list;
        Size = list.Length;
    }

    public void Add(T elem)
    {
        Size++;
        Array.Resize(ref _list, Size);
        _list[^1] = elem;
    }

    public T this[int i]
    {
        get => _list[i];
        set => _list[i] = value;
    }
}
